using ECDC.OutlookExtender.Forms;
using ECDC.OutlookExtender.Properties;
using Microsoft.Office.Tools.Ribbon;
using static ECDC.OutlookExtender.Helpers.ControlFlow;

namespace ECDC.OutlookExtender
{
    public partial class Ribbon_MailCompose
    {
        private void Ribbon_MailWrite_Load(object sender, RibbonUIEventArgs e)
        {
            Group_Settings.DialogLauncherClick += Group_Settings_DialogLauncherClick;    
            
            Globals.ThisAddIn.LoadDropDownWithModels(DropDown_Models, Label_Version);

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
            OpenSettingsForm(ComposeRibbon.Default);
        }

        private async void Button_Translate_Click(object sender, RibbonControlEventArgs e)
        {
            await ControlFlowAsync(
                new ComposeRibbon().Translate,
                ((RibbonButton)sender).Label,
                ControlActionEnum.Improve,
                (RibbonButton)sender,
                DropDown_Temperature,
                DropDown_Models);
        }

        private async void Button_MakeNicer_Click(object sender, RibbonControlEventArgs e)
        {
            await ControlFlowAsync(
                new ComposeRibbon().MakeNicer, 
                null, 
                ControlActionEnum.Improve, 
                (RibbonButton)sender, 
                DropDown_Temperature,
                DropDown_Models);
        }

        private async void Button_Improve_Click(object sender, RibbonControlEventArgs e)
        {
            await ControlFlowAsync(
                new ComposeRibbon().Improve, 
                null, 
                ControlActionEnum.Improve, 
                (RibbonButton)sender, 
                DropDown_Temperature,
                DropDown_Models);
        }

        private async void Button_Correct_Click(object sender, RibbonControlEventArgs e)
        {
            await ControlFlowAsync(
                new ComposeRibbon().Correct, 
                null, 
                ControlActionEnum.Improve, 
                (RibbonButton)sender, 
                DropDown_Temperature,
                DropDown_Models);
        }

        private async void Button_Prompt_Click(object sender, RibbonControlEventArgs e)
        {
            await ControlFlowAsync(
                new ComposeRibbon().Prompt, 
                null, 
                ControlActionEnum.Prompt, 
                (RibbonButton)sender, 
                DropDown_Temperature,
                DropDown_Models);
        }

        private async void Button_Chat_Click(object sender, RibbonControlEventArgs e)
        {
            var body = Globals.ThisAddIn.GetCurrentEmail();
            var context = $"Consider the following email:«\n{body}\n»";

            await OpenChat(
                (RibbonButton)sender,
                DropDown_Temperature,
                DropDown_Models,
                context);                       
        }
    }
}
