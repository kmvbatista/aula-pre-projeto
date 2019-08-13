using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypeObject
{
    public class Usuario
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password{ get; set; }
        public bool IsAdm { get; set; }

        public override string ToString()
        {
            return ID + "," + UserName;
        }

        public static Usuario Parse(string text)
        {
            Usuario user = new Usuario();
            string[] data = text.Split(',');
            user.ID = int.Parse(data[0]);
            user.UserName = data[1];
            return user;
        }
    }
}
