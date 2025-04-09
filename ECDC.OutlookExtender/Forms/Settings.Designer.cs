namespace ECDC.OutlookExtender.Forms
{
    partial class Settings
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
            this.PropertyGrid_Main = new System.Windows.Forms.PropertyGrid();
            this.Button_Apply = new System.Windows.Forms.Button();
            this.Label_Info = new System.Windows.Forms.Label();
            this.Button_Reset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PropertyGrid_Main
            // 
            this.PropertyGrid_Main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PropertyGrid_Main.Location = new System.Drawing.Point(0, 0);
            this.PropertyGrid_Main.Name = "PropertyGrid_Main";
            this.PropertyGrid_Main.Size = new System.Drawing.Size(772, 470);
            this.PropertyGrid_Main.TabIndex = 0;
            // 
            // Button_Apply
            // 
            this.Button_Apply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Apply.Location = new System.Drawing.Point(679, 480);
            this.Button_Apply.Name = "Button_Apply";
            this.Button_Apply.Size = new System.Drawing.Size(82, 43);
            this.Button_Apply.TabIndex = 1;
            this.Button_Apply.Text = "Save";
            this.Button_Apply.UseVisualStyleBackColor = true;
            this.Button_Apply.Click += new System.EventHandler(this.Button_Apply_Click);
            // 
            // Label_Info
            // 
            this.Label_Info.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label_Info.AutoSize = true;
            this.Label_Info.Location = new System.Drawing.Point(12, 499);
            this.Label_Info.Name = "Label_Info";
            this.Label_Info.Size = new System.Drawing.Size(67, 20);
            this.Label_Info.TabIndex = 3;
            this.Label_Info.Text = "-no info-";
            // 
            // Button_Reset
            // 
            this.Button_Reset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Reset.Location = new System.Drawing.Point(591, 480);
            this.Button_Reset.Name = "Button_Reset";
            this.Button_Reset.Size = new System.Drawing.Size(82, 43);
            this.Button_Reset.TabIndex = 4;
            this.Button_Reset.Text = "Reset";
            this.Button_Reset.UseVisualStyleBackColor = true;
            this.Button_Reset.Click += new System.EventHandler(this.Button_Reset_Click);
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 531);
            this.Controls.Add(this.Button_Reset);
            this.Controls.Add(this.Label_Info);
            this.Controls.Add(this.Button_Apply);
            this.Controls.Add(this.PropertyGrid_Main);
            this.Name = "Settings";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Property Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PropertyGrid PropertyGrid_Main;
        private System.Windows.Forms.Button Button_Apply;
        private System.Windows.Forms.Label Label_Info;
        private System.Windows.Forms.Button Button_Reset;
    }
}