using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WIPS
{
    public partial class Form_Main : Form
    {
        public Form_Main()
        {
            InitializeComponent();
            initializeChildWindows();
        }
        
        private Form_SourceCode source;
        private Form_Cycles cycles;
        private Form_Pipeline pipeline;
        private Form_Registers registers;
        private Form_Statistics stats;
        private String sourceCode;
        private Form_Console console;
        private LinkedList<Token> classifiedTokens;
        private LinkedList<Command> commands; //list for instructions 
        private LinkedList<Command> process = null; //list for instructions being processed
        private Boolean toContinue; //flag for processing
        private Boolean[] stateFlags = new Boolean[3]; //flags for [0]Fetch [1]Decode [2]Execute
        private int instructionPointer = 0; //index  of the next instruction
        private Dictionary<String, int> labels; //structure for all labels

        private void initializeChildWindows()
        {
            source = new Form_SourceCode();
            source.MdiParent = this;

            cycles = new Form_Cycles();
            cycles.MdiParent = this;

            pipeline = new Form_Pipeline();
            pipeline.MdiParent = this;

            console = new Form_Console();
            console.MdiParent = this;

            stats = new Form_Statistics();
            stats.MdiParent = this;

            registers = new Form_Registers();
            registers.MdiParent = this;

            source.Show();
            cycles.Show();
            pipeline.Show();
            console.Show();
            stats.Show();
            registers.Show();
        }

        private async void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Text File";
            theDialog.Filter = "*.txt files|*.txt";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamReader sr = new StreamReader(theDialog.FileName))
                    {
                        //re-initialized lists
                        classifiedTokens = new LinkedList<Token>();
                        classifiedTokens.Clear();
                        commands = new LinkedList<Command>();
                        commands.Clear();

                        //read file
                        sourceCode = await sr.ReadToEndAsync();

                        //tokenize
                        classifyTokens(sourceCode.Split('\n', '\r'));

                        //parse tokens
                        parse();

                        //reset source screen
                        source.clearScreen();

                        //display source code and binary codes
                        displayCommands();

                        //run simulator
                        simulate();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                
            }
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade); //cascade child windows
        }

        private void tileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileVertical); //tile child windows vertically
        }

        private void arraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.ArrangeIcons);
        }

        //Tokenize each input element and store each of them to the list
        private void classifyTokens(String[] lines)
        {
            console.addMessage("Tokenizing...");
            toContinue = true;
            for (int x = 0; x < lines.Length; x++)
            {
                String[] tokens = lines[x].Split(' ');
                if (toContinue)
                for (int i = 0; i < tokens.Length; i++)
                {
                    if (toContinue)
                    {
                        tokens[i] = tokens[i].Trim(); //remove trailing/leading spaces
                        if (tokens[i].Equals("")) continue;
                        switch (tokens[i])
                        {
                            //valid keywords
                            case "LOD": case "STR": case "SAV":
                            case "INC": case "DEC": case "ADD":
                            case "SUB": case "MUL": case "DIV":
                            case "CMP": case "AND": case "OR":
                            case "NOT": case "IFE": case "IFG":
                            case "IFL": case "FLY": case "R0":
                            case "R1": case "R2": case "R3":
                            case "R4": case "R5": case "R6":
                            case "R7": case "MAR0": case "MAR1":
                                classifiedTokens.AddLast(new Token(tokens[i]));
                                break;
                            
                            //Default case
                            default:
                                byte val;
                                //check for data/integer value
                                if (byte.TryParse(tokens[i], out val))
                                {
                                    classifiedTokens.AddLast(new Token(val, "DATA"));
                                    break;
                                }
                                //check for label values
                                else if (tokens[i][tokens[i].Length - 1] == ':')
                                {
                                    //Label name example -> label:
                                   
                                    classifiedTokens.AddLast(new Token(tokens[i], "LABEL NAME", x));
                                    break;
                                }
                                else if (tokens[i][0] == ':')
                                {
                                    //goto label example -> FLY :label
                                    classifiedTokens.AddLast(new Token(tokens[i], "LABEL", 0));
                                    break;
                                }
                                else
                                {
                                    //unidentified token
                                    toContinue = false; //unset flag
                                    console.addMessage("Invalid token " + tokens[i] + "  at line number "+x+".");
                                    break;
                                }
                        }
                    }
                }
            }
            console.addMessage("Tokenizing ended.");
            
        }

        //Initialize Command objects from tokenized elements
        private void parse()
        {
            if (toContinue)
            {
                console.addMessage("Parsing...");
                labels = new Dictionary<string, int>();
                labels.Clear();
                for (int i = 0; i < classifiedTokens.Count; i++)
                {
                    if(!toContinue)return;
                    Token t = classifiedTokens.ElementAt(i);
                    switch (t.getClassification())
                    {
                        case "DATA TRANSFER": 
                            switch (t.getToken())
                            {
                                case "LOD": // LOD <GEN PUR REG> <MEM ADD REG>
                                    if (classifiedTokens.ElementAt(i + 1).getClassification().Equals("GENERAL PURPOSE REGISTER"))
                                    {
                                        if (classifiedTokens.ElementAt(i + 2).getClassification().Equals("ADDRESS REGISTER"))
                                        {
                                            String code = t.getCode() +
                                                classifiedTokens.ElementAt(i+1).getCode() +
                                                classifiedTokens.ElementAt(i+2).getCode();
                                                commands.AddLast(new Command(t.getToken(), 
                                                classifiedTokens.ElementAt(i+1).getToken(), 
                                                classifiedTokens.ElementAt(i+2).getToken(),
                                                code
                                                ));
                                        }
                                        else
                                        {
                                            console.addMessage("Memory address register expected after " + classifiedTokens.ElementAt(i + 1).getToken());
                                            toContinue = false;
                                        }
                                    }
                                    else
                                    {
                                        console.addMessage("General purpose register expected after " + t.getToken());
                                        toContinue = false;
                                    }
                                    break;
                                case "SAV": // SAV <GEN PUR REG> <DATA>
                                    if (classifiedTokens.ElementAt(i + 1).getClassification().Equals("GENERAL PURPOSE REGISTER"))
                                    {
                                        if (classifiedTokens.ElementAt(i + 2).getClassification().Equals("DATA"))
                                        {
                                            String code = t.getCode() +
                                                classifiedTokens.ElementAt(i+1).getCode() +
                                                classifiedTokens.ElementAt(i+2).getCode();
                                                commands.AddLast(new Command(t.getToken(), 
                                                classifiedTokens.ElementAt(i+1).getToken(), 
                                                classifiedTokens.ElementAt(i+2).getToken(),
                                                code
                                                ));
                                        }
                                        else
                                        {
                                            console.addMessage("Integer data expected after " + classifiedTokens.ElementAt(i + 1).getToken());
                                            toContinue = false;
                                        }
                                    }
                                    else
                                    {
                                        console.addMessage("General purpose register expected after " + t.getToken());
                                        toContinue = false;
                                    }
                                    break;
                                case "STR": // STR <MEM ADD REG> <GEN PUR REG>
                                    if (classifiedTokens.ElementAt(i + 1).getClassification().Equals("ADDRESS REGISTER"))
                                    {
                                        if (classifiedTokens.ElementAt(i + 2).getClassification().Equals("GENERAL PURPOSE REGISTER"))
                                        {
                                            String code = t.getCode() +
                                                classifiedTokens.ElementAt(i+1).getCode() +
                                                classifiedTokens.ElementAt(i+2).getCode();
                                                commands.AddLast(new Command(t.getToken(), 
                                                classifiedTokens.ElementAt(i+1).getToken(), 
                                                classifiedTokens.ElementAt(i+2).getToken(),
                                                code
                                                ));
                                        }
                                        else
                                        {
                                            console.addMessage("General purpose register expected after " + classifiedTokens.ElementAt(i + 1).getToken());
                                            toContinue = false;
                                        }
                                    }
                                    else
                                    {
                                        console.addMessage("Memory address register expected after " + t.getToken());
                                        toContinue = false;
                                    }
                                    break;
                            }
                            break;
                            //<OPERATION> <GEN PUR REG> <GEN PUR REG>
                        case "ARITHMETIC":
                        case "COMPARISON":
                        case "LOGIC":
                            if (classifiedTokens.ElementAt(i + 1).getClassification().Contains("REGISTER"))
                            {
                                if (classifiedTokens.ElementAt(i + 2).getClassification().Contains("REGISTER"))
                                {
                                    String a = t.getCode();
                                    String b = classifiedTokens.ElementAt(i + 1).getCode();
                                    String c = classifiedTokens.ElementAt(i + 2).getCode();
                                    String binaryCode = a + b + c;

                                    commands.AddLast(new Command(t.getToken(),
                                        classifiedTokens.ElementAt(i + 1).getToken(),
                                        classifiedTokens.ElementAt(i + 2).getToken(),
                                        binaryCode));
                                }
                                else
                                {
                                    console.addMessage("Register name expected after: " + classifiedTokens.ElementAt(i + 2));
                                }
                            }
                            else
                            {
                                console.addMessage("Register name expected after: " + classifiedTokens.ElementAt(i + 1).getClassification());
                            }
                            break;

                        case "PROGRAM FLOW": //<PROG FLOW> <LABEL>
                            if (classifiedTokens.ElementAt(i + 1).getClassification().Equals("LABEL"))
                            {
                                String a = t.getCode();
                                String b = classifiedTokens.ElementAt(i + 1).getCode();
                                String binaryCode = a + b + "000000000";

                                commands.AddLast(new Command(t.getToken(), classifiedTokens.ElementAt(i + 1).getToken(), null, binaryCode));
                            }
                            else
                            {
                                console.addMessage("Label expected after: " + classifiedTokens.ElementAt(i));
                            }
                            break;
                        case "LABEL NAME": //<LABEL NAME>
                            //check existence of label
                            if (labels.ContainsKey(t.getToken()))
                            {
                                console.addMessage("Label name " + t.getToken().Substring(0, t.getToken().Length-1) + " cannot be declared again.");
                                toContinue = false;
                                break;
                            }
                            else
                            {
                                //add label and instruction it points which is the one next to this
                                labels.Add(t.getToken(), commands.Count);
                                break;
                            }
                            
                    }
                }
                console.addMessage("Parsing ended.");
            }
        }

        //Start simulation by initializing one instruction
        private void simulate()
        {
            if (toContinue)
            {
                console.addMessage("Simulating...");
                //reset
                resetStateFlags();
                cycles.reset();
                instructionPointer = 0;

                //add first instruction
                process = new LinkedList<Command>();
                commands.First().fetch();
                lockStateFlag(commands.First().getState());
                process.AddLast(commands.First());
                cycles.addInstruction(commands.First());
                pipeline.activateFetch(commands.First().getInstruction());
                instructionPointer++;
                drawCycles(process);
            }
        }

        //draw the current cycle
        private void drawCycles(LinkedList<Command> current)
        {
            cycles.addColumn(current);
        }

        //Display the instructions
        private void displayCommands()
        {
            if(toContinue)
            for (int i = 0; i < commands.Count; i++)
            {
                source.addInstruction(commands.ElementAt(i).getBinaryCode(), 
                    commands.ElementAt(i).getInstruction(), 
                    new String[]{commands.ElementAt(i).getArg1(), commands.ElementAt(i).getArg2()});
            }
        }

        //reset FDE flags
        private void resetStateFlags()
        {
            for (int i = 0; i < 3; i++)
            {
                stateFlags[i] = true;
            }
        }

        //reset all child windows
        private void resetAll()
        {
            //reset all windows
            console.reset();
            cycles.reset();
            source.reset();
            pipeline.reset();

            //clear all lists
            process = null;
            labels.Clear();

            //reset all variables
            instructionPointer = 0;
            resetStateFlags();
            console.addMessage("Reset successful!");
        }

        //simulate next cycle
        private void singleStepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (process != null) //if process is initialized
            {
                pipeline.reset();
                //update running instructions
                foreach(Command c in process){
                    c.unstall();
                    unlockStateFlag(c.getState()); //unlock the flag that the instruction previously used
                    c.nextState(); //update state

                    //will enter here if instruction processing is finished
                    int state = flagToBeUsed(c.getState());
                    if (state == -1)
                    {
                        
                    }
                    else //instruction processing not done
                    {
                        //is the new flag to be used available?
                        if (stateFlags[state])
                        {
                            //if yes, lock it baby
                            lockStateFlag(c.getState());

                            //draw pipeline
                            switch (state)
                            {
                                case 0:
                                    pipeline.activateFetch(c.getInstruction());
                                    break;
                                case 1:
                                    pipeline.activateDecode(c.getInstruction());
                                    break;
                                case 2:
                                    pipeline.activateExecute(c.getInstruction());
                                    String instructionCode = c.getInstructionCode();
                                    String type = Code.getInstructionType(instructionCode);

                                    //check if will pass through the ALU
                                    switch (type)
                                    {
                                        case "ARITHMETIC":
                                        case "LOGIC":
                                        case "COMPARISON":
                                            pipeline.activateALU(c.getInstruction());
                                            break;
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            //else, stall first
                            c.Stall();
                        }
                    }
                    
                }

                //add to process a new instruction
                if (instructionPointer < commands.Count)
                {
                    commands.ElementAt(instructionPointer).fetch();
                    lockStateFlag(commands.ElementAt(instructionPointer).getState());
                    process.AddLast(commands.ElementAt(instructionPointer));
                    cycles.addInstruction(commands.ElementAt(instructionPointer));
                    pipeline.activateFetch(commands.ElementAt(instructionPointer).getInstruction());
                    instructionPointer++;
                }
                drawCycles(process);
            }
        }

        //unlock the F/D/E flag
        private void unlockStateFlag(int state)
        {
            int flag = flagToBeUsed(state);
            if (flag != -1)
            {
                stateFlags[flag] = true;
            }
        }

        //lock the F/D/E flag
        private void lockStateFlag(int state)
        {
            int flag = flagToBeUsed(state);
            if (flag != -1)
            {
                stateFlags[flag] = false;
            }
        }
        

        //identify which among F/D/E flag will be used
        private int flagToBeUsed(int state)
        {
            switch (state)
            {
                case 1:
                    return 0; //Fetch flag
                case 2:
                case 3:
                    return 1; //decode flag
                case 4:
                case 5:
                    return 2; //execute flag
            }

            return -1;
        }

        //full reset
        private void resetCCMiniComToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resetAll();
        }

        //exit
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
