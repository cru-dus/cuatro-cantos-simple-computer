using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    class Token
    {
        private String token;
        private String classification;
        private String code;

        public Token(String token, String classification, String code)
        {
            this.token = token;
            this.classification = classification;
            this.code = code;
        }

        public String getToken()
        {
            return this.token;
        }

        public String getClass()
        {
            return this.classification;
        }

        public String getCode()
        {
            return this.code;
        }
    }
}
