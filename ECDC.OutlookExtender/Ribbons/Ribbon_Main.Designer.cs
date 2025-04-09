namespace ECDC.OutlookExtender
{
    partial class Ribbon_Main : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Ribbon_Main()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ribbon_Main));
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl1 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl2 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl3 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl4 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl5 = this.Factory.CreateRibbonDropDownItem();
            this.Tab_Main = this.Factory.CreateRibbonTab();
            this.Group_Advanced = this.Factory.CreateRibbonGroup();
            this.Button_DailySummary = this.Factory.CreateRibbonButton();
            this.Button_Chat = this.Factory.CreateRibbonButton();
            this.Group_Classification = this.Factory.CreateRibbonGroup();
            this.Button_ClassificationSettings = this.Factory.CreateRibbonButton();
            this.Button_Classify = this.Factory.CreateRibbonButton();
            this.Group_Settings = this.Factory.CreateRibbonGroup();
            this.DropDown_Temperature = this.Factory.CreateRibbonDropDown();
            this.DropDown_Models = this.Factory.CreateRibbonDropDown();
            this.Label_Version = this.Factory.CreateRibbonLabel();
            this.Tab_Main.SuspendLayout();
            this.Group_Advanced.SuspendLayout();
            this.Group_Classification.SuspendLayout();
            this.Group_Settings.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tab_Main
            // 
            this.Tab_Main.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.Tab_Main.Groups.Add(this.Group_Advanced);
            this.Tab_Main.Groups.Add(this.Group_Classification);
            this.Tab_Main.Groups.Add(this.Group_Settings);
            this.Tab_Main.Label = "ECDC AI";
            this.Tab_Main.Name = "Tab_Main";
            // 
            // Group_Advanced
            // 
            this.Group_Advanced.Items.Add(this.Button_DailySummary);
            this.Group_Advanced.Items.Add(this.Button_Chat);
            this.Group_Advanced.Label = "AI Tools";
            this.Group_Advanced.Name = "Group_Advanced";
            // 
            // Button_DailySummary
            // 
            this.Button_DailySummary.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.Button_DailySummary.Image = ((System.Drawing.Image)(resources.GetObject("Button_DailySummary.Image")));
            this.Button_DailySummary.Label = "Summarize My Day";
            this.Button_DailySummary.Name = "Button_DailySummary";
            this.Button_DailySummary.ShowImage = true;
            this.Button_DailySummary.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Button_DailySummary_Click);
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
            // Group_Classification
            // 
            this.Group_Classification.Items.Add(this.Button_ClassificationSettings);
            this.Group_Classification.Items.Add(this.Button_Classify);
            this.Group_Classification.Label = "Email Classification";
            this.Group_Classification.Name = "Group_Classification";
            // 
            // Button_ClassificationSettings
            // 
            this.Button_ClassificationSettings.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.Button_ClassificationSettings.Image = ((System.Drawing.Image)(resources.GetObject("Button_ClassificationSettings.Image")));
            this.Button_ClassificationSettings.Label = "Classification Settings";
            this.Button_ClassificationSettings.Name = "Button_ClassificationSettings";
            this.Button_ClassificationSettings.ShowImage = true;
            this.Button_ClassificationSettings.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Button_ClassificationSettings_Click);
            // 
            // Button_Classify
            // 
            this.Button_Classify.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.Button_Classify.Image = ((System.Drawing.Image)(resources.GetObject("Button_Classify.Image")));
            this.Button_Classify.Label = "Email Classification";
            this.Button_Classify.Name = "Button_Classify";
            this.Button_Classify.ShowImage = true;
            this.Button_Classify.Visible = false;
            // 
            // Group_Settings
            // 
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
            // Ribbon_Main
            // 
            this.Name = "Ribbon_Main";
            this.RibbonType = "Microsoft.Outlook.Explorer";
            this.Tabs.Add(this.Tab_Main);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon_Main_Load);
            this.Tab_Main.ResumeLayout(false);
            this.Tab_Main.PerformLayout();
            this.Group_Advanced.ResumeLayout(false);
            this.Group_Advanced.PerformLayout();
            this.Group_Classification.ResumeLayout(false);
            this.Group_Classification.PerformLayout();
            this.Group_Settings.ResumeLayout(false);
            this.Group_Settings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab Tab_Main;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup Group_Advanced;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Button_DailySummary;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup Group_Settings;
        internal Microsoft.Office.Tools.Ribbon.RibbonLabel Label_Version;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup Group_Classification;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Button_ClassificationSettings;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Button_Classify;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Button_Chat;
        internal Microsoft.Office.Tools.Ribbon.RibbonDropDown DropDown_Temperature;
        internal Microsoft.Office.Tools.Ribbon.RibbonDropDown DropDown_Models;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon_Main Ribbon_Main
        {
            get { return this.GetRibbon<Ribbon_Main>(); }
        }
    }
}
