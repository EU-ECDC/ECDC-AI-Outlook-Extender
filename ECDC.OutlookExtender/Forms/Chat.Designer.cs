namespace ECDC.OutlookExtender.Forms
{
    partial class Chat
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.WebBrowser_Conversation = new System.Windows.Forms.WebBrowser();
            this.Button_Chat = new System.Windows.Forms.Button();
            this.TextBox_Input = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.TextBox_Context = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(831, 470);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.WebBrowser_Conversation);
            this.tabPage1.Controls.Add(this.Button_Chat);
            this.tabPage1.Controls.Add(this.TextBox_Input);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(823, 437);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Chat";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // WebBrowser_Conversation
            // 
            this.WebBrowser_Conversation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WebBrowser_Conversation.Location = new System.Drawing.Point(8, 6);
            this.WebBrowser_Conversation.MinimumSize = new System.Drawing.Size(20, 20);
            this.WebBrowser_Conversation.Name = "WebBrowser_Conversation";
            this.WebBrowser_Conversation.Size = new System.Drawing.Size(809, 386);
            this.WebBrowser_Conversation.TabIndex = 6;
            // 
            // Button_Chat
            // 
            this.Button_Chat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Chat.Location = new System.Drawing.Point(708, 397);
            this.Button_Chat.Name = "Button_Chat";
            this.Button_Chat.Size = new System.Drawing.Size(107, 34);
            this.Button_Chat.TabIndex = 5;
            this.Button_Chat.Text = "Send";
            this.Button_Chat.UseVisualStyleBackColor = true;
            this.Button_Chat.Click += new System.EventHandler(this.Button_Chat_Click);
            // 
            // TextBox_Input
            // 
            this.TextBox_Input.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Input.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox_Input.Location = new System.Drawing.Point(8, 397);
            this.TextBox_Input.Name = "TextBox_Input";
            this.TextBox_Input.Size = new System.Drawing.Size(694, 34);
            this.TextBox_Input.TabIndex = 3;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.TextBox_Context);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(989, 531);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Context";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // TextBox_Context
            // 
            this.TextBox_Context.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox_Context.Location = new System.Drawing.Point(3, 3);
            this.TextBox_Context.Name = "TextBox_Context";
            this.TextBox_Context.Size = new System.Drawing.Size(983, 525);
            this.TextBox_Context.TabIndex = 0;
            this.TextBox_Context.Text = "";
            this.TextBox_Context.WordWrap = false;
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 470);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Chat";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chat with AI";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button Button_Chat;
        private System.Windows.Forms.TextBox TextBox_Input;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox TextBox_Context;
        private System.Windows.Forms.WebBrowser WebBrowser_Conversation;
    }
}