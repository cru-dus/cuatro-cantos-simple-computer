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
        private LinkedList<Command> commands; // linked list for each command line (object)
        private LinkedList<Command> process = null;
        private Boolean toContinue;  // linked list for each token (object)
        private Boolean[] stateFlags = new Boolean[3]; //[0]Fetch [1]Decode [2]Execute
        private int[] hazards = new int[3];
        private int instructionPointer = 0; //index  the next instruction


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
                        
                        classifiedTokens = new LinkedList<Token>();
                        classifiedTokens.Clear();
                        commands = new LinkedList<Command>();
                        commands.Clear();
                        sourceCode = await sr.ReadToEndAsync();
                        classifyTokens(sourceCode.Split('\n', '\r'));
                        parse();
                        source.clearScreen();
                        displayCommands();
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
            this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
        }

        private void tileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileVertical);
        }

        private void arraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.ArrangeIcons);
        }

        //Tokenize each input element and store each of them as object
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
                        tokens[i] = tokens[i].Trim();
                        if (tokens[i].Equals("")) continue;
                        switch (tokens[i])
                        {
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
                                if(byte.TryParse(tokens[i], out val)){
                                    classifiedTokens.AddLast(new Token(val, "DATA"));
                                    break;
                                }
                                toContinue = false;
                                console.addMessage("Invalid token: " + tokens[i]);
                                break;
                        }
                    }
                }
            }
            console.addMessage("Tokenizing ended.");
            
        }

        //Initialize command objects from tokenized elements
        //edit loop jumps
        private void parse()
        {
            if (toContinue)
            {
                console.addMessage("Parsing...");
                for (int i = 0; i < classifiedTokens.Count; i++)
                {
                    if(!toContinue)return;
                    Token t = classifiedTokens.ElementAt(i);
                    switch (t.getClassification())
                    {
                        case "DATA TRANSFER":
                            switch (t.getToken())
                            {
                                case "LOD":
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
                                case "SAV":
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
                                case "STR":
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
                                        console.addMessage("FOUND: " + classifiedTokens.ElementAt(i + 1).getToken());
                                        toContinue = false;
                                    }
                                    break;
                            }
                            break;
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

                        case "PROGRAM FLOW":
                            //LABEL for FLY INSTRUCTION IS NOT YET CHECKED HERE (NOT WORKING)
                            if (classifiedTokens.ElementAt(i + 1).getClassification().Equals("REGISTER"))
                            {
                                String a = classifiedTokens.ElementAt(i).getCode();
                                String b = classifiedTokens.ElementAt(i + 1).getCode();
                                String binaryCode = a + b;

                                commands.AddLast(new Command(t.getToken(), classifiedTokens.ElementAt(i + 1).getToken(), null, binaryCode));
                            }
                            else
                            {
                                //prompt error: label name expected after tokens[i]
                                console.addMessage("Label name expected after: " + classifiedTokens.ElementAt(i));
                            }
                            break;
                    }
                }
                console.addMessage("Parsing ended.");
            }
        }

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

        private void drawCycles(LinkedList<Command> current)
        {
            cycles.addColumn(current);
        }

        //Display the command objects
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

        private void resetStateFlags()
        {
            for (int i = 0; i < 3; i++)
            {
                stateFlags[i] = true;
            }
        }

        private void resetAll()
        {
            //reset all windows
            console.reset();
            cycles.reset();
            source.reset();
            pipeline.reset();


            //clear all tables

            //clear all lists
            process = null;

            //reset all variables
            instructionPointer = 0;
            resetStateFlags();
            console.addMessage("Reset successful!");
        }

        private void singleStepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
             * update states of all running instructions
             *  -check if to stall or to continue to next state
             * add next instruction to the process list 
             
             */
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

        private void unlockStateFlag(int state)
        {
            int flag = flagToBeUsed(state);
            if (flag != -1)
            {
                stateFlags[flag] = true;
            }
        }

        private void lockStateFlag(int state)
        {
            int flag = flagToBeUsed(state);
            if (flag != -1)
            {
                stateFlags[flag] = false;
            }
        }

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

        private void resetCCMiniComToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resetAll();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
