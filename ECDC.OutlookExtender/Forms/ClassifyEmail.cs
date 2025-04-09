using ECDC.OutlookExtender.Properties;
using ECDC.Service.Files;
using Microsoft.Office.Tools.Ribbon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ECDC.OutlookExtender.Helpers.ControlFlow;

namespace ECDC.OutlookExtender.Forms
{
    public partial class ClassifyEmail : Form
    {
        public ClassifyEmail()
        {
            InitializeComponent();
        }

        private void Button_AssignCategory_Click(object sender, EventArgs e)
        {
            string path = TextBox_classification.Text;
            string finalFolder = path.Split('\\').Last();


            var addIn = Globals.ThisAddIn;
            addIn.EnsureCategoryExists(finalFolder);
            addIn.AssignCategoryToMailItem(finalFolder);

            this.Close();
        }

        private void Button_MoveToFolder_Click(object sender, EventArgs e)
        {
            var addIn = Globals.ThisAddIn;
            var folderPath = TextBox_classification.Text;
            addIn.MoveCurrentMailItemToFolder(folderPath);
            this.Close();
        }

    }
}
