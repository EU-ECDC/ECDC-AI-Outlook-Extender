using ECDC.OutlookExtender.Properties;
using Microsoft.Office.Tools.Ribbon;
using static ECDC.OutlookExtender.Helpers.ControlFlow;

namespace ECDC.OutlookExtender
{
    public partial class Ribbon_Main
    {
        
        private void Ribbon_Main_Load(object sender, RibbonUIEventArgs e)
        {            
            Globals.ThisAddIn.LoadDropDownWithModels(DropDown_Models, Label_Version);
        }

        private async void Button_DailySummary_Click(object sender, RibbonControlEventArgs e)
        {
            await ControlFlowAsync(
                new MainRibbon().SummarizeDay,
                string.Empty,
                ControlActionEnum.SummarizeDay,
                Button_DailySummary,
                DropDown_Temperature,
                DropDown_Models);
        }

        private async void Button_Chat_Click(object sender, RibbonControlEventArgs e)
        {
            await OpenChat(
                (RibbonButton)sender, 
                DropDown_Temperature, 
                DropDown_Models, 
                string.Empty);
        }       

        private void Button_ClassificationSettings_Click(object sender, RibbonControlEventArgs e)
        {
            LoadClassificationSettingsForm();
        }
    }
}
