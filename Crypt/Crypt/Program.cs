using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypt
{
    class Program
    {
        public static string Key = "limx->oo(1+(1/x))^x=e";

        static void Main(string[] args)
        {
            byte[] buffer = new byte[4];
            float number = (float)-2.5;
            uint d = (uint)number;

            buffer[0] = (byte)(d & 0x000F);
            buffer[1] = (byte)((d & 0x00F0) >> 8);
            buffer[2] = (byte)((d & 0x0F00) >> 16);
            buffer[3] = (byte)((d & 0xF000) >> 24);

            uint f = (uint)(buffer[0] << 24 | buffer[1] << 16 | buffer[2] << 8 | buffer[3]);

            float g = (float)f;

            string Password = "toscolinoahdghgjfhfadhsgfjgfhadfhagfhahrty";
            string CryptedPassword = Crypt(Password);
            string DecryptedPassword = Decrypt(CryptedPassword);
        }

        static string Crypt(string Password)
        {
            string CryptedPassword = string.Empty;

            for (int i = 0, j = 0; i < Password.Length; i++,j++)
            {
                if (j == Key.Length)
                {
                    j = 0;
                }

                CryptedPassword += Convert.ToChar(Password[i] * Key[j]);
            }

            return CryptedPassword;
        }

        static string Decrypt(string CryptedPassword)
        {
            string Password = string.Empty;

            for (int i = 0, j = 0; i < CryptedPassword.Length; i++, j++)
            {
                if (j == Key.Length)
                {
                    j = 0;
                }

                Password += Convert.ToChar(CryptedPassword[i] / Key[j]);
            }

            return Password;
        }
    }
}
