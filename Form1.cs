using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parser
{
    public partial class frm_1 : Form
    {
        public frm_1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            classifyTokens(richTextBox1.Text.Split(' ', '\n'));
            displayTokens();
        }

        private LinkedList<Token> classifiedTokens;
        private void classifyTokens(String[] tokens)
        {
            classifiedTokens = new LinkedList<Token>();
            for (int i = 0; i < tokens.Length; i++)
            {
                switch (tokens[i])
                {
                    case "LOD":
                    case "STR":
                    case "SAV":
                        classifiedTokens.AddLast(new Token(tokens[i], "DATA TRANSFER INSTRUCTION", "01010101"));
                        break;
                    case "INC":
                    case "DEC":
                    case "ADD":
                    case "SUB":
                    case "MUL":
                    case "DIV":
                        classifiedTokens.AddLast(new Token(tokens[i], "ARITHMETIC INSTRUCTIONS", "00001100"));
                        break;
                    default:
                        classifiedTokens.AddLast(new Token(tokens[i], "UFO", "shitty-byte"));
                        break;

                    //Ken voluntered to finish this shit.

                }
            }
        }

        private void displayTokens()
        {
            for (int i = 0; i < classifiedTokens.Count; i++)
            {
                dataGridView1.Rows.Add(classifiedTokens.ElementAt(i).getToken(), classifiedTokens.ElementAt(i).getClass());
            }
        }

        private LinkedList<Command> commands;
        
        private void parse()
        {
            commands = new LinkedList<Command>();

            for (int i = 0; i < classifiedTokens.Count; i++)
            {
                switch (classifiedTokens.ElementAt(i).getClass())
                {
                    case "DATA TRANSFER INSTRUCTION":
                    case "ARITHMETIC INSTRUCTION":
                        if (classifiedTokens.ElementAt(i + 1).getClass().Equals("REGISTER"))
                        {
                            if (classifiedTokens.ElementAt(i + 2).getClass().Equals("REGISTER"))
                            {
                                commands.AddLast(new Command(classifiedTokens.ElementAt(i).getToken(), classifiedTokens.ElementAt(i + 1).getToken(), classifiedTokens.ElementAt(i+2).getToken()));
                            }
                            else
                            {
                                //prompt error: register name expected after tokens[i]
                            }
                        }
                        else
                        {
                            //prompt error: register name expected after tokens[i]
                        }
                        break;
                }
            }

        }
    }
}
