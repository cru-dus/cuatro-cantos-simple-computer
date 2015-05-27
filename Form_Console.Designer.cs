namespace WIPS
{
    partial class Form_Console
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
            this.cmd = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // cmd
            // 
            this.cmd.BackColor = System.Drawing.Color.Black;
            this.cmd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmd.ForeColor = System.Drawing.Color.Green;
            this.cmd.Location = new System.Drawing.Point(0, 0);
            this.cmd.Name = "cmd";
            this.cmd.ReadOnly = true;
            this.cmd.Size = new System.Drawing.Size(633, 275);
            this.cmd.TabIndex = 0;
            this.cmd.Text = "";
            // 
            // Console
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(633, 275);
            this.Controls.Add(this.cmd);
            this.ForeColor = System.Drawing.Color.Green;
            this.MaximizeBox = false;
            this.Name = "Console";
            this.Text = "Console";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox cmd;
    }
}