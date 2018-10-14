using System;
using System.Collections.Generic;
using System.Web;

namespace WebApplication
{
    public class Encrypted
    {
        
        public string StringEncoding(string pwd)
        {
            char[] arrChar = pwd.ToCharArray();
            string strChar = "";
            for (int i = 0; i < arrChar.Length; i++)
            {
                arrChar[i] = Convert.ToChar(arrChar[i] + 40);
                strChar = strChar + arrChar[i].ToString();
            }
            return strChar;
        }

       public string StringDecoding(string pwd)
        {
            char[] arrChar = pwd.ToCharArray();
            string strChar = "";
            for (int i = 0; i < arrChar.Length; i++)
            {
                arrChar[i] = Convert.ToChar(arrChar[i] - 40);
                strChar = strChar + arrChar[i].ToString();
            }
            return strChar;
        }
    }
}
