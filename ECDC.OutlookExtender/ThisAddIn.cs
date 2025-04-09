using ECDC.OutlookExtender.Exceptions;
using ECDC.OutlookExtender.Forms;
using ECDC.Service.Files;
using Markdig;
using Microsoft.Office.Interop.Outlook;
using Microsoft.Office.Interop.Word;
using Microsoft.Office.Tools.Ribbon;
using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static ECDC.Service.AI.IndexerService;
using static System.Net.Mime.MediaTypeNames;
using Action = System.Action;

namespace ECDC.OutlookExtender
{
    public partial class ThisAddIn
    {

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {

        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            // Note: Outlook no longer raises this event. If you have code that 
            //    must run when Outlook shuts down, see https://go.microsoft.com/fwlink/?LinkId=506785
        }

        public void LoadDropDownWithModels(RibbonDropDown dropDown, RibbonLabel label)
        {

            FaultHandledOperation.Execute(() =>
            {
                // Create the data manager
                var data = new ModelDataManager();

                // Load data asynchronously
                var items = data.Load();

                // Clear existing items
                dropDown.Items.Clear();

                // Add the loaded items to the drop-down
                foreach (var item in items)
                {
                    var dropDownItem = Globals
                        .Factory
                        .GetRibbonFactory()
                        .CreateRibbonDropDownItem();

                    dropDownItem.Label = item.Name;
                    dropDownItem.Tag = item;
                    dropDownItem.SuperTip = item.ToString();

                    dropDown.Items.Add(dropDownItem);
                }

                label.Label = Globals.ThisAddIn.GetVersion();
            });
        }

        public void ReplyToEmail(string message, MailItem referenceEmail)
        {


            MailItem newEmail = referenceEmail.ReplyAll();

            Inspector inspector = newEmail.GetInspector;
            var wordEditor = inspector.WordEditor;
            var signature = wordEditor.Application.EmailOptions.EmailSignature;
            string signatureHtml = signature.NewMessageSignature;

            // Set the HTMLBody of the reply (including the original message and signature)
            newEmail.HTMLBody = newEmail.HTMLBody + "<br>" + signatureHtml;

            string formatedMessage = Markdown.ToHtml(message);
            newEmail.HTMLBody = "<p><b>ECDC AI generated message</b> &nbsp; </p><p>" + formatedMessage + "</p> <i>AI models are inaccurate, validate your results </i> <hr/>" + newEmail.HTMLBody;            
            
            newEmail.Display();

        }

        public MailItem ReplyToEmail(MailItem referenceEmail)
        {


            MailItem newEmail = referenceEmail.ReplyAll();

            Inspector inspector = newEmail.GetInspector;
            var wordEditor = inspector.WordEditor;
            var signature = wordEditor.Application.EmailOptions.EmailSignature;
            string signatureHtml = signature.NewMessageSignature;

            // Set the HTMLBody of the reply (including the original message and signature)
            newEmail.HTMLBody = newEmail.HTMLBody + "<br>" + signatureHtml;

            return newEmail;
    
        }

        public void ShowForm(string message)
        {
            using (var form = new Edit())
            {
                form.RichTextBox_Edit.Text = message;
                form.ShowDialog();
            }
        }

        public bool IsEmailSensitiveOrConfidential(MailItem mailItem)
        {
            var mipLabels = mailItem.PropertyAccessor.GetProperty("http://schemas.microsoft.com/mapi/string/{00020386-0000-0000-C000-000000000046}/msip_labels/0x0000001F") as string;
            var containsSensitiveInfo = mipLabels.Contains("SENSITIVE (SNC)");
            var isConfidential = mailItem.Sensitivity == OlSensitivity.olConfidential;
            return (containsSensitiveInfo || isConfidential);
        }

        public MailItem GetCurrentMailItem()
        {
            
            Explorer explorer = Application.ActiveExplorer();
            if (explorer != null && explorer.Selection.Count > 0)
            {
                var mailItem = explorer.Selection[1] as MailItem;
                var sensitiveInfo = IsEmailSensitiveOrConfidential(mailItem);

                if (sensitiveInfo == false)
                {
                    return mailItem;
                }
                else 
                { 
                    MessageBox.Show(
                        "You are not allowed to use this feature on Sensitive or Confidential information",
                        "Security",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }                
            }
            return null;
        }

        public string GetCurrentEmail()
        {
            string ret = string.Empty;
            FaultHandledOperation.Execute(() =>
            {
                Inspector inspector = Globals.ThisAddIn.Application.ActiveInspector();
                if (inspector != null && inspector.CurrentItem is MailItem mailItem)
                {
                    ret = $"Subject: {mailItem.Subject}\nTo: {mailItem.To}\nCC: {mailItem.CC}\nCC: {mailItem.BCC}\nBody:\n{mailItem.Body}";
                }
            });            
            return ret;
        }

        public string GetAppointments(DateTime startdate, DateTime enddate)
        {

            StringBuilder result = new StringBuilder();

            var outlookApp = this.Application;

            // Get the namespace
            NameSpace outlookNamespace = outlookApp.GetNamespace("MAPI");

            // Get the default calendar folder
            MAPIFolder calendarFolder = outlookNamespace.GetDefaultFolder(OlDefaultFolders.olFolderCalendar);

            // Get the items in the calendar folder
            Items calendarItems = calendarFolder.Items;

            // Sort items by start date
            calendarItems.Sort("[Start]", Type.Missing);
            calendarItems.IncludeRecurrences = true; // Include recurring appointments

            // Create a filter for the specific day
            string filter = "[Start] >= '" + startdate.ToString("g") + "' AND [Start] < '" + enddate.ToString("g") + "'";
            Items filteredItems = calendarItems.Restrict(filter);

            // Iterate through the filtered items
            foreach (AppointmentItem item in filteredItems)
            {
                if (item != null)
                {
                    result.AppendLine(" ------ Appointment Item ------ ");

                    // You can access the subject, start time, and other properties here
                    result.AppendLine("Subject: " + item.Subject);
                    result.AppendLine("Start Time: " + item.Start.ToString());
                    result.AppendLine("End Time: " + item.End.ToString());
                    result.AppendLine("Location: " + item.Location);
       
                    if (item.RequiredAttendees != null)
                    {
                        result.AppendLine("Required Attendees: " + item.RequiredAttendees);
                    }
                    if (item.OptionalAttendees != null)
                    {
                        result.AppendLine("Optional Attendees: " + item.OptionalAttendees);
                    }
                }
            }
            return result.ToString();
        }

        public string GetSelectedText()
        {
            // Get the current active inspector
            Inspector inspector = this.Application.ActiveInspector();

            // Check if the current item is a MailItem
            if (inspector != null && inspector.CurrentItem is MailItem)
            {
                // Get the selection from the Word editor
                if (inspector.WordEditor is Document wordDocument)
                {
                    Microsoft.Office.Interop.Word.Selection selection = wordDocument.Application.Selection;
                    string selectedText = selection.Text;

                    if (!string.IsNullOrEmpty(selectedText.Trim()))
                    {
                        // Display the selected text
                        return selectedText;
                    }
                    else
                    {
                        MessageBox.Show("No text was selected. Select some text in the email you are composing", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("No active email found.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return null;
        }

        public string GetCurrentUser()
        {
            var application = Globals.ThisAddIn.Application;
            var currentUser = application.Session.CurrentUser;
            string emailAddress = currentUser.AddressEntry.GetExchangeUser()?.PrimarySmtpAddress ?? currentUser.Address;
            return emailAddress;

        }



        public string GetEmails(DateTime startdate, DateTime enddate)
        {

            StringBuilder result = new StringBuilder();

            // Create an Outlook application instance
            var outlookApp = this.Application;

            // Get the namespace (MAPI)
            NameSpace outlookNamespace = outlookApp.GetNamespace("MAPI");

            // Get the default inbox folder
            MAPIFolder inboxFolder = outlookNamespace.GetDefaultFolder(OlDefaultFolders.olFolderInbox);

            // Get the items in the inbox folder
            Items inboxItems = inboxFolder.Items;

            // Sort items by received date
            inboxItems.Sort("[ReceivedTime]", Type.Missing);

            // Create a filter for the specific day
            string filter = "[ReceivedTime] >= '" + startdate.ToString("g") + "' AND [ReceivedTime] < '" + enddate.ToString("g") + "'";

            // Use the Restrict method to filter the emails for the specific date
            Items filteredItems = inboxItems.Restrict(filter);

            // Iterate through the filtered items
            foreach (var item in filteredItems)
            {
                // Check if the item is a MailItem (it could be other types like MeetingItem, ReportItem, etc.)
                if (item is MailItem mailItem)
                {
                    if (IsEmailSensitiveOrConfidential((MailItem)item) == false)
                    {
                        result.AppendLine(" ------ Email Item ------ ");
                        // Access the properties of the email (e.g., subject, received time, sender, etc.)
                        result.AppendLine("Sender: " + mailItem.SenderName);
                        result.AppendLine("To: " + mailItem.To);
                        result.AppendLine("CCs: " + mailItem.CC);
                        result.AppendLine("Subject: " + mailItem.Subject);
                        result.AppendLine("Email: «" + mailItem.Body.Trim() + "»");
                    }

                }
            }
            return result.ToString();
        }

        public List<string> GetTodoLists()
        {
            // Create an Outlook application instance
            var outlookApp = this.Application;

            var ret = new List<string>();

            // Get the namespace (MAPI)
            NameSpace outlookNamespace = outlookApp.GetNamespace("MAPI");

            // Get the default tasks folder
            MAPIFolder tasksFolder = outlookNamespace.GetDefaultFolder(OlDefaultFolders.olFolderTasks);

            // Print the main tasks folder name (this is usually the default To-Do list)
            Console.WriteLine("Main To-Do List: " + tasksFolder.Name);
            ret.Add(tasksFolder.Name);

            // Check if there are any subfolders (other To-Do lists)
            if (tasksFolder.Folders.Count > 0)
            {
                foreach (MAPIFolder folder in tasksFolder.Folders)
                {
                    // Print the name of each subfolder (which represents a To-Do list)
                    Console.WriteLine("To-Do List: " + folder.Name);
                    ret.Add(folder.Name);
                }
            }
            else
            {
                Console.WriteLine("No additional To-Do lists found.");
            }

            return ret;
        }

        public void AddTaskToSpecificTodoList(string taskListName, List<string> taskSubjects)
        {
            // Create an Outlook application instance
            var outlookApp = this.Application;

            // Get the namespace (MAPI)
            NameSpace outlookNamespace = outlookApp.GetNamespace("MAPI");

            // Get the default tasks folder
            MAPIFolder tasksFolder = outlookNamespace.GetDefaultFolder(OlDefaultFolders.olFolderTasks);

            // Find the specific task folder (To-Do list)
            MAPIFolder specificTaskFolder = outlookNamespace.GetDefaultFolder(OlDefaultFolders.olFolderTasks);

            if (specificTaskFolder.Name != taskListName)
            { 
                foreach (MAPIFolder folder in tasksFolder.Folders)
                {
                    var name = folder.Name;
                    if ( name == taskListName)
                    {
                        specificTaskFolder = folder;
                        break;
                    }
                }
            }

            // Create a new task item in the specific folder            
            foreach (var taskSubject in taskSubjects)
            {
                TaskItem task = (TaskItem)specificTaskFolder.Items.Add(OlItemType.olTaskItem);
                task.Subject = taskSubject;
                task.Status = OlTaskStatus.olTaskNotStarted;
                task.Save();
            }

            ShowTasksInOutlook();
        }

        public void ShowTasksInOutlook()
        {
            // Get the Outlook application object
            var outlookApp = Globals.ThisAddIn.Application;

            // Get the active Explorer (the main Outlook window)
            Explorer explorer = outlookApp.ActiveExplorer();

            // Get the default Tasks folder
            Folder tasksFolder = (Folder)outlookApp.Session.GetDefaultFolder(OlDefaultFolders.olFolderTasks);

            // Display the Tasks folder in the active Explorer window
            explorer.SelectFolder(tasksFolder);
            explorer.Display(); // Ensure the Explorer window is shown
        }

        private string _version = null;
        public string GetVersion()
        {
            if (_version == null)
            { 
                _version = "Version: ";
                if (ApplicationDeployment.IsNetworkDeployed)
                {
                    _version = _version + string.Format("{0}", ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(4));                
                }
            }
            return _version;
        }

        public void ListAllMailboxFolders(TreeView tree)
        {
            var outlookApp = this.Application;

            // Initialize the Outlook application and namespace
            var outlookNamespace = outlookApp.GetNamespace("MAPI");

            // Access the default mailbox
            MAPIFolder rootFolder = outlookNamespace.GetDefaultFolder(OlDefaultFolders.olFolderInbox).Parent as MAPIFolder;

            // Clear any existing nodes in the TreeView
            tree.Nodes.Clear();

            // Add the root node and call the recursive function to add subfolders
            TreeNode rootNode = new TreeNode(rootFolder.Name);
            tree.Nodes.Add(rootNode);

            // Populate subfolders under the root node
            PopulateTreeView(rootFolder, rootNode);

            // Expand all nodes to show the full structure
            tree.ExpandAll();
        }

        private void PopulateTreeView(MAPIFolder folder, TreeNode parentNode)
        {
            // Loop through each subfolder in the current folder
            foreach (MAPIFolder subFolder in folder.Folders)
            {
                if (folder.DefaultItemType == OlItemType.olMailItem)
                {
                    // Create a new TreeNode for each subfolder
                    TreeNode childNode = new TreeNode(subFolder.Name);
                    childNode.Tag = subFolder;

                    parentNode.Nodes.Add(childNode);
                    // Recursive call to populate subfolders under the current subfolder
                    PopulateTreeView(subFolder, childNode);

                }
            }
        }

        public string GetFullFolderPathFromName(TreeNode node)
        {
            if (node == null || node.Tag == null)
                return null;

            MAPIFolder folder = node.Tag as MAPIFolder;
            return folder.FullFolderPath;
        }

        public void CreateEmailTo(string recipientEmail, string message)
        {
            try
            {
                var outlookApp = this.Application;
                MailItem mail = (MailItem)outlookApp.CreateItem(OlItemType.olMailItem);

                mail.To = recipientEmail;
                mail.Subject = "Error reporting from the Add in!";
                mail.Body = message;

                mail.Display();

            }
            catch { }
        }

        public bool MailboxFolderExists(string folderPath)
        {
            return GetMailboxFolderByPath(folderPath) != null;
        }

        public Folder GetMailboxFolderByPath(string folderPath)
        {
            try
            {
                // Split the folder path into individual folder names
                //string[] folderNames = folderPath.Split(new[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);

                // Start with the root namespace and default folder (e.g., Inbox)
                var outlookApp = this.Application;

                // Initialize the Outlook application and namespace
                var outlookNamespace = outlookApp.GetNamespace("MAPI");

                // Access the default mailbox

                Folder currentFolder = outlookNamespace.GetDefaultFolder(OlDefaultFolders.olFolderInbox) as Folder;

                // Traverse the folder hierarchy

                Folder folderFound = null;

                foreach (Folder subFolder in currentFolder.Folders)
                {
                    var subFolderName = subFolder.FullFolderPath;
                    if (subFolderName.Equals(folderPath, StringComparison.OrdinalIgnoreCase))
                    {
                        folderFound = subFolder;
                        break;
                    }
                }

                // If we successfully traversed all folders, the path exists
                return folderFound;
            }
            catch
            {
                // Handle exceptions (e.g., invalid folder paths)
                return null;
            }
        }

        public void EnsureCategoryExists(string categoryName, OlCategoryColor color = OlCategoryColor.olCategoryColorBlue)
        {
            var application = Globals.ThisAddIn.Application;
            var categories = application.Session.Categories;

            if (categories[categoryName] == null)
            {
                categories.Add(categoryName, color);
            }
        }

        public List<OlCategoryColor> GetAllColors()
        {
            var ret = new List<OlCategoryColor>();
            foreach (OlCategoryColor color in Enum.GetValues(typeof(OlCategoryColor)))
            {
                ret.Add(color);
            }
            return ret;
        }

        public void AssignCategoryToMailItem(string categoryName)
        {
            var mailItem = GetCurrentMailItem();

            if (mailItem == null)
                throw new ArgumentNullException(nameof(mailItem));

            // Assign the category
            if (!string.IsNullOrEmpty(categoryName))
            {
                mailItem.Categories = categoryName;

                // Save the changes
                mailItem.Save();
            }
        }

        public void MoveCurrentMailItemToFolder(string folderPath)
        {
            try
            {
                // Get the current Outlook application instance
                var application = Globals.ThisAddIn.Application;

                // Get the namespace (MAPI)
                var outlookNamespace = application.GetNamespace("MAPI");

                // Get the default Inbox folder
                //Outlook.MAPIFolder inboxFolder = outlookNamespace.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);

                if (folderPath != null)
                {
                    var addIn = Globals.ThisAddIn;
                    var mailItem = addIn.GetCurrentMailItem();

                    var folder = addIn.GetMailboxFolderByPath(folderPath);
                    if (folder == null)
                    {
                        MessageBox.Show("Something went wrong, could not find the folder", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    // Move the email to the target folder
                    mailItem.Move(folder);
                    MessageBox.Show("Email moved successfully.", "Email moved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Something went wrong, could not find the folder", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        public string GetAllFilteredEmails()
        {
            var result = string.Empty;

            var application = Globals.ThisAddIn.Application;

            var explorer = application.ActiveExplorer();

            var regEx = new Regex(@"<(.+).*>.*<\/\1>");

            if (explorer != null)
            {
                // Get the current view's table (which respects the search/filter)
                Microsoft.Office.Interop.Outlook.Table table = explorer.CurrentView.GetTable();

                // Add columns you want to retrieve (e.g., Subject, Sender, ReceivedTime)
                table.Columns.Add("EntryID");
                table.Columns.Add("Subject");
                table.Columns.Add("SenderName");
                table.Columns.Add("ReceivedTime");


                // Iterate through the filtered items
                int i = 0;
                while (!table.EndOfTable)
                {
                    Microsoft.Office.Interop.Outlook.Row row = table.GetNextRow();

                    // Retrieve the email properties
                    string subject = row["Subject"] as string;
                    string sender = row["SenderName"] as string;
                    DateTime receivedTime = (DateTime)row["ReceivedTime"];
                    result += $"{i} Subject:{subject},Sender:{sender},Received:{receivedTime}";


                    string entryId = row["EntryID"] as string;
                    MailItem mailItem = application.Session.GetItemFromID(entryId) as MailItem;
                    if (mailItem != null)
                    {
                        var body = mailItem.Body;
                        //var trimmed = Regex.Replace(body, @"(^\p{Zs}*\r\n){2,}", "\r\n", RegexOptions.Multiline);
                        var trimmed = body.Replace("\n", "").Replace("\r","").Trim();
                        result += $", Body «{trimmed}»";
                    }
                    result += "\r\n";

                    // Output or process the email details
                    ++i;
                    if (i > 20)
                        break;
                }
            }

            //MessageBox.Show(result);

            return result;

        }

        public List<EmailDocument> GetAllFilteredEmailsList()
        {
            var result = new List<EmailDocument>();

            var application = Globals.ThisAddIn.Application;

            var explorer = application.ActiveExplorer();

            var regEx = new Regex(@"<(.+).*>.*<\/\1>");

            if (explorer != null)
            {
                // Get the current view's table (which respects the search/filter)
                Microsoft.Office.Interop.Outlook.Table table = explorer.CurrentView.GetTable();

                // Add columns you want to retrieve (e.g., Subject, Sender, ReceivedTime)
                table.Columns.Add("EntryID");
                table.Columns.Add("Subject");
                table.Columns.Add("SenderName");
                table.Columns.Add("ReceivedTime");


                // Iterate through the filtered items
                int i = 0;
                while (!table.EndOfTable)
                {
                    Microsoft.Office.Interop.Outlook.Row row = table.GetNextRow();

                    // Retrieve the email properties
                    string subject = row["Subject"] as string;
                    string from = row["SenderName"] as string;
                    DateTime receivedTime = (DateTime)row["ReceivedTime"];
                    string entryId = row["EntryID"] as string;


                    var email = new EmailDocument();
                    email.Subject = subject;
                    email.From = from;
                    email.Date = receivedTime;
                    email.Id = entryId;
                    email.Cc = from;
                    email.UserId ="tiago";
                    email.Body = string.Empty;
                    email.To = string.Empty;

                    
                    MailItem mailItem = application.Session.GetItemFromID(entryId) as MailItem;
                    if (mailItem != null)
                    {
                        email.Body = mailItem.Body;
                        email.Subject = mailItem.Subject;
                        email.Cc = mailItem.CC;
                        email.To = mailItem.To;

                    }

                    result.Add(email);
                    
                    // Output or process the email details
                    ++i;
                    if (i > 199)
                        break;
                }
            }

            //MessageBox.Show(result);

            return result;

        }

        private string GetSenderEmail(MailItem mail)
        {
            try
            {
                if (mail.SenderEmailType == "EX")  // Exchange format
                {
                    AddressEntry sender = mail.Sender;
                    if (sender != null)
                    {
                        ExchangeUser exchUser = sender.GetExchangeUser();
                        if (exchUser != null)
                        {
                            return exchUser.PrimarySmtpAddress;
                        }
                    }
                }
                return mail.SenderEmailAddress;  // Standard SMTP format
            }
            catch (System.Exception)
            {
                //LOG IT
                return String.Empty;
            }
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
