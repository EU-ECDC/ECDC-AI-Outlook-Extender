using ECDC.OutlookExtender.Forms;
using ECDC.OutlookExtender.Properties;
using ECDC.Service.Files;


using Microsoft.Office.Tools.Ribbon;
using Microsoft.VisualBasic;
using System;
using static ECDC.OutlookExtender.Helpers.ControlFlow;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace ECDC.OutlookExtender
{


    public partial class Ribbon_MailRead
    {

        private void Ribbon_ECDC_Load(object sender, RibbonUIEventArgs e)
        {
            
            Globals.ThisAddIn.LoadDropDownWithModels(DropDown_Models, Label_Version);

            Group_Settings.DialogLauncherClick += Group_Settings_DialogLauncherClick;

            Button_PT.Click += new RibbonControlEventHandler(this.Button_Translate_Click);
            Button_RO.Click += new RibbonControlEventHandler(this.Button_Translate_Click);
            Button_GR.Click += new RibbonControlEventHandler(this.Button_Translate_Click);
            Button_EN.Click += new RibbonControlEventHandler(this.Button_Translate_Click);
            Button_PL.Click += new RibbonControlEventHandler(this.Button_Translate_Click);

            Button_GE.Click += new RibbonControlEventHandler(this.Button_Translate_Click);
            Button_FR.Click += new RibbonControlEventHandler(this.Button_Translate_Click);
            Button_NL.Click += new RibbonControlEventHandler(this.Button_Translate_Click);
        }

        private void Group_Settings_DialogLauncherClick(object sender, RibbonControlEventArgs e)
        {
            OpenSettingsForm(ReadRibbon.Default);
        }

        private void Button_ClassificationSettings_Click(object sender, RibbonControlEventArgs e)
        {
            LoadClassificationSettingsForm();
        }

        private async void Button_Translate_Click(object sender, RibbonControlEventArgs e)
        {
            await ControlFlowAsync(
                new ReadRibbon().Translate,
                ((RibbonButton)sender).Label,
                ControlActionEnum.OpenForm,
                (RibbonButton)sender,
                DropDown_Temperature,
                DropDown_Models);
        }
        
        private async void Button_Summarize_Click(object sender, RibbonControlEventArgs e)
        {
            await ControlFlowAsync(
                new ReadRibbon().SummarizeEmail, 
                string.Empty, 
                ControlActionEnum.Reply, 
                (RibbonButton)sender, 
                DropDown_Temperature,
                DropDown_Models);            
        }

        private async void Button_SummarizeTimeline_Click(object sender, RibbonControlEventArgs e)
        {
            await ControlFlowAsync(
                new ReadRibbon().SummarizeWithTimeline, 
                string.Empty, 
                ControlActionEnum.Reply, 
                (RibbonButton)sender, 
                DropDown_Temperature,
                DropDown_Models);
        }

        private async void Button_AutomaticRepy_Click(object sender, RibbonControlEventArgs e)
        {
            await ControlFlowAsync(
                new ReadRibbon().AutomaticRepy, 
                string.Empty, 
                ControlActionEnum.Reply, 
                (RibbonButton)sender, 
                DropDown_Temperature,
                DropDown_Models);
        }

        private async void Button_AssistedReply_Click(object sender, RibbonControlEventArgs e)
        {
            string instructions = Interaction.InputBox("Taking into to consideration this email interaction, what are your instructions?", "What do you want to ask.", "");
            if (instructions != string.Empty)
            {
                await ControlFlowAsync(
                    new ReadRibbon().AssistedReply, 
                    instructions, 
                    ControlActionEnum.Reply, 
                    (RibbonButton)sender,
                    DropDown_Temperature,
                    DropDown_Models);
            }
        }
        
        private async void Button_Actions_Click(object sender, RibbonControlEventArgs e)
        {
            await ControlFlowAsync(
                new ReadRibbon().IdentifyActions, 
                string.Empty, 
                ControlActionEnum.OpenForm, 
                (RibbonButton)sender, 
                DropDown_Temperature,
                DropDown_Models);
        }

        private async void Button_IdentifyTodos_Click(object sender, RibbonControlEventArgs e)
        {
            await ControlFlowAsync(
                new ReadRibbon().IdentifyTodos, 
                string.Empty, 
                ControlActionEnum.TodoForm, 
                (RibbonButton)sender, 
                DropDown_Temperature,
                DropDown_Models);
        }

        private async void Button_Prompt_Click(object sender, RibbonControlEventArgs e)
        {
            string prompt = Interaction.InputBox("Taking into to consideration this email interaction, what is your question?", "What do you want to ask.", "");
            if (prompt != string.Empty)
            { 
                await ControlFlowAsync(
                    prompt, 
                    string.Empty, 
                    ControlActionEnum.OpenForm, 
                    (RibbonButton)sender, 
                    DropDown_Temperature,
                    DropDown_Models);
            }
        }

        private async void Button_Classify_Click(object sender, RibbonControlEventArgs e)
        {

            var categories = new MetaDataManager().ToString();

            await ControlFlowAsync(
                new ReadRibbon().SeetingsBasedClassification,
                categories,
                ControlActionEnum.ClassifyTag,
                (RibbonButton)sender,
                DropDown_Temperature,
                DropDown_Models);
        }

        private async void Button_AutoClassify_Click(object sender, RibbonControlEventArgs e)
        {
            await ControlFlowAsync(
                new ReadRibbon().AutomaticClassification,
                string.Empty,
                ControlActionEnum.OpenForm,
                (RibbonButton)sender,
                DropDown_Temperature,
                DropDown_Models);
        }

        private async void ButtonDetectAI_Click(object sender, RibbonControlEventArgs e)
        {
            await ControlFlowAsync(
                new ReadRibbon().AIDetection,
                string.Empty,
                ControlActionEnum.OpenForm,
                (RibbonButton)sender,
                DropDown_Temperature,
                DropDown_Models);
        }

        private async void Button_Chat_Click(object sender, RibbonControlEventArgs e)
        {
            var emailItem = Globals.ThisAddIn.GetCurrentMailItem();

            string context = string.Empty;            
            if (emailItem != null)
            {
                context = $"Consider the following email exchange:«\n{emailItem?.Body}\n»";
            }

            await OpenChat(
                (RibbonButton)sender,
                DropDown_Temperature,
                DropDown_Models,
                context);
        }
    }
}
