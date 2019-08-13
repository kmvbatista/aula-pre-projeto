using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypeObject
{
    //Representar um erro no sistema
    public class ErrorField
    {
        public string PropertyName{ get; set; }
        public string Error { get; set; }
        public Exception Exception { get; set; }
    }
}
