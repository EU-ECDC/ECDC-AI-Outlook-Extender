using ECDC.OutlookExtender.Exceptions;
using ECDC.OutlookExtender.Forms;
using ECDC.Service.AI;
using Microsoft.Office.Tools.Ribbon;
using Microsoft.VisualBasic;
using System;
using System.Configuration;
using static ECDC.Service.Files.ModelDataManager;
using Task = System.Threading.Tasks.Task;

namespace ECDC.OutlookExtender.Helpers
{
    /// <summary>
    /// Handles button control flows in the add-in, enabling interaction between the UI and backend logic.
    /// </summary>
    internal class ControlFlow
    {
        /// <summary>
        /// Enumeration of supported actions triggered by UI elements.
        /// </summary>
        public enum ControlActionEnum
        {
            Reply,
            OpenForm,
            TodoForm,
            Improve,
            Prompt,
            ClassifyTag,
            SummarizeDay,
        }

        #region public methods

        /// <summary>
        /// Opens a modal form to display or edit a message.
        /// </summary>
        /// <param name="message">The text to populate the form with.</param>
        public static void ShowForm(string message)
        {
            using (var form = new Edit())
            {
                form.RichTextBox_Edit.Text = message;
                form.ShowDialog();
            }
        }

        /// <summary>
        /// Loads the classification settings form and populates its folder tree.
        /// </summary>
        public static void LoadClassificationSettingsForm()
        {
            FaultHandledOperation.Execute(() =>
            {
                var form = new ClassificationSettings();
                var thisAddIn = Globals.ThisAddIn;
                thisAddIn.ListAllMailboxFolders(form.TreeView_Folders);
                form.ShowDialog();
            });
        }

        /// <summary>
        /// Main control flow for actions using AI services. Disables the triggering UI button during execution.
        /// </summary>
        public static async Task ControlFlowAsync(string prompt, string text, ControlActionEnum action, RibbonButton sender, RibbonDropDown dropdownTemperature, RibbonDropDown dropdownModel)
        {
            sender.Enabled = false;

            await FaultHandledOperation.ExecuteAsync(async () =>
            {
                var temperature = GetTemperatureFromDropDown(dropdownTemperature);
                ModelItem model = GetModelItemFromDropDown(dropdownModel);

                string userName = Globals.ThisAddIn.GetCurrentUser();
                prompt = prompt.Replace("{userName}", userName).Replace("{instructions}", text);
                   
                var openAiService = new OpenAiService(model.ClientKey, model.UrlEndPoint, model.Name);
                await ExecuteActionAsync(action, prompt, temperature, model.MaxTokens, model.TopP, Globals.ThisAddIn, openAiService);
            });

            sender.Enabled = true;
        }
        
        /// <summary>
        /// Opens a custom chat window using selected model and temperature.
        /// </summary>
        public static async Task OpenChat(RibbonButton sender, RibbonDropDown dropdownTemperature, RibbonDropDown dropdownModel, string context)
        {
            sender.Enabled = false;
            
            await FaultHandledOperation.ExecuteAsync(() =>
            {
                var form = new Chat((RibbonButton)sender, dropdownTemperature, dropdownModel, context);
                form.ShowDialog();
                return System.Threading.Tasks.Task.CompletedTask;
            });

            sender.Enabled = true;

        }
        
        /// <summary>
        /// Opens the settings form initialized with current application settings.
        /// </summary>
        public static void OpenSettingsForm(ApplicationSettingsBase settings)
        {
            FaultHandledOperation.Execute(() =>
            {
                Settings formSettings = new Settings(settings);
                formSettings.ShowDialog();
            });
        }

        /// <summary>
        /// Extracts the selected model from the dropdown.
        /// </summary>
        public static ModelItem GetModelItemFromDropDown(RibbonDropDown dropdownModel)
        {
            ModelItem model = dropdownModel.SelectedItem?.Tag as ModelItem ?? throw new ArgumentException("Invalid model selected.");
            return model;
        }

        /// <summary>
        /// Extracts and parses the temperature value from the dropdown.
        /// </summary>
        public static double GetTemperatureFromDropDown(RibbonDropDown dropdownTemperature)
        {
            if (!double.TryParse(dropdownTemperature.SelectedItem?.Tag?.ToString(), out double temperature))
            {
                throw new ArgumentException("Invalid temperature selected.");
            }
            return temperature;
        }

        #endregion

        #region private methods

        /// <summary>
        /// Central dispatcher method to execute the corresponding logic based on selected action.
        /// </summary>
        private static async Task ExecuteActionAsync(ControlActionEnum action, string prompt, double temperature, int maxTokens, double topP, ThisAddIn addIn, OpenAiService service)
        {
            switch (action)
            {
                case ControlActionEnum.Reply:
                    await ReplyCurrentEmailAsync(prompt, temperature, maxTokens, topP, addIn, service);
                    break;
                case ControlActionEnum.OpenForm:
                    await AnalyseCurrentEmailAsync(prompt, temperature, maxTokens, topP, addIn, service);
                    break;
                case ControlActionEnum.TodoForm:
                    await FindTodosAsync(prompt, temperature, maxTokens, topP, addIn, service);
                    break;
                case ControlActionEnum.Improve:
                    await ImproveAsync(prompt, temperature, maxTokens, topP, addIn, service);
                    break;
                case ControlActionEnum.Prompt:
                    await AnalysePromptAsync(prompt, temperature, maxTokens, topP, addIn, service);
                    break;
                case ControlActionEnum.ClassifyTag:
                    await ClassifyTagAsync(prompt, temperature, maxTokens, topP, addIn, service);
                    break;
                case ControlActionEnum.SummarizeDay:
                    SummarizeDay(prompt, temperature, maxTokens, topP, addIn, service);
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(action), "Invalid action selected.");
            }
        }

        /// <summary>
        /// Uses the AI model to generate a reply for the current email and sends it.
        /// </summary>
        private static async Task ReplyCurrentEmailAsync(string prompt, double temperature, int maxTokens, double topP, ThisAddIn addIn, OpenAiService service)
        {
            var mailItem = addIn.GetCurrentMailItem();
            if (mailItem == null)
                return;
            var reply = await service.SendToModel(mailItem.Body, prompt, temperature, maxTokens, topP);
            addIn.ReplyToEmail(reply, mailItem);
        }

        /// <summary>
        /// Analyzes the current email with AI and shows the result in a form.
        /// </summary>
        private static async Task AnalyseCurrentEmailAsync(string prompt, double temperature, int maxTokens, double topP, ThisAddIn addIn, OpenAiService service)
        {
            var mailItem = addIn.GetCurrentMailItem();
            if (mailItem == null)
                return;
            var response = await service.SendToModel(mailItem.Body, prompt, temperature, maxTokens, topP);
            ShowForm(response);
        }

        /// <summary>
        /// Prompts the user for instructions and sends them to the AI for content generation.
        /// </summary>
        private static async Task AnalysePromptAsync(string prompt, double temperature, int maxTokens, double topP, ThisAddIn addIn, OpenAiService service)
        {
            string instructions = Interaction.InputBox("Create a new text based on your instructions.", "What are your instructions?", "");
            if (string.IsNullOrEmpty(instructions)) return;

            var output = await service.SendToModel(instructions, prompt, temperature, maxTokens, topP);
            ShowForm(output);
        }

        /// <summary>
        /// Identifies todos in the current email and displays them in a form for user action.
        /// </summary>
        private static async Task FindTodosAsync(string prompt, double temperature, int maxTokens, double topP, ThisAddIn addIn, OpenAiService service)
        {
            var mailItem = addIn.GetCurrentMailItem();
            if (mailItem == null)
                return;

            var response = await service.SendToModel(mailItem.Body, prompt, temperature, maxTokens, topP);
            var todos = response.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            var formTodos = new Forms.Tasks();
            var todoLists = addIn.GetTodoLists();

            formTodos.ComboBox_Todos.Items.Clear();
            formTodos.ComboBox_Todos.Items.AddRange(todoLists.ToArray());
            formTodos.ComboBox_Todos.SelectedIndex = formTodos.ComboBox_Todos.Items.Count > 0 ? 0 : -1;
            formTodos.Button_Create.Enabled = formTodos.ComboBox_Todos.Items.Count > 0;

            formTodos.CheckedListBox_Tasks.Items.Clear();
            formTodos.CheckedListBox_Tasks.Items.AddRange(todos);
            formTodos.ShowDialog();
        }

        /// <summary>
        /// Sends selected text to the AI for improvement and shows the result.
        /// </summary>
        private static async Task ImproveAsync(string prompt, double temperature, int maxTokens, double topP, ThisAddIn addIn, OpenAiService service)
        {
            var selectedText = addIn.GetSelectedText();
            if (!string.IsNullOrEmpty(selectedText))
            {
                var response = await service.SendToModel(selectedText, prompt, temperature, maxTokens, topP);
                ShowForm(response);
            }
        }

        /// <summary>
        /// Summarizes the user's day based on appointments and emails for a selected date.
        /// </summary>
        private static void SummarizeDay(string prompt, double temperature, int maxTokens, double topP, ThisAddIn addIn, OpenAiService service)
        {
            DatePicker form = new DatePicker();
            form.DateChanged += async (sender, e) =>
            {

                var thisAddIn = Globals.ThisAddIn;
                var startDate = e.SelectedDate;
                var endDate = startDate.AddDays(1);

                var events = thisAddIn.GetAppointments(startDate, endDate);
                var emails = thisAddIn.GetEmails(startDate, endDate);                

                string instructions =
                    $"The information is for the following date: {startDate.ToString("yyyy/MM/dd")}.\n\r" +
                    $"Consider the following email exchange: «{emails}». \n\r" +
                    $"Consider the following events : «{events}». \n\r";

                string response = await service.SendToModel(instructions, prompt, temperature, maxTokens, topP);
                form.Close();
                ShowForm(response);

                
            };
            form.ShowDialog();                     
        }

        /// <summary>
        /// Uses AI to classify the email and shows the result either in a classification form or plain text form.
        /// </summary>
        private static async Task ClassifyTagAsync(string prompt, double temperature, int maxTokens, double topP, ThisAddIn addIn, OpenAiService service)
        {
            var mailItem = addIn.GetCurrentMailItem();
            if (mailItem == null)
                return;

            var output = await service.SendToModel(mailItem.Body, prompt, temperature, maxTokens, topP);

            var exists = addIn.MailboxFolderExists(output);
            if (exists)
            {

                using (var form = new ClassifyEmail())
                {
                    form.TextBox_classification.Text = output;
                    form.ShowDialog();
                }
            }
            else
            {
                ShowOutputForm(output);
            }
        }

        /// <summary>
        /// Helper method to show an output in a modal text form.
        /// </summary>
        private static void ShowOutputForm(string message)
        {
            using (var form = new Edit())
            {
                form.RichTextBox_Edit.Text = message;
                form.ShowDialog();
            }
        }

        #endregion
    }
}
