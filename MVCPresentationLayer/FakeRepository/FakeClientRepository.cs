using MVCPresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPresentationLayer.FakeRepository
{
    public class FakeClientRepository
    {
        //Lista static para ela sobreviver entre as requisições.
        //Entretanto, em um ambiente real, o proprio servidor
        //reseterá o valor das variáveis (até as statics) 
        private static List<ClienteViewModel> clientes =
                   new List<ClienteViewModel>();

        public static void Add(ClienteViewModel cliente)
        {
            if (clientes.Count == 0)
            {
                cliente.ID = 1;
            }
            else
            {
                cliente.ID = clientes.Last().ID + 1;
            }
            clientes.Add(cliente);
        }

        public static List<ClienteViewModel> GetAll()
        {
            return clientes;
        }

        public static void Edit(ClienteViewModel cliente)
        {
            foreach (ClienteViewModel item in clientes)
            {
                if (item.ID == cliente.ID)
                {
                    item.Nome = cliente.Nome;
                    item.Email = cliente.Email;
                    item.Telefone = cliente.Telefone;
                    item.CPF = cliente.CPF;
                    item.DataNascimento = cliente.DataNascimento;
                }
            }
        }

        public static void Delete(int id)
        {
            for (int i = 0; i < clientes.Count; i++)
            {
                if (clientes[i].ID == id)
                {
                    clientes.RemoveAt(i);
                    return;
                }
            }
        }

    }
}