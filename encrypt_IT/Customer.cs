using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace encrypt_IT
{
    public class Customer
    {
        int process;
        int choosenmethod;
        int? textsize;

        public Customer(int p, int c, int? t)
        {
            this.process = p;
            this.choosenmethod = c;
            this.textsize = t;
        }

        public int Process
        {
            get
            {
                return this.process;
            }
        }

        public int ChoosenMethod
        {
            get
            {
                return this.choosenmethod;
            }
        }

        public string caseMethod()
        {
            switch (this.choosenmethod)
            {
                case 1: return "3DES";
                case 2: return "AES";
                case 3: return "Blowfish";
                case 4: return "Twofish";
                case 5: return "IDEA";
                case 6: return "MD5";
                case 7: return "SHA 1";
                case 8: return "HMAC";
                case 9: return "RSA Security: RC4";
                default: return "";
            }
        }
    }
}