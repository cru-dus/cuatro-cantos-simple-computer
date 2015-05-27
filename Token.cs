using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIPS
{
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

        public Token(byte token, String classification)
        {
            this.token = token.ToString();
            this.classification = classification;
            if (classification.Equals("DATA"))
            {
                this.code = Convert.ToString(token, 2);
            }
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
