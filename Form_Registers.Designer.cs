namespace WIPS
{
    partial class Form_Registers
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
            this.grid_registers = new System.Windows.Forms.DataGridView();
            this.grid_registers_col1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_registers_col2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grid_registers)).BeginInit();
            this.SuspendLayout();
            // 
            // grid_registers
            // 
            this.grid_registers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_registers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grid_registers_col1,
            this.grid_registers_col2});
            this.grid_registers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_registers.Enabled = false;
            this.grid_registers.Location = new System.Drawing.Point(0, 0);
            this.grid_registers.Name = "grid_registers";
            this.grid_registers.ReadOnly = true;
            this.grid_registers.Size = new System.Drawing.Size(284, 262);
            this.grid_registers.TabIndex = 0;
            // 
            // grid_registers_col1
            // 
            this.grid_registers_col1.HeaderText = "Register Name";
            this.grid_registers_col1.Name = "grid_registers_col1";
            this.grid_registers_col1.ReadOnly = true;
            // 
            // grid_registers_col2
            // 
            this.grid_registers_col2.HeaderText = "Value";
            this.grid_registers_col2.Name = "grid_registers_col2";
            this.grid_registers_col2.ReadOnly = true;
            // 
            // Registers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.grid_registers);
            this.Name = "Registers";
            this.Text = "Registers";
            ((System.ComponentModel.ISupportInitialize)(this.grid_registers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grid_registers;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_registers_col1;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_registers_col2;
    }
}