using ECDC.OutlookExtender.Exceptions;
using ECDC.OutlookExtender.Forms;
using ECDC.OutlookExtender.Properties;
using ECDC.Service.AI;
using Microsoft.Office.Tools.Ribbon;
using Microsoft.VisualBasic;
using System;
using System.Threading.Tasks;
using static ECDC.Service.Files.ModelDataManager;

namespace ECDC.OutlookExtender.Helpers
{
    /// <summary>
    /// Handles button control flows in the add-in, enabling interaction between the UI and backend logic.
    /// </summary>
    internal class ButtonControlFlow
    {
        /// <summary>
        /// Enum representing various control actions.
        /// </summary>
        public enum ControlActionEnum
        {
            Reply,
            OpenForm,
            TodoForm,
            Improve,
            Prompt,
        }

        #region public methods
        /// <summary>
        /// Loads the classification settings form and populates it with mailbox folder data.
        /// </summary>
        public static void LoadClassificationSettingsForm()
        {
            FaultHandledOperation.Execute(() =>
            {
                var form = new FormClassificationSettings();
                var thisAddIn = Globals.ThisAddIn;
                thisAddIn.ListAllMailboxFolders(form.TreeView_Folders);
                form.ShowDialog();
            });
        }




        /// <summary>
        /// Executes a control flow based on the selected action asynchronously.
        /// </summary>
        /// <param name="prompt">The prompt string used for OpenAI interactions.</param>
        /// <param name="text">The additional text or instructions.</param>
        /// <param name="action">The control action to execute.</param>
        /// <param name="sender">The RibbonButton triggering the action.</param>
        /// <param name="dropdownTemperature">Dropdown for temperature selection.</param>
        /// <param name="dropdownModel">Dropdown for model selection.</param>
        public static async Task ControlFlowAsync(string prompt, string text, ControlActionEnum action, RibbonButton sender, RibbonDropDown dropdownTemperature, RibbonDropDown dropdownModel)
        {
            sender.Enabled = false;

            try
            {
                await FaultHandledOperation.ExecuteAsync(async () =>
                {
                    if (!double.TryParse(dropdownTemperature.SelectedItem?.Tag?.ToString(), out double temperature))
                    {
                        throw new ArgumentException("Invalid temperature selected.");
                    }

                    string userName = Globals.ThisAddIn.GetCurrentUser();
                    prompt = prompt.Replace("{userName}", userName).Replace("{instructions}", text);

                    var addIn = Globals.ThisAddIn;
                    ModelItem item = dropdownModel.SelectedItem?.Tag as ModelItem ?? throw new ArgumentException("Invalid model selected.");

                    var openAiService = new OpenAiService(item.ClientKey, item.UrlEndPoint);
                    await ExecuteActionAsync(action, prompt, temperature, addIn, openAiService);
                });
            }
            finally
            {
                sender.Enabled = true;
            }
        }
        #endregion

        #region private methods
        /// <summary>
        /// Executes the specified action asynchronously.
        /// </summary>
        private static async Task ExecuteActionAsync(ControlActionEnum action, string prompt, double temperature, ThisAddIn addIn, OpenAiService service)
        {
            switch (action)
            {
                case ControlActionEnum.Reply:
                    await ReplyCurrentEmailAsync(prompt, temperature, addIn, service);
                    break;
                case ControlActionEnum.OpenForm:
                    await AnalyseCurrentEmailAsync(prompt, temperature, addIn, service);
                    break;
                case ControlActionEnum.TodoForm:
                    await FindTodosAsync(prompt, temperature, addIn, service);
                    break;
                case ControlActionEnum.Improve:
                    await ImproveAsync(prompt, temperature, addIn, service);
                    break;
                case ControlActionEnum.Prompt:
                    await AnalysePromptAsync(prompt, temperature, addIn, service);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(action), "Invalid action selected.");
            }
        }

        /// <summary>
        /// Replies to the current email using OpenAI's response.
        /// </summary>
        private static async Task ReplyCurrentEmailAsync(string prompt, double temperature, ThisAddIn addIn, OpenAiService service)
        {
            var mailItem = addIn.GetCurrentMailItem();
            if (mailItem == null)
                return;
            var reply = await service.SendToModel(mailItem.Body, prompt, temperature);
            addIn.ReplyToEmail(reply, mailItem);
        }

        /// <summary>
        /// Analyzes the current email and displays the response in a form.
        /// </summary>
        private static async Task AnalyseCurrentEmailAsync(string prompt, double temperature, ThisAddIn addIn, OpenAiService service)
        {
            var mailItem = addIn.GetCurrentMailItem();
            if (mailItem == null)
                return;
            var response = await service.SendToModel(mailItem.Body, prompt, temperature);
            addIn.ShowForm(response);
        }

        /// <summary>
        /// Analyzes a user-defined prompt and displays the response in a form.
        /// </summary>
        private static async Task AnalysePromptAsync(string prompt, double temperature, ThisAddIn addIn, OpenAiService service)
        {
            string instructions = Interaction.InputBox("Create a new text based on your instructions.", "What are your instructions?", "");
            if (string.IsNullOrEmpty(instructions)) return;

            var output = await service.SendToModel(instructions, prompt, temperature);
            addIn.ShowForm(output);
        }

        /// <summary>
        /// Finds TODO items in the current email and displays them in a tasks form.
        /// </summary>
        private static async Task FindTodosAsync(string prompt, double temperature, ThisAddIn addIn, OpenAiService service)
        {
            var mailItem = addIn.GetCurrentMailItem();
            if (mailItem == null)
                return;

            var response = await service.SendToModel(mailItem.Body, prompt, temperature);
            var todos = response.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            var formTodos = new FormTasks();
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
        /// Improves the selected text using OpenAI's response.
        /// </summary>
        private static async Task ImproveAsync(string prompt, double temperature, ThisAddIn addIn, OpenAiService service)
        {
            var selectedText = addIn.GetSelectedText();
            if (!string.IsNullOrEmpty(selectedText))
            {
                var response = await service.SendToModel(selectedText, prompt, temperature);
                addIn.ShowForm(response);
            }
        }
        #endregion
    }
}
