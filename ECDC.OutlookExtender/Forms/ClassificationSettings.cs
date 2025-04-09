using ECDC.Service.Files;
using System;
using System.Windows.Forms;

namespace ECDC.OutlookExtender.Forms
{
    public partial class ClassificationSettings : Form
    {
        public ClassificationSettings()
        {
            InitializeComponent();
        }

        private void Button_Save_Click(object sender, EventArgs e)
        {
            var data = new MetaDataManager();
            data.Save(Label_Path.Text, TextBox_Description.Text);
        }

        private void TreeView_Folders_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var path = Globals.ThisAddIn.GetFullFolderPathFromName(TreeView_Folders.SelectedNode);
            if (path != null)
            {
                Label_Path.Text = path;
                TextBox_Description.Enabled = true;
                TextBox_Description.Text = new MetaDataManager().Load(path);
                Button_Save.Enabled = true;
            }
            else
            {
                Label_Path.Text = "Not valid";
                TextBox_Description.Text = string.Empty;

                TextBox_Description.Enabled = false;
                Button_Save.Enabled = false;
            }
        }
    }
}
