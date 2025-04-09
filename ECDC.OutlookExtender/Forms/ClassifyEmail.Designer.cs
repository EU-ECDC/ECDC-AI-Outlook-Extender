namespace ECDC.OutlookExtender.Forms
{
    partial class ClassifyEmail
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
            this.TextBox_classification = new System.Windows.Forms.TextBox();
            this.Button_AssignCategory = new System.Windows.Forms.Button();
            this.Button_MoveToFolder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TextBox_classification
            // 
            this.TextBox_classification.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox_classification.Location = new System.Drawing.Point(12, 22);
            this.TextBox_classification.Name = "TextBox_classification";
            this.TextBox_classification.Size = new System.Drawing.Size(765, 34);
            this.TextBox_classification.TabIndex = 0;
            // 
            // Button_AssignCategory
            // 
            this.Button_AssignCategory.Location = new System.Drawing.Point(501, 79);
            this.Button_AssignCategory.Name = "Button_AssignCategory";
            this.Button_AssignCategory.Size = new System.Drawing.Size(135, 42);
            this.Button_AssignCategory.TabIndex = 1;
            this.Button_AssignCategory.Text = "Assign Category";
            this.Button_AssignCategory.UseVisualStyleBackColor = true;
            this.Button_AssignCategory.Click += new System.EventHandler(this.Button_AssignCategory_Click);
            // 
            // Button_MoveToFolder
            // 
            this.Button_MoveToFolder.Location = new System.Drawing.Point(642, 79);
            this.Button_MoveToFolder.Name = "Button_MoveToFolder";
            this.Button_MoveToFolder.Size = new System.Drawing.Size(135, 42);
            this.Button_MoveToFolder.TabIndex = 2;
            this.Button_MoveToFolder.Text = "Move to Folder";
            this.Button_MoveToFolder.UseVisualStyleBackColor = true;
            this.Button_MoveToFolder.Click += new System.EventHandler(this.Button_MoveToFolder_Click);
            // 
            // ClassifyEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 142);
            this.Controls.Add(this.Button_MoveToFolder);
            this.Controls.Add(this.Button_AssignCategory);
            this.Controls.Add(this.TextBox_classification);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClassifyEmail";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Classify Email";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Button_AssignCategory;
        private System.Windows.Forms.Button Button_MoveToFolder;
        public System.Windows.Forms.TextBox TextBox_classification;
    }
}