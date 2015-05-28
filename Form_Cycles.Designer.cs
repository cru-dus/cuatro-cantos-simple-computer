namespace WIPS
{
    partial class Form_Cycles
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.rt_instructions = new System.Windows.Forms.RichTextBox();
            this.tbpanel = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.rt_instructions);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tbpanel);
            this.splitContainer1.Size = new System.Drawing.Size(372, 240);
            this.splitContainer1.SplitterDistance = 48;
            this.splitContainer1.TabIndex = 0;
            // 
            // rt_instructions
            // 
            this.rt_instructions.BackColor = System.Drawing.Color.Black;
            this.rt_instructions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rt_instructions.ForeColor = System.Drawing.Color.White;
            this.rt_instructions.Location = new System.Drawing.Point(0, 0);
            this.rt_instructions.Name = "rt_instructions";
            this.rt_instructions.ReadOnly = true;
            this.rt_instructions.Size = new System.Drawing.Size(48, 240);
            this.rt_instructions.TabIndex = 0;
            this.rt_instructions.Text = "";
            this.rt_instructions.WordWrap = false;
            // 
            // tbpanel
            // 
            this.tbpanel.AutoScroll = true;
            this.tbpanel.AutoSize = true;
            this.tbpanel.BackColor = System.Drawing.Color.Black;
            this.tbpanel.ColumnCount = 1;
            this.tbpanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tbpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbpanel.Location = new System.Drawing.Point(0, 0);
            this.tbpanel.Name = "tbpanel";
            this.tbpanel.RowCount = 1;
            this.tbpanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tbpanel.Size = new System.Drawing.Size(320, 240);
            this.tbpanel.TabIndex = 0;
            // 
            // Form_Cycles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(372, 240);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form_Cycles";
            this.Text = "Cycles";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox rt_instructions;
        private System.Windows.Forms.TableLayoutPanel tbpanel;
    }
}