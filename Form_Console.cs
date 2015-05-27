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
    public partial class Form_Console : Form
    {
        private const String prefix = "CC-MiniCom >> ";

        public Form_Console()
        {
            InitializeComponent();
        }

        public void addMessage(String message)
        {
            cmd.AppendText(prefix + message + "\n");
        }

        public void reset()
        {
            cmd.Clear();
        }
    }
}
