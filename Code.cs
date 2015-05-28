using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIPS
{
    //class for identifying binary codes
    public class Code
    {
        private const String DATA_TRANSFER = "0001";
        private const String ARITHMETIC = "0010";
        private const String COMPARISON = "0011";
        private const String LOGIC = "0100";
        private const String PROGRAM_FLOW = "0101";

        private const String GEN_REGISTER = "1000";
        private const String ADD_REGISTER = "1001";

        private const String LOD = "0001";
        private const String STR = "0010";
        private const String SAV = "0011";

        private const String INC = "0001";
        private const String DEC = "0010";
        private const String ADD = "0011";
        private const String SUB = "0100";
        private const String MUL = "0101";
        private const String DIV = "0110";

        private const String CMP = "0001";

        private const String AND = "0001";
        private const String OR =  "0010";
        private const String NOT = "0011";
        private const String XOR = "0100";

        private const String IFE = "0001";
        private const String IFG = "0010";
        private const String IFL = "0011";
        private const String FLY = "0100";

        private const String R0 = "0001";
        private const String R1 = "0010";
        private const String R2 = "0011";
        private const String R3 = "0100";
        private const String R4 = "0101";
        private const String R5 = "0101";
        private const String R6 = "0111";
        private const String R7 = "1000";

        private const String MAR0 = "0001";
        private const String MAR1 = "0010";


        //encapsulate constructor
        private Code(){}

        public static String getCode(String keyword){
            switch (keyword)
            {
                case "LOD": return DATA_TRANSFER + LOD;
                case "STR": return DATA_TRANSFER + STR;
                case "SAV": return DATA_TRANSFER + SAV;

                case "INC": return ARITHMETIC + INC;
                case "DEC": return ARITHMETIC + DEC;
                case "ADD": return ARITHMETIC + ADD;
                case "SUB": return ARITHMETIC + SUB;
                case "MUL": return ARITHMETIC + MUL;
                case "DIV": return ARITHMETIC + DIV;

                case "CMP": return COMPARISON + CMP;

                case "AND": return LOGIC + AND;
                case "OR":  return LOGIC + OR;
                case "NOT": return LOGIC + NOT;
                case "XOR": return LOGIC + XOR;

                case "IFE": return PROGRAM_FLOW + IFE;
                case "IFL": return PROGRAM_FLOW + IFL;
                case "IFG": return PROGRAM_FLOW + IFG;
                case "FLY": return PROGRAM_FLOW + FLY;

                case "R0": return GEN_REGISTER + R0;
                case "R1": return GEN_REGISTER + R1;
                case "R2": return GEN_REGISTER + R2;
                case "R3": return GEN_REGISTER + R3;
                case "R4": return GEN_REGISTER + R4;
                case "R5": return GEN_REGISTER + R5;
                case "R6": return GEN_REGISTER + R6;
                case "R7": return GEN_REGISTER + R7;

                case "MAR0": return ADD_REGISTER + MAR0;
                case "MAR1": return ADD_REGISTER + MAR1;

                default:
                    return null;
            }
        }

        public static String getInstructionType(String instructionCode)
        {

            switch (instructionCode.Substring(0,4))
            {
                case "0001": return "DATA TRANSFER";
                case "0010": return "ARITHMETIC";
                case "0011": return "COMPARISON";
                case "0100": return "LOGIC";
                case "0101": return "PROGRAM FLOW";

                case "1000": return "GENERAL PURPOSE REGISTER";
                case "1001": return "ADDRESS REGISTER";

                default:
                    return null;
            }
        }
    }
}
