using DataTypeObject.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypeObject
{
    public class Produto
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Descricao{ get; set; }
        public int FornecedorID { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
        public double Preco { get; set; }
        public double Estoque { get; set; }
        public UnidadeMedida UnidadeMedida { get; set; }

    }
}
