using DataTypeObject;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mapping
{
    class UsuarioMapConfig : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMapConfig()
        {
            this.ToTable("USUARIOS");
            this.Property(u => u.UserName).HasMaxLength(30);
            this.Property(u => u.Password).HasMaxLength(30);
        }
    }
}
