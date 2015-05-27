using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIPS
{
    public class Command
    {
        private String instruction;
        private String arg1;
        private String arg2;
        private String binaryCode;
        private int state;
        private Boolean stall=false;

        /*
         * 0 - not running 
         * 1 - fetch
         * 2 - decode#1
         * 3 - decode#2
         * 4 - execute#1
         * 5 - execute#2
         * 6 - done
         */

        public Command(String instruction, String arg1, String arg2, String binaryCode)
        {
            this.instruction = instruction;
            this.arg1 = arg1;
            this.arg2 = arg2;
            this.binaryCode = binaryCode;
            this.state = 0;
        }

        public Boolean isStall()
        {
            return this.stall;
        }

        public void Stall()
        {
            state--;
            this.stall = true;
        }

        public void unstall()
        {
            this.stall = false;
        }

        public int getState()
        {
            return this.state;
        }

        public String getStateName()
        {
            if (stall)
            {
                return "S";
            }
            switch (state)
            {
                case 0: return "0";
                case 1: return "F";
                case 2:
                case 3: return "D";
                case 4:
                case 5: return "E";
                case 6: return " ";
                default: return null;

            }
        }

        public void nextState()
        {
            state++;
        }

        public Color getStateColor()
        {
            if (stall)
            {
                return Color.DarkGray;
            }
            switch (state)
            {
                case 1: return Color.Yellow;
                case 2:
                case 3: return Color.Aqua;
                case 4:
                case 5: return Color.Red;
                case 6: return Color.Black;

                default: return Color.Black;

            }
        }

        public void fetch()
        {
            this.state = 1;
        }

        public void decode()
        {
            
        }

        public void execute()
        {
            
        }

        public String getInstruction()
        {
            return this.instruction;
        }

        public String getArg1()
        {
            return this.arg1;
        }

        public String getArg2()
        {
            return this.arg2;
        }

        public String getBinaryCode()
        {
            return this.binaryCode;
        }

        public String getInstructionCode()
        {
            return this.binaryCode.Substring(0, 8);
        }
    }
}
