namespace ECDC.OutlookExtender
{
    partial class Ribbon_MailCompose : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Ribbon_MailCompose()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ribbon_MailCompose));
            Microsoft.Office.Tools.Ribbon.RibbonDialogLauncher ribbonDialogLauncherImpl1 = this.Factory.CreateRibbonDialogLauncher();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl1 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl2 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl3 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl4 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl5 = this.Factory.CreateRibbonDropDownItem();
            this.Tab_MailCompose = this.Factory.CreateRibbonTab();
            this.Group_Compose = this.Factory.CreateRibbonGroup();
            this.Button_MakeNicer = this.Factory.CreateRibbonButton();
            this.Button_Improve = this.Factory.CreateRibbonButton();
            this.Button_Correct = this.Factory.CreateRibbonButton();
            this.separator1 = this.Factory.CreateRibbonSeparator();
            this.Menu_Translate = this.Factory.CreateRibbonMenu();
            this.Button_PT = this.Factory.CreateRibbonButton();
            this.Button_RO = this.Factory.CreateRibbonButton();
            this.Button_GR = this.Factory.CreateRibbonButton();
            this.Button_EN = this.Factory.CreateRibbonButton();
            this.Button_PL = this.Factory.CreateRibbonButton();
            this.Button_GE = this.Factory.CreateRibbonButton();
            this.Button_FR = this.Factory.CreateRibbonButton();
            this.Button_NL = this.Factory.CreateRibbonButton();
            this.Group_Promp = this.Factory.CreateRibbonGroup();
            this.Button_Prompt = this.Factory.CreateRibbonButton();
            this.Button_Chat = this.Factory.CreateRibbonButton();
            this.Group_Settings = this.Factory.CreateRibbonGroup();
            this.DropDown_Temperature = this.Factory.CreateRibbonDropDown();
            this.DropDown_Models = this.Factory.CreateRibbonDropDown();
            this.Label_Version = this.Factory.CreateRibbonLabel();
            this.Tab_MailCompose.SuspendLayout();
            this.Group_Compose.SuspendLayout();
            this.Group_Promp.SuspendLayout();
            this.Group_Settings.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tab_MailCompose
            // 
            this.Tab_MailCompose.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.Tab_MailCompose.Groups.Add(this.Group_Compose);
            this.Tab_MailCompose.Groups.Add(this.Group_Promp);
            this.Tab_MailCompose.Groups.Add(this.Group_Settings);
            this.Tab_MailCompose.Label = "ECDC AI";
            this.Tab_MailCompose.Name = "Tab_MailCompose";
            // 
            // Group_Compose
            // 
            this.Group_Compose.Items.Add(this.Button_MakeNicer);
            this.Group_Compose.Items.Add(this.Button_Improve);
            this.Group_Compose.Items.Add(this.Button_Correct);
            this.Group_Compose.Items.Add(this.separator1);
            this.Group_Compose.Items.Add(this.Menu_Translate);
            this.Group_Compose.Label = "Selected Text";
            this.Group_Compose.Name = "Group_Compose";
            // 
            // Button_MakeNicer
            // 
            this.Button_MakeNicer.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.Button_MakeNicer.Image = ((System.Drawing.Image)(resources.GetObject("Button_MakeNicer.Image")));
            this.Button_MakeNicer.Label = "Make nicer";
            this.Button_MakeNicer.Name = "Button_MakeNicer";
            this.Button_MakeNicer.ShowImage = true;
            this.Button_MakeNicer.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Button_MakeNicer_Click);
            // 
            // Button_Improve
            // 
            this.Button_Improve.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.Button_Improve.Image = ((System.Drawing.Image)(resources.GetObject("Button_Improve.Image")));
            this.Button_Improve.Label = "Improve";
            this.Button_Improve.Name = "Button_Improve";
            this.Button_Improve.ShowImage = true;
            this.Button_Improve.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Button_Improve_Click);
            // 
            // Button_Correct
            // 
            this.Button_Correct.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.Button_Correct.Image = ((System.Drawing.Image)(resources.GetObject("Button_Correct.Image")));
            this.Button_Correct.Label = "Correct";
            this.Button_Correct.Name = "Button_Correct";
            this.Button_Correct.ShowImage = true;
            this.Button_Correct.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Button_Correct_Click);
            // 
            // separator1
            // 
            this.separator1.Name = "separator1";
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
            // Group_Promp
            // 
            this.Group_Promp.Items.Add(this.Button_Prompt);
            this.Group_Promp.Items.Add(this.Button_Chat);
            this.Group_Promp.Label = "Compose helper";
            this.Group_Promp.Name = "Group_Promp";
            // 
            // Button_Prompt
            // 
            this.Button_Prompt.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.Button_Prompt.Image = ((System.Drawing.Image)(resources.GetObject("Button_Prompt.Image")));
            this.Button_Prompt.Label = "Prompt";
            this.Button_Prompt.Name = "Button_Prompt";
            this.Button_Prompt.ShowImage = true;
            this.Button_Prompt.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Button_Prompt_Click);
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
            // Ribbon_MailCompose
            // 
            this.Name = "Ribbon_MailCompose";
            this.RibbonType = "Microsoft.Outlook.Mail.Compose";
            this.Tabs.Add(this.Tab_MailCompose);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon_MailWrite_Load);
            this.Tab_MailCompose.ResumeLayout(false);
            this.Tab_MailCompose.PerformLayout();
            this.Group_Compose.ResumeLayout(false);
            this.Group_Compose.PerformLayout();
            this.Group_Promp.ResumeLayout(false);
            this.Group_Promp.PerformLayout();
            this.Group_Settings.ResumeLayout(false);
            this.Group_Settings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab Tab_MailCompose;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup Group_Compose;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Button_MakeNicer;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Button_Improve;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Button_Correct;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup Group_Settings;
        internal Microsoft.Office.Tools.Ribbon.RibbonDropDown DropDown_Temperature;
        internal Microsoft.Office.Tools.Ribbon.RibbonDropDown DropDown_Models;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup Group_Promp;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Button_Prompt;
        internal Microsoft.Office.Tools.Ribbon.RibbonLabel Label_Version;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator1;
        internal Microsoft.Office.Tools.Ribbon.RibbonMenu Menu_Translate;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Button_PT;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Button_RO;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Button_GR;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Button_EN;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Button_PL;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Button_Chat;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Button_GE;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Button_FR;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Button_NL;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon_MailCompose Ribbon_MailWrite
        {
            get { return this.GetRibbon<Ribbon_MailCompose>(); }
        }
    }
}
