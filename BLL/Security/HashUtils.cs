using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Security
{
    class HashUtils
    {
        public static string HashPassword(string password)
        {
            string initialSalt = "b147V2";
            string finalSalt = "cw@6492";
            password = initialSalt + password + finalSalt;
            MD5 md5 = MD5.Create();
            byte[] senhaEncodada = Encoding.UTF8.GetBytes(password);
            byte[] senhaHasheada = md5.ComputeHash(senhaEncodada);
            string senhaCompleta = Convert.ToBase64String(senhaHasheada);
            if (senhaCompleta.Length > 30)
            {
                senhaCompleta = senhaCompleta.Substring(0, 30);
            }
            return senhaCompleta;
        }
    }
}
