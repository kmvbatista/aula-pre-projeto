using DataTypeObject;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mapping
{
    class ClienteMapConfig : EntityTypeConfiguration<Cliente>
    {
        public ClienteMapConfig()
        {
            this.ToTable("CLIENTES");
            //NOME VARCHAR(70) NOT NULL
            this.Property(p => p.Nome).HasMaxLength(70);
            this.Property(p => p.Email).HasMaxLength(70);
            this.Property(p => p.Telefone).HasMaxLength(15);

        }


    }
}
