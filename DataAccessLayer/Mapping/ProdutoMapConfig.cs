using DataTypeObject;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mapping
{
    class ProdutoMapConfig : EntityTypeConfiguration<Produto>
    {
        public ProdutoMapConfig()
        {
            //Nomeia a tabela, sobrescrevendo a convenção nativa de a tabela
            //ter o mesmo nome da classe (ja removemos a convenção da pluralização)
            this.ToTable("PRODUTOS");
            //ANTES
            //NOME NVARCHAR (MAX) NULL,
            //DEPOIS
            //NOME VARCHAR(50) NOT NULL
            this.Property(p => p.Nome).HasMaxLength(50);
            this.Property(p => p.Descricao).HasMaxLength(100);
        }


    }
}
