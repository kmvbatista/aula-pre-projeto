using DataTypeObject;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mapping
{
    class FornecedorMapConfig : EntityTypeConfiguration<Fornecedor>
    {
        public FornecedorMapConfig()
        {
            this.ToTable("FORNECEDORES");
            this.Property(f => f.NomeFantasia).HasMaxLength(60);
            this.Property(f => f.RazaoSocial).HasMaxLength(100);
            this.Property(f => f.Contato).HasMaxLength(50);

        }
    }
}
