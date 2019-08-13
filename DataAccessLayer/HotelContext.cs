using DataAccessLayer.Mapping;
using DataTypeObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class HotelContext : DbContext
    {
        //Método que determina como a base é criada de acordo com os DbSets registrados
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Criação da configuração global que diz que as strings gerarão VARCHAR NOT NULL
            modelBuilder.Properties()
                        .Where(c => c.PropertyType == typeof(string))
                        .Configure(c => c.IsRequired().IsUnicode(false));

            //Criação da configuração global que determina o comportamento padrão do campo CPF
            //CHAR(11)
            modelBuilder.Properties()
                        .Where(c => c.PropertyType == typeof(string) && c.Name.ToUpper() == "CPF")
                        .Configure(c => c.IsFixedLength().HasMaxLength(11));


            //Criação da configuração global que determina o comportamento padrão do campo CNPJ
            //CHAR(14)
            modelBuilder.Properties()
                        .Where(c => c.PropertyType == typeof(string) && c.Name.ToUpper() == "CNPJ")
                        .Configure(c => c.IsFixedLength().HasMaxLength(14));


            //Criação da configuração global que determina o comportamento padrão do campo Email
            //VARCHAR(70)
            modelBuilder.Properties()
                        .Where(c => c.PropertyType == typeof(string) && c.Name.ToUpper() == "EMAIL")
                        .Configure(c => c.HasMaxLength(70));

            //Criação da configuração global que determina o comportamento padrão do campo Telefone
            //VARCHAR(15)
            modelBuilder.Properties()
                        .Where(c => c.PropertyType == typeof(string) && c.Name.ToUpper().Contains("TELEFONE"))
                        .Configure(c => c.HasMaxLength(15));


            modelBuilder.Properties()
                        .Where(c => c.PropertyType == typeof(DateTime))
                        .Configure(c => c.IsRequired().HasColumnType("datetime2"));

            //Como criar convenção de Handle como chave primária de identidade
            //modelBuilder.Properties()
            //          .Where(c => c.PropertyType == typeof(int) && c.Name == "Handle").Configure(c => c.IsKey().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity));
            //          //Ignora a técnica de Pluralização de nomes das tabelas
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //Adicionar todos os maps configs do projeto DAL
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());

            //Chamada padrão de criação da base
            base.OnModelCreating(modelBuilder);
        }

        public HotelContext() : base(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\moc\Documents\Hotel.mdf;Integrated Security=True;Connect Timeout=30")
        {
            //USADO APENAS PARA AMBIENTE DE DESENVOLVIMENTO
            //APAGAR OU COMENTAR ESTA LINHA ANTES DE JOGAR O CÓDIGO PRA PRODUÇÃO
            Database.SetInitializer(new HotelDbStrategy());
        }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Usuario> Usuarios{ get; set; }

    }
    //Exemplo de API fluente
    class Carro
    {
        public int KM { get; private set; }
        public string Marca { get; private set; }
        public int HP { get; private set; }

        public Carro SetKM(int km)
        {
            this.KM = km;
            return this;
        }
        public Carro SetMarca(string marca)
        {
            this.Marca = marca;
            return this;
        }
        public Carro SetHP(int hp)
        {
            this.HP = hp;
            return this;
        }
    }
    class MyClass
    {
        public MyClass()
        {
            Carro c = new Carro();
            c.SetKM(55000).SetHP(140).SetMarca("Fiat");
        }
    }
}
