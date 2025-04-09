using System;
using System.Windows.Forms;

namespace ECDC.OutlookExtender.Forms
{
    public partial class DatePicker : Form
    {
        public class DatePickedEventArgs : EventArgs
        {
            public DateTime SelectedDate { get; }

            public DatePickedEventArgs(DateTime selectedDate)
            {
                SelectedDate  = selectedDate;
            }
        }

        public event EventHandler<DatePickedEventArgs> DateChanged;

        public DatePicker()
        {
            InitializeComponent();
            DateTimePicker_Choose.MaxDate = System.DateTime.Today;
        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            Button_OK.Enabled = false ;
            Button_Cancel.Enabled = false ;
            this.Text = "Please wait...";

            var selectedDate = DateTimePicker_Choose.Value.Date;
            DateChanged?.Invoke(this, new DatePickedEventArgs(selectedDate));
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
