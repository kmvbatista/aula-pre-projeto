using BLL.Extensions;
using DataAccessLayer;
using DataTypeObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL
{
    public class ClienteBLL
    {
        List<ErrorField> erros = new List<ErrorField>();

        public void Inserir(Cliente cliente)
        {
            if (string.IsNullOrWhiteSpace(cliente.CPF))
            {
                ErrorField error = new ErrorField()
                {
                    Error = "CPF deve ser informado.",
                    PropertyName = "CPF"
                };
                erros.Add(error);
            }
            else if (!cliente.CPF.IsValidCPF())
            {
                ErrorField error = new ErrorField()
                {
                    Error = "CPF inválido.",
                    PropertyName = "CPF"
                };
                erros.Add(error);
            }
            if (string.IsNullOrWhiteSpace(cliente.Nome))
            {
                ErrorField error = new ErrorField()
                {
                    Error = "Nome deve ser informado.",
                    PropertyName = "Nome"
                };
                erros.Add(error);
            }
            else if (cliente.Nome.Length < 3 || cliente.Nome.Length > 70)
            {
                ErrorField error = new ErrorField()
                {
                    Error = "Nome deve conter entre 3 e 70 caracteres.",
                    PropertyName = "Nome"
                };
                erros.Add(error);
            }
            if (string.IsNullOrWhiteSpace(cliente.Email))
            {
                ErrorField error = new ErrorField()
                {
                    Error = "Email deve ser informado.",
                    PropertyName = "Email"
                };
                erros.Add(error);
            }
            else if (!Regex.IsMatch(cliente.Email, @"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$"))
            {
                ErrorField error = new ErrorField()
                {
                    Error = "Email inválido.",
                    PropertyName = "Email"
                };
                erros.Add(error);
            }
            if (DateTime.Now.Subtract(cliente.DataNascimento).TotalDays < 6574)
            {
                ErrorField error = new ErrorField()
                {
                    Error = "Apenas maiores de 18 anos podem se cadastrar.",
                    PropertyName = "DataNascimento"
                };
                erros.Add(error);

            }
            if (string.IsNullOrWhiteSpace(cliente.Telefone))
            {
                ErrorField error = new ErrorField()
                {
                    Error = "Telefone deve ser informado.",
                    PropertyName = "Telefone"
                };
                erros.Add(error);
            }
            else if (cliente.Telefone.Length < 7 || cliente.Telefone.Length > 15)
            {
                ErrorField error = new ErrorField()
                {
                    Error = "Telefone deve conter entre 7 e 15 caracteres.",
                    PropertyName = "Telefone"
                };
                erros.Add(error);
            }

            if (erros.Count != 0)
            {
                throw new HotelException(erros);
            }

            //Se chegou aqui, jogar no banco!
            using (HotelContext ctx = new HotelContext())
            {
                ctx.Clientes.Add(cliente);
                ctx.SaveChanges();
            }
        }
    }
}
