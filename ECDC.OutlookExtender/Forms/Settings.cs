using System;
using System.Configuration;
using System.Windows.Forms;

namespace ECDC.OutlookExtender.Forms
{
    public partial class Settings : Form
    {
        private ApplicationSettingsBase _settings;
        public Settings(ApplicationSettingsBase settings)
        {
            InitializeComponent();    
            _settings = settings;
            PropertyGrid_Main.SelectedObject = _settings;                   
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            Label_Info.Text = Globals.ThisAddIn.GetVersion();
        }

        private void Button_Apply_Click(object sender, EventArgs e)
        {
            _settings.Save();
        }

        private void Button_Reset_Click(object sender, EventArgs e)
        {
            _settings.Reset();
            PropertyGrid_Main.SelectedObject = _settings;
        }
    }
}
