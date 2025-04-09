namespace ECDC.OutlookExtender
{
    partial class Ribbon_MailRead : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Ribbon_MailRead()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Microsoft.Office.Tools.Ribbon.RibbonDialogLauncher ribbonDialogLauncherImpl1 = this.Factory.CreateRibbonDialogLauncher();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl1 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl2 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl3 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl4 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl5 = this.Factory.CreateRibbonDropDownItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ribbon_MailRead));
            this.Tab_MailRead = this.Factory.CreateRibbonTab();
            this.Group_Reply = this.Factory.CreateRibbonGroup();
            this.separator1 = this.Factory.CreateRibbonSeparator();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.box1 = this.Factory.CreateRibbonBox();
            this.Group_Classification = this.Factory.CreateRibbonGroup();
            this.separator2 = this.Factory.CreateRibbonSeparator();
            this.Group_Settings = this.Factory.CreateRibbonGroup();
            this.DropDown_Temperature = this.Factory.CreateRibbonDropDown();
            this.DropDown_Models = this.Factory.CreateRibbonDropDown();
            this.Label_Version = this.Factory.CreateRibbonLabel();
            this.Button_Summarize = this.Factory.CreateRibbonButton();
            this.Button_SummarizeTimeline = this.Factory.CreateRibbonButton();
            this.Button_AssistedReply = this.Factory.CreateRibbonButton();
            this.Button_Respond = this.Factory.CreateRibbonButton();
            this.Button_Actions = this.Factory.CreateRibbonButton();
            this.Button_IdentifyTodos = this.Factory.CreateRibbonButton();
            this.Button_Prompt = this.Factory.CreateRibbonButton();
            this.Menu_Translate = this.Factory.CreateRibbonMenu();
            this.Button_PT = this.Factory.CreateRibbonButton();
            this.Button_RO = this.Factory.CreateRibbonButton();
            this.Button_GR = this.Factory.CreateRibbonButton();
            this.Button_EN = this.Factory.CreateRibbonButton();
            this.Button_PL = this.Factory.CreateRibbonButton();
            this.Button_GE = this.Factory.CreateRibbonButton();
            this.Button_FR = this.Factory.CreateRibbonButton();
            this.Button_NL = this.Factory.CreateRibbonButton();
            this.Button_Chat = this.Factory.CreateRibbonButton();
            this.Button_ClassificationSettings = this.Factory.CreateRibbonButton();
            this.Button_Classify = this.Factory.CreateRibbonButton();
            this.Button_AutoClassify = this.Factory.CreateRibbonButton();
            this.ButtonDetectAI = this.Factory.CreateRibbonButton();
            this.Tab_MailRead.SuspendLayout();
            this.Group_Reply.SuspendLayout();
            this.group1.SuspendLayout();
            this.box1.SuspendLayout();
            this.Group_Classification.SuspendLayout();
            this.Group_Settings.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tab_MailRead
            // 
            this.Tab_MailRead.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.Tab_MailRead.Groups.Add(this.Group_Reply);
            this.Tab_MailRead.Groups.Add(this.group1);
            this.Tab_MailRead.Groups.Add(this.Group_Classification);
            this.Tab_MailRead.Groups.Add(this.Group_Settings);
            this.Tab_MailRead.Label = "ECDC AI";
            this.Tab_MailRead.Name = "Tab_MailRead";
            // 
            // Group_Reply
            // 
            this.Group_Reply.Items.Add(this.Button_Summarize);
            this.Group_Reply.Items.Add(this.Button_SummarizeTimeline);
            this.Group_Reply.Items.Add(this.separator1);
            this.Group_Reply.Items.Add(this.Button_AssistedReply);
            this.Group_Reply.Items.Add(this.Button_Respond);
            this.Group_Reply.Label = "Reply Assistant";
            this.Group_Reply.Name = "Group_Reply";
            // 
            // separator1
            // 
            this.separator1.Name = "separator1";
            // 
            // group1
            // 
            this.group1.Items.Add(this.box1);
            this.group1.Items.Add(this.Button_IdentifyTodos);
            this.group1.Items.Add(this.Button_Prompt);
            this.group1.Items.Add(this.Menu_Translate);
            this.group1.Items.Add(this.Button_Chat);
            this.group1.Label = "Email Analisys";
            this.group1.Name = "group1";
            // 
            // box1
            // 
            this.box1.Items.Add(this.Button_Actions);
            this.box1.Name = "box1";
            // 
            // Group_Classification
            // 
            this.Group_Classification.Items.Add(this.Button_ClassificationSettings);
            this.Group_Classification.Items.Add(this.Button_Classify);
            this.Group_Classification.Items.Add(this.Button_AutoClassify);
            this.Group_Classification.Items.Add(this.separator2);
            this.Group_Classification.Items.Add(this.ButtonDetectAI);
            this.Group_Classification.Label = "Email Classification";
            this.Group_Classification.Name = "Group_Classification";
            // 
            // separator2
            // 
            this.separator2.Name = "separator2";
            // 
            // Group_Settings
            // 
            this.Group_Settings.DialogLauncher = ribbonDialogLauncherImpl1;
            this.Group_Settings.Items.Add(this.DropDown_Temperature);
            this.Group_Settings.Items.Add(this.DropDown_Models);
            this.Group_Settings.Items.Add(this.Label_Version);
            this.Group_Settings.Label = "Settings";
            this.Group_Settings.Name = "Group_Settings";
            // 
            // DropDown_Temperature
            // 
            ribbonDropDownItemImpl1.Label = "Frozen";
            ribbonDropDownItemImpl1.Tag = "0.0";
            ribbonDropDownItemImpl2.Label = "Cold";
            ribbonDropDownItemImpl2.Tag = "0.2";
            ribbonDropDownItemImpl3.Label = "Mild";
            ribbonDropDownItemImpl3.Tag = "0.6";
            ribbonDropDownItemImpl4.Label = "Hot";
            ribbonDropDownItemImpl4.Tag = "0.8";
            ribbonDropDownItemImpl5.Label = "Scorching";
            ribbonDropDownItemImpl5.Tag = "1.0";
            this.DropDown_Temperature.Items.Add(ribbonDropDownItemImpl1);
            this.DropDown_Temperature.Items.Add(ribbonDropDownItemImpl2);
            this.DropDown_Temperature.Items.Add(ribbonDropDownItemImpl3);
            this.DropDown_Temperature.Items.Add(ribbonDropDownItemImpl4);
            this.DropDown_Temperature.Items.Add(ribbonDropDownItemImpl5);
            this.DropDown_Temperature.Label = "Temperature";
            this.DropDown_Temperature.Name = "DropDown_Temperature";
            // 
            // DropDown_Models
            // 
            this.DropDown_Models.Label = "Models";
            this.DropDown_Models.Name = "DropDown_Models";
            // 
            // Label_Version
            // 
            this.Label_Version.Label = "Label_Version";
            this.Label_Version.Name = "Label_Version";
            // 
            // Button_Summarize
            // 
            this.Button_Summarize.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.Button_Summarize.Image = ((System.Drawing.Image)(resources.GetObject("Button_Summarize.Image")));
            this.Button_Summarize.Label = "Summarize email";
            this.Button_Summarize.Name = "Button_Summarize";
            this.Button_Summarize.ShowImage = true;
            this.Button_Summarize.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Button_Summarize_Click);
            // 
            // Button_SummarizeTimeline
            // 
            this.Button_SummarizeTimeline.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.Button_SummarizeTimeline.Image = ((System.Drawing.Image)(resources.GetObject("Button_SummarizeTimeline.Image")));
            this.Button_SummarizeTimeline.Label = "Summarize email w/timeline";
            this.Button_SummarizeTimeline.Name = "Button_SummarizeTimeline";
            this.Button_SummarizeTimeline.ShowImage = true;
            this.Button_SummarizeTimeline.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Button_SummarizeTimeline_Click);
            // 
            // Button_AssistedReply
            // 
            this.Button_AssistedReply.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.Button_AssistedReply.Image = ((System.Drawing.Image)(resources.GetObject("Button_AssistedReply.Image")));
            this.Button_AssistedReply.Label = "Assisted Reply";
            this.Button_AssistedReply.Name = "Button_AssistedReply";
            this.Button_AssistedReply.ShowImage = true;
            this.Button_AssistedReply.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Button_AssistedReply_Click);
            // 
            // Button_Respond
            // 
            this.Button_Respond.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.Button_Respond.Image = ((System.Drawing.Image)(resources.GetObject("Button_Respond.Image")));
            this.Button_Respond.Label = "Automatic Reply";
            this.Button_Respond.Name = "Button_Respond";
            this.Button_Respond.ShowImage = true;
            this.Button_Respond.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Button_AutomaticRepy_Click);
            // 
            // Button_Actions
            // 
            this.Button_Actions.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.Button_Actions.Image = ((System.Drawing.Image)(resources.GetObject("Button_Actions.Image")));
            this.Button_Actions.Label = "Identify Actions";
            this.Button_Actions.Name = "Button_Actions";
            this.Button_Actions.ShowImage = true;
            this.Button_Actions.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Button_Actions_Click);
            // 
            // Button_IdentifyTodos
            // 
            this.Button_IdentifyTodos.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.Button_IdentifyTodos.Image = ((System.Drawing.Image)(resources.GetObject("Button_IdentifyTodos.Image")));
            this.Button_IdentifyTodos.Label = "Identify My To-Do";
            this.Button_IdentifyTodos.Name = "Button_IdentifyTodos";
            this.Button_IdentifyTodos.ShowImage = true;
            this.Button_IdentifyTodos.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Button_IdentifyTodos_Click);
            // 
            // Button_Prompt
            // 
            this.Button_Prompt.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.Button_Prompt.Image = ((System.Drawing.Image)(resources.GetObject("Button_Prompt.Image")));
            this.Button_Prompt.Label = "Query Email";
            this.Button_Prompt.Name = "Button_Prompt";
            this.Button_Prompt.ShowImage = true;
            this.Button_Prompt.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Button_Prompt_Click);
            // 
            // Menu_Translate
            // 
            this.Menu_Translate.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.Menu_Translate.Image = ((System.Drawing.Image)(resources.GetObject("Menu_Translate.Image")));
            this.Menu_Translate.Items.Add(this.Button_PT);
            this.Menu_Translate.Items.Add(this.Button_RO);
            this.Menu_Translate.Items.Add(this.Button_GR);
            this.Menu_Translate.Items.Add(this.Button_EN);
            this.Menu_Translate.Items.Add(this.Button_PL);
            this.Menu_Translate.Items.Add(this.Button_GE);
            this.Menu_Translate.Items.Add(this.Button_FR);
            this.Menu_Translate.Items.Add(this.Button_NL);
            this.Menu_Translate.Label = "Translate";
            this.Menu_Translate.Name = "Menu_Translate";
            this.Menu_Translate.ShowImage = true;
            // 
            // Button_PT
            // 
            this.Button_PT.Label = "Portuguese";
            this.Button_PT.Name = "Button_PT";
            this.Button_PT.ShowImage = true;
            // 
            // Button_RO
            // 
            this.Button_RO.Label = "Romanian";
            this.Button_RO.Name = "Button_RO";
            this.Button_RO.ShowImage = true;
            // 
            // Button_GR
            // 
            this.Button_GR.Label = "Greek";
            this.Button_GR.Name = "Button_GR";
            this.Button_GR.ShowImage = true;
            // 
            // Button_EN
            // 
            this.Button_EN.Label = "English";
            this.Button_EN.Name = "Button_EN";
            this.Button_EN.ShowImage = true;
            // 
            // Button_PL
            // 
            this.Button_PL.Label = "Polish";
            this.Button_PL.Name = "Button_PL";
            this.Button_PL.ShowImage = true;
            // 
            // Button_GE
            // 
            this.Button_GE.Label = "German";
            this.Button_GE.Name = "Button_GE";
            this.Button_GE.ShowImage = true;
            // 
            // Button_FR
            // 
            this.Button_FR.Label = "French";
            this.Button_FR.Name = "Button_FR";
            this.Button_FR.ShowImage = true;
            // 
            // Button_NL
            // 
            this.Button_NL.Label = "Dutch";
            this.Button_NL.Name = "Button_NL";
            this.Button_NL.ShowImage = true;
            // 
            // Button_Chat
            // 
            this.Button_Chat.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.Button_Chat.Image = ((System.Drawing.Image)(resources.GetObject("Button_Chat.Image")));
            this.Button_Chat.Label = "Chat";
            this.Button_Chat.Name = "Button_Chat";
            this.Button_Chat.ShowImage = true;
            this.Button_Chat.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Button_Chat_Click);
            // 
            // Button_ClassificationSettings
            // 
            this.Button_ClassificationSettings.Image = ((System.Drawing.Image)(resources.GetObject("Button_ClassificationSettings.Image")));
            this.Button_ClassificationSettings.Label = "Classification Settings";
            this.Button_ClassificationSettings.Name = "Button_ClassificationSettings";
            this.Button_ClassificationSettings.ShowImage = true;
            this.Button_ClassificationSettings.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Button_ClassificationSettings_Click);
            // 
            // Button_Classify
            // 
            this.Button_Classify.Image = ((System.Drawing.Image)(resources.GetObject("Button_Classify.Image")));
            this.Button_Classify.Label = "Settings Based Classification";
            this.Button_Classify.Name = "Button_Classify";
            this.Button_Classify.ShowImage = true;
            this.Button_Classify.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Button_Classify_Click);
            // 
            // Button_AutoClassify
            // 
            this.Button_AutoClassify.Image = ((System.Drawing.Image)(resources.GetObject("Button_AutoClassify.Image")));
            this.Button_AutoClassify.Label = "AI Auto Classification";
            this.Button_AutoClassify.Name = "Button_AutoClassify";
            this.Button_AutoClassify.ShowImage = true;
            this.Button_AutoClassify.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Button_AutoClassify_Click);
            // 
            // ButtonDetectAI
            // 
            this.ButtonDetectAI.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.ButtonDetectAI.Image = ((System.Drawing.Image)(resources.GetObject("ButtonDetectAI.Image")));
            this.ButtonDetectAI.Label = "Detect AI";
            this.ButtonDetectAI.Name = "ButtonDetectAI";
            this.ButtonDetectAI.ShowImage = true;
            this.ButtonDetectAI.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ButtonDetectAI_Click);
            // 
            // Ribbon_MailRead
            // 
            this.Name = "Ribbon_MailRead";
            this.RibbonType = "Microsoft.Outlook.Mail.Read";
            this.Tabs.Add(this.Tab_MailRead);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon_ECDC_Load);
            this.Tab_MailRead.ResumeLayout(false);
            this.Tab_MailRead.PerformLayout();
            this.Group_Reply.ResumeLayout(false);
            this.Group_Reply.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.box1.ResumeLayout(false);
            this.box1.PerformLayout();
            this.Group_Classification.ResumeLayout(false);
            this.Group_Classification.PerformLayout();
            this.Group_Settings.ResumeLayout(false);
            this.Group_Settings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab Tab_MailRead;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup Group_Reply;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Button_Summarize;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Button_SummarizeTimeline;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Button_Respond;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup Group_Settings;
        internal Microsoft.Office.Tools.Ribbon.RibbonDropDown DropDown_Temperature;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonBox box1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Button_Actions;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Button_Classify;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Button_Prompt;
        internal Microsoft.Office.Tools.Ribbon.RibbonDropDown DropDown_Models;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Button_AssistedReply;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Button_IdentifyTodos;
        internal Microsoft.Office.Tools.Ribbon.RibbonLabel Label_Version;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup Group_Classification;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Button_ClassificationSettings;
        internal Microsoft.Office.Tools.Ribbon.RibbonMenu Menu_Translate;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Button_PT;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Button_RO;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Button_GR;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Button_EN;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Button_PL;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Button_AutoClassify;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton ButtonDetectAI;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Button_Chat;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Button_GE;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Button_FR;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Button_NL;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon_MailRead Ribbon1
        {
            get { return this.GetRibbon<Ribbon_MailRead>(); }
        }
    }
}
