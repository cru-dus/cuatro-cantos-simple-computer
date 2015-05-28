using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WIPS
{
    //win form for the pipeline
    public partial class Form_Pipeline : Form
    {
        public Form_Pipeline()
        {
            InitializeComponent();
        }

        //reset this winform
        public void reset()
        {
            //reset labels
            lbl_alu_inst.Text = lbl_decode_inst.Text = lbl_execute_inst.Text = lbl_fetch_inst.Text = "";
            rect_execute.BackColor = rect_decode.BackColor = rect_ALU.BackColor = rect_fetch.BackColor =  SystemColors.Control;
        }

        public void activateFetch(String instruction)
        {

            lbl_fetch_inst.Text = instruction;
            rect_fetch.BackColor = Color.Yellow;
        }

        public void activateDecode(String instruction)
        {
            lbl_decode_inst.Text = instruction;
            rect_decode.BackColor = Color.Aqua;
        }

        public void activateExecute(String instruction)
        {
            lbl_execute_inst.Text = instruction;
            rect_execute.BackColor = Color.Red;
        }

        public void activateALU(String instruction)
        {
            rect_ALU.BackColor = Color.Red;
            lbl_alu_inst.Text = instruction;
        }
    }
}
