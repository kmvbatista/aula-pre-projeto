using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MVCPresentationLayer.WEB
{

    public class CustomAutoMapper<T, W>
    {
        public static W Map(T item)
        {
            PropertyInfo[] propertiesT = typeof(T).GetProperties();
            Type typeW = typeof(W);
            W w = Activator.CreateInstance<W>();
            foreach (PropertyInfo property in propertiesT)
            {
                try
                {
                    //cliente.Nome = clienteViewModel.Nome;
                    typeW.GetProperty(property.Name).SetValue(w, property.GetValue(item));
                }
                catch
                {
                    //POG
                }
            }
            return w;
        }
    }
}