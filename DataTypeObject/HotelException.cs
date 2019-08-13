using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypeObject
{

    [Serializable]
    public class HotelException : Exception
    {
        public List<ErrorField> Errors { get; private set; }
        public HotelException(List<ErrorField> errors)
        {
            this.Errors = errors;
        }
        public string GetErrorMessage()
        {
            StringBuilder sb = new StringBuilder();
            foreach (ErrorField error in Errors)
            {
                sb.AppendLine(error.Error);
            }
            return sb.ToString();
        }
        public HotelException() { }
        public HotelException(string message) : base(message) { }
        public HotelException(string message, Exception inner) : base(message, inner) { }
        //BinaryFormatter - .Net Remoting
        protected HotelException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
