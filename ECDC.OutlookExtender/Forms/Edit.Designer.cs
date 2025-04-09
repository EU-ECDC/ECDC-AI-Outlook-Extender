namespace ECDC.OutlookExtender.Forms
{
    partial class Edit
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
            this.RichTextBox_Edit = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // RichTextBox_Edit
            // 
            this.RichTextBox_Edit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RichTextBox_Edit.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichTextBox_Edit.Location = new System.Drawing.Point(0, 0);
            this.RichTextBox_Edit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RichTextBox_Edit.Name = "RichTextBox_Edit";
            this.RichTextBox_Edit.Size = new System.Drawing.Size(938, 585);
            this.RichTextBox_Edit.TabIndex = 0;
            this.RichTextBox_Edit.Text = "";
            // 
            // FormEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 585);
            this.Controls.Add(this.RichTextBox_Edit);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormEdit";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AI Output";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.RichTextBox RichTextBox_Edit;
    }
}