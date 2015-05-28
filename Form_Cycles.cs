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
    //winform for the cycles
    public partial class Form_Cycles : Form
    {
        public int startRow = 0;

        public Form_Cycles()
        {
            InitializeComponent();
            
        }

        //add instruction to the left pane (rtbox)
        public void addInstruction(Command c)
        {
            rt_instructions.AppendText(c.getInstruction() + " " + c.getArg1() + " " + c.getArg2() + "\n");
        }

        //reset this winform
        public void reset()
        {
            
            tbpanel.RowStyles.Clear();
            tbpanel.ColumnStyles.Clear();
            
            
            rt_instructions.Clear();
            
            tbpanel.Controls.Clear();

            tbpanel.Refresh();

            tbpanel.RowCount = 1;
            tbpanel.ColumnCount = 1;
            
            tbpanel.HorizontalScroll.Maximum = tbpanel.HorizontalScroll.Minimum+1;
            tbpanel.VerticalScroll.Maximum = tbpanel.VerticalScroll.Minimum+1;
            
            tbpanel.AutoScrollPosition = new Point(tbpanel.HorizontalScroll.Minimum, 0);
            //tbpanel.AutoScroll = false;

            tbpanel.Refresh();
            

        }


        //add a new cycle
        public void addColumn(LinkedList<Command> states)
        {
            int row = startRow;
            if (!tbpanel.AutoScroll)
            {
                tbpanel.AutoScroll = true;
            }
            tbpanel.RowCount = states.Count+1;
            tbpanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30));
            tbpanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 13)); 
            
            
            foreach (Command c in states)
            {
                Label l = new Label();
                l.Text = c.getStateName();
                l.BackColor = c.getStateColor();
                l.ForeColor = Color.Black;
                l.Dock = DockStyle.Fill;
                l.TextAlign = ContentAlignment.MiddleCenter;

                tbpanel.Controls.Add(l, tbpanel.ColumnCount-1, row);
                row++;
            }

            tbpanel.ColumnCount++;
            //tbpanel.AutoScrollPosition = new Point(tbpanel.HorizontalScroll.Maximum, 0);
        }
    }
}
