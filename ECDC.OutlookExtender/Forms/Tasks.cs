using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace ECDC.OutlookExtender.Forms
{
    public partial class Tasks : Form
    {
        public Tasks()
        {
            InitializeComponent();
        }

        private void Button_Create_Click(object sender, EventArgs e)
        {
            var thisAddin = Globals.ThisAddIn;
            var items = new List<string>();

            foreach (var item in CheckedListBox_Tasks.CheckedItems)
            {
                items.Add(item.ToString());
            }

            var list = ComboBox_Todos.Text;

            var orderedItems = items.OrderByDescending(task => task).ToList();
            thisAddin.AddTaskToSpecificTodoList(list, orderedItems);

            this.Close();
        }
    }
}
