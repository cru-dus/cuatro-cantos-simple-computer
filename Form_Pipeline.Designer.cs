namespace WIPS
{
    partial class Form_Pipeline
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rect_fetch = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.rect_execute = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.rect_ALU = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.rect_decode = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape3 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lbl_fetch_inst = new System.Windows.Forms.Label();
            this.lbl_decode_inst = new System.Windows.Forms.Label();
            this.lbl_execute_inst = new System.Windows.Forms.Label();
            this.lbl_alu_inst = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Controls.Add(this.lbl_alu_inst);
            this.panel1.Controls.Add(this.lbl_execute_inst);
            this.panel1.Controls.Add(this.lbl_decode_inst);
            this.panel1.Controls.Add(this.lbl_fetch_inst);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.shapeContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(471, 248);
            this.panel1.TabIndex = 0;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape3,
            this.lineShape2,
            this.lineShape1,
            this.rect_decode,
            this.rect_ALU,
            this.rect_execute,
            this.rect_fetch});
            this.shapeContainer1.Size = new System.Drawing.Size(471, 248);
            this.shapeContainer1.TabIndex = 0;
            this.shapeContainer1.TabStop = false;
            // 
            // rect_fetch
            // 
            this.rect_fetch.BackColor = System.Drawing.SystemColors.Control;
            this.rect_fetch.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.rect_fetch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.rect_fetch.Location = new System.Drawing.Point(25, 70);
            this.rect_fetch.Name = "rect_fetch";
            this.rect_fetch.Size = new System.Drawing.Size(106, 93);
            // 
            // rect_execute
            // 
            this.rect_execute.BackColor = System.Drawing.SystemColors.Control;
            this.rect_execute.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.rect_execute.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.rect_execute.Location = new System.Drawing.Point(303, 20);
            this.rect_execute.Name = "rect_execute";
            this.rect_execute.Size = new System.Drawing.Size(138, 102);
            // 
            // rect_ALU
            // 
            this.rect_ALU.BackColor = System.Drawing.SystemColors.Control;
            this.rect_ALU.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.rect_ALU.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.rect_ALU.Location = new System.Drawing.Point(327, 150);
            this.rect_ALU.Name = "rect_ALU";
            this.rect_ALU.Size = new System.Drawing.Size(91, 81);
            // 
            // rect_decode
            // 
            this.rect_decode.BackColor = System.Drawing.SystemColors.Control;
            this.rect_decode.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.rect_decode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.rect_decode.Location = new System.Drawing.Point(147, 71);
            this.rect_decode.Name = "rect_decode";
            this.rect_decode.Size = new System.Drawing.Size(111, 92);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "FETCH";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(158, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "DECODE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(323, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "EXECUTE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(349, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 24);
            this.label4.TabIndex = 4;
            this.label4.Text = "ALU";
            // 
            // lineShape1
            // 
            this.lineShape1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 132;
            this.lineShape1.X2 = 147;
            this.lineShape1.Y1 = 116;
            this.lineShape1.Y2 = 116;
            // 
            // lineShape2
            // 
            this.lineShape2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lineShape2.Name = "lineShape2";
            this.lineShape2.X1 = 258;
            this.lineShape2.X2 = 302;
            this.lineShape2.Y1 = 114;
            this.lineShape2.Y2 = 71;
            // 
            // lineShape3
            // 
            this.lineShape3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lineShape3.Name = "lineShape3";
            this.lineShape3.X1 = 259;
            this.lineShape3.X2 = 327;
            this.lineShape3.Y1 = 125;
            this.lineShape3.Y2 = 194;
            // 
            // lbl_fetch_inst
            // 
            this.lbl_fetch_inst.AutoSize = true;
            this.lbl_fetch_inst.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_fetch_inst.ForeColor = System.Drawing.Color.Blue;
            this.lbl_fetch_inst.Location = new System.Drawing.Point(56, 125);
            this.lbl_fetch_inst.Name = "lbl_fetch_inst";
            this.lbl_fetch_inst.Size = new System.Drawing.Size(0, 13);
            this.lbl_fetch_inst.TabIndex = 5;
            // 
            // lbl_decode_inst
            // 
            this.lbl_decode_inst.AutoSize = true;
            this.lbl_decode_inst.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_decode_inst.ForeColor = System.Drawing.Color.Blue;
            this.lbl_decode_inst.Location = new System.Drawing.Point(168, 125);
            this.lbl_decode_inst.Name = "lbl_decode_inst";
            this.lbl_decode_inst.Size = new System.Drawing.Size(0, 13);
            this.lbl_decode_inst.TabIndex = 6;
            // 
            // lbl_execute_inst
            // 
            this.lbl_execute_inst.AutoSize = true;
            this.lbl_execute_inst.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_execute_inst.ForeColor = System.Drawing.Color.Blue;
            this.lbl_execute_inst.Location = new System.Drawing.Point(335, 71);
            this.lbl_execute_inst.Name = "lbl_execute_inst";
            this.lbl_execute_inst.Size = new System.Drawing.Size(0, 13);
            this.lbl_execute_inst.TabIndex = 7;
            // 
            // lbl_alu_inst
            // 
            this.lbl_alu_inst.AutoSize = true;
            this.lbl_alu_inst.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_alu_inst.ForeColor = System.Drawing.Color.Blue;
            this.lbl_alu_inst.Location = new System.Drawing.Point(350, 196);
            this.lbl_alu_inst.Name = "lbl_alu_inst";
            this.lbl_alu_inst.Size = new System.Drawing.Size(0, 13);
            this.lbl_alu_inst.TabIndex = 8;
            // 
            // Form_Pipeline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 248);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(494, 303);
            this.Name = "Form_Pipeline";
            this.Text = "Pipeline";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rect_decode;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rect_ALU;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rect_execute;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rect_fetch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape3;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.Label lbl_alu_inst;
        private System.Windows.Forms.Label lbl_execute_inst;
        private System.Windows.Forms.Label lbl_decode_inst;
        private System.Windows.Forms.Label lbl_fetch_inst;
    }
}