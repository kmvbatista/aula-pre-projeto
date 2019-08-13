using DataTypeObject.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPresentationLayer.Models
{
    public class ProdutoViewModel
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Descricao{ get; set; }
        public double Preco { get; set; }
        public double Estoque{ get; set; }
        public UnidadeMedida UnidadeDeMedida { get; set; }

    }

  


}