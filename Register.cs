﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIPS
{
    //unused class. suppposed to be used for implementing the instructions
    class Register
    {
        private byte value;
        private byte binCode;
        private Boolean available;

        public Register()
        {
            this.available = true;
            setValue(0);
        }

        public void setValue(byte value)
        {
            this.value = value;
        }

        public void setBinCode(byte binCode)
        {
            this.binCode = binCode;
        }

        public void setAvailable(Boolean isAvailable)
        {
            this.available = isAvailable;
        }

        public Boolean isAvailable()
        {
            return this.available;
        }

        public static String getEightBitBinCode(int bincode)
        {
            String s = Convert.ToString(bincode, 2);
            if (s.Length > 8) s = s.Substring(s.Length - 8, 8);
            else if (s.Length < 8)
            {
                String pre = "";
                for (int i = 0; i < 8 - s.Length; i++) pre += "0";
                s = pre + s;
            }
            return s;
        }
    }
}
