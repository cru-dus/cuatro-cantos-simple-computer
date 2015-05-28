using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIPS
{
    //class for the tokens
    class Token
    {
        private String token;
        private String classification;
        private String code;

        public Token(String token)
        {
            this.token = token;
            this.code = Code.getCode(this.token);
            this.classification = Code.getInstructionType(this.code.Substring(0, 4));
            
        }

        //constructor for data
        public Token(byte token, String classification)
        {
            this.token = token.ToString();
            this.classification = classification;
            if (classification.Equals("DATA"))
            {
                this.code = Convert.ToString(token, 2);
            }
        }

        //constructor for label
        public Token(String token, String classification, int x)
        {
            this.token = token;
            this.classification = classification;
            this.code = Register.getEightBitBinCode(x);
        }

        public String getToken()
        {
            return this.token;
        }

        public String getClassification()
        {
            return this.classification;
        }

        public String getCode()
        {
            return this.code;
        }
    }
}
