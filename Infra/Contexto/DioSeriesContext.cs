using MeuDioSeries.Dominio.Entidades;
using MeuDioSeries.Infra.EntityConfiguration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MeuDioSeries.Infra.Contexto
{
    public class DioSeriesContext : DbContext
    {
        //Adicione aqui sua string de conexão.
        //Caso queira seguir o mesmo modelo, terá que criar a pasta App_Data no projeto onde está seu contexto.
        public DioSeriesContext()
            : base(@"Data Source=(localdb)\MSSQLLocalDB; AttachDbFilename=C:\DioSeriesV2\MeuDioSeries\Infra\App_Data\MeuDioSeriesDB.mdf; Initial Catalog=MeuDioSeriesDB; Integrated Security=True")
        {

        }

        public DbSet<Serie> Series { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Aqui é removido a pluralização automática feita pelo Entityframework
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Aqui é removido o efeito cascata ao excluir algum registro
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //Aqui definimos algumas configurações padrão para as entidades
            //Todo campo que tiver Nome + Id se trata de chave primária (Ex: SerieId) 
            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            //Toda propriedade do tipo string deve ser tratada como varchar no BD
            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            //O comprimento máximo de um campo será 100
            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            //Aqui adicionamos uma configuração personalizada, definida na classe SeriesConfig
            modelBuilder.Configurations.Add(new SeriesConfig());
        }
    }
}
