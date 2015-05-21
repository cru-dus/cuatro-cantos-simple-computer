using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    class Command
    {
        private String instruction;
        private String arg1;
        private String arg2;

        public Command(String instruction, String arg1, String arg2)
        {
            this.instruction = instruction;
            this.arg1 = arg1;
            this.arg2 = arg2;
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
    }
}
