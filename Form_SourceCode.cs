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
    public partial class Form_SourceCode : Form
    {
        public Form_SourceCode()
        {
            InitializeComponent();
        }

        public void addInstruction(String code, String opcode, String[] operands)
        {
            rtb_code.AppendText(code + "\t" + opcode+" ");
            for (int i = 0; i < operands.Count(); i++)
            {
                rtb_code.AppendText(operands[i]+" ");
            }
            rtb_code.AppendText("\n");
        }

        public void clearScreen()
        {
            rtb_code.Clear();
        }
        public void reset()
        {
            clearScreen();
        }
    }
}
