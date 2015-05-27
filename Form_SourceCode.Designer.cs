namespace WIPS
{
    partial class Form_SourceCode
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
            this.rtb_code = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtb_code
            // 
            this.rtb_code.AcceptsTab = true;
            this.rtb_code.BackColor = System.Drawing.Color.Black;
            this.rtb_code.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.rtb_code.DetectUrls = false;
            this.rtb_code.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtb_code.ForeColor = System.Drawing.Color.White;
            this.rtb_code.Location = new System.Drawing.Point(0, 0);
            this.rtb_code.Name = "rtb_code";
            this.rtb_code.ReadOnly = true;
            this.rtb_code.Size = new System.Drawing.Size(578, 262);
            this.rtb_code.TabIndex = 0;
            this.rtb_code.Text = "";
            this.rtb_code.WordWrap = false;
            // 
            // Form_SourceCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 262);
            this.Controls.Add(this.rtb_code);
            this.Name = "Form_SourceCode";
            this.Text = "Code";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtb_code;


    }
}