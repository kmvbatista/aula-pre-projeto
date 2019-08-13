using DataTypeObject;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    class HotelDbStrategy : DropCreateDatabaseIfModelChanges<HotelContext>
    {
        protected override void Seed(HotelContext context)
        {
            using(HotelContext ctx = new HotelContext())
            {
                Cliente c = new Cliente();
                c.Nome = "Ricardo Baader Schmidt";
                c.Telefone = "47999994499";
                c.Email = "ricardo.schmidt@gmail.com";
                c.DataNascimento = new DateTime(2003, 4, 11);
                c.CPF = "90191706949";
                ctx.Clientes.Add(c);

                Fornecedor f = new Fornecedor();
                f.CNPJ = "12345678901234";
                f.Contato = "Davi";
                f.Email = "maxcigarreted@gmail.com";
                f.NomeFantasia = "Max Cigarettes";
                f.RazaoSocial = "Max Cigarettes Ltda";
                f.Telefone = "4730351099";

                Produto p = new Produto();
                p.Nome = "Carlton Red Box";
                p.Preco = 12;
                p.UnidadeMedida = DataTypeObject.Enums.UnidadeMedida.Unitario;
                p.Estoque = 100;
                p.Descricao = "Morte Lenta";
                p.Fornecedor = f;

                ctx.Fornecedores.Add(f);
                ctx.Produtos.Add(p);

                ctx.SaveChanges();

            }
            base.Seed(context);
        }
    }
}
