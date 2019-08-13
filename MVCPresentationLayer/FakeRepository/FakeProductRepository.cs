using MVCPresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPresentationLayer.FakeRepository
{
    public class FakeProducttRepository
    {
        //Lista static para ela sobreviver entre as requisições.
        //Entretanto, em um ambiente real, o proprio servidor
        //reseterá o valor das variáveis (até as statics) 
        private static List<ProdutoViewModel> produtos =
                   new List<ProdutoViewModel>();

        public static void Add(ProdutoViewModel produto)
        {
            if (produtos.Count == 0)
            {
                produto.ID = 1;
            }
            else
            {
                produto.ID = produtos.Last().ID + 1;
            }
            produtos.Add(produto);
        }

        public static List<ProdutoViewModel> GetAll()
        {
            return produtos;
        }

        public static void Edit(ProdutoViewModel produto)
        {
            foreach (ProdutoViewModel item in produtos)
            {
                if (item.ID == produto.ID)
                {
                    item.Nome = produto.Nome;
                    item.Descricao = produto.Descricao;
                    item.Estoque = produto.Estoque;
                    item.Preco = produto.Preco;
                    item.UnidadeDeMedida= produto.UnidadeDeMedida;
                }
            }
        }

        public static void Delete(int id)
        {
            for (int i = 0; i < produtos.Count; i++)
            {
                if (produtos[i].ID == id)
                {
                    produtos.RemoveAt(i);
                    return;
                }
            }
        }

    }
}