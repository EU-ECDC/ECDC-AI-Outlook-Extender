namespace ECDC.OutlookExtender.Forms
{
    partial class Tasks
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
            this.Button_Create = new System.Windows.Forms.Button();
            this.ComboBox_Todos = new System.Windows.Forms.ComboBox();
            this.CheckedListBox_Tasks = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // Button_Create
            // 
            this.Button_Create.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Create.Enabled = false;
            this.Button_Create.Location = new System.Drawing.Point(418, 451);
            this.Button_Create.Name = "Button_Create";
            this.Button_Create.Size = new System.Drawing.Size(143, 28);
            this.Button_Create.TabIndex = 2;
            this.Button_Create.Text = "Import Tasks";
            this.Button_Create.UseVisualStyleBackColor = true;
            this.Button_Create.Click += new System.EventHandler(this.Button_Create_Click);
            // 
            // ComboBox_Todos
            // 
            this.ComboBox_Todos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBox_Todos.FormattingEnabled = true;
            this.ComboBox_Todos.Location = new System.Drawing.Point(567, 451);
            this.ComboBox_Todos.Name = "ComboBox_Todos";
            this.ComboBox_Todos.Size = new System.Drawing.Size(216, 28);
            this.ComboBox_Todos.TabIndex = 3;
            // 
            // CheckedListBox_Tasks
            // 
            this.CheckedListBox_Tasks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckedListBox_Tasks.FormattingEnabled = true;
            this.CheckedListBox_Tasks.Location = new System.Drawing.Point(0, 0);
            this.CheckedListBox_Tasks.Name = "CheckedListBox_Tasks";
            this.CheckedListBox_Tasks.Size = new System.Drawing.Size(795, 441);
            this.CheckedListBox_Tasks.TabIndex = 4;
            // 
            // FormTasks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 491);
            this.Controls.Add(this.CheckedListBox_Tasks);
            this.Controls.Add(this.ComboBox_Todos);
            this.Controls.Add(this.Button_Create);
            this.Name = "FormTasks";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Task Identifier";
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.ComboBox ComboBox_Todos;
        public System.Windows.Forms.CheckedListBox CheckedListBox_Tasks;
        public System.Windows.Forms.Button Button_Create;
    }
}