namespace ECDC.OutlookExtender.Forms
{
    partial class ClassificationSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TreeView_Folders = new System.Windows.Forms.TreeView();
            this.GroupBox_Prompt = new System.Windows.Forms.GroupBox();
            this.Label_Path = new System.Windows.Forms.Label();
            this.TextBox_Description = new System.Windows.Forms.TextBox();
            this.Button_Save = new System.Windows.Forms.Button();
            this.GroupBox_Prompt.SuspendLayout();
            this.SuspendLayout();
            // 
            // TreeView_Folders
            // 
            this.TreeView_Folders.Location = new System.Drawing.Point(13, 14);
            this.TreeView_Folders.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TreeView_Folders.Name = "TreeView_Folders";
            this.TreeView_Folders.Size = new System.Drawing.Size(238, 372);
            this.TreeView_Folders.TabIndex = 0;
            this.TreeView_Folders.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView_Folders_AfterSelect);
            // 
            // GroupBox_Prompt
            // 
            this.GroupBox_Prompt.Controls.Add(this.Label_Path);
            this.GroupBox_Prompt.Controls.Add(this.TextBox_Description);
            this.GroupBox_Prompt.Location = new System.Drawing.Point(264, 18);
            this.GroupBox_Prompt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GroupBox_Prompt.Name = "GroupBox_Prompt";
            this.GroupBox_Prompt.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GroupBox_Prompt.Size = new System.Drawing.Size(570, 329);
            this.GroupBox_Prompt.TabIndex = 1;
            this.GroupBox_Prompt.TabStop = false;
            this.GroupBox_Prompt.Text = "Provide the prompt for the LLM to classify this folder";
            // 
            // Label_Path
            // 
            this.Label_Path.AutoSize = true;
            this.Label_Path.Location = new System.Drawing.Point(8, 32);
            this.Label_Path.Name = "Label_Path";
            this.Label_Path.Size = new System.Drawing.Size(51, 20);
            this.Label_Path.TabIndex = 1;
            this.Label_Path.Text = "label1";
            // 
            // TextBox_Description
            // 
            this.TextBox_Description.Location = new System.Drawing.Point(12, 57);
            this.TextBox_Description.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TextBox_Description.Multiline = true;
            this.TextBox_Description.Name = "TextBox_Description";
            this.TextBox_Description.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextBox_Description.Size = new System.Drawing.Size(548, 261);
            this.TextBox_Description.TabIndex = 0;
            // 
            // Button_Save
            // 
            this.Button_Save.Location = new System.Drawing.Point(712, 357);
            this.Button_Save.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Button_Save.Name = "Button_Save";
            this.Button_Save.Size = new System.Drawing.Size(112, 35);
            this.Button_Save.TabIndex = 2;
            this.Button_Save.Text = "Save";
            this.Button_Save.UseVisualStyleBackColor = true;
            this.Button_Save.Click += new System.EventHandler(this.Button_Save_Click);
            // 
            // ClassificationSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 403);
            this.Controls.Add(this.Button_Save);
            this.Controls.Add(this.GroupBox_Prompt);
            this.Controls.Add(this.TreeView_Folders);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClassificationSettings";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Folder metadata form";
            this.GroupBox_Prompt.ResumeLayout(false);
            this.GroupBox_Prompt.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox GroupBox_Prompt;
        private System.Windows.Forms.TextBox TextBox_Description;
        private System.Windows.Forms.Button Button_Save;
        public System.Windows.Forms.TreeView TreeView_Folders;
        private System.Windows.Forms.Label Label_Path;
    }
}