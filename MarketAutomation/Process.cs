using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
namespace MarketAutomation
{
    public class Process
    {

        public string MD5Password(string password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] byteArray = Encoding.UTF8.GetBytes(password);
            byteArray = md5.ComputeHash(byteArray);
            StringBuilder stringBuilder = new StringBuilder();

            foreach(byte b in byteArray)
            {
                stringBuilder.Append(b.ToString("x2").ToLower());
            }

            return stringBuilder.ToString();
        }

    }
}
