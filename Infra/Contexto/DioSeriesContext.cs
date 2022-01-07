using MeuDioSeries.Dominio.Entidades;
using MeuDioSeries.Infra.EntityConfiguration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MeuDioSeries.Infra.Contexto
{
    public class DioSeriesContext : DbContext
    {
        public DioSeriesContext()
            : base(@"Data Source=(localdb)\MSSQLLocalDB; AttachDbFilename=C:\DioSeriesV2\MeuDioSeries\Infra\App_Data\MeuDioSeriesDB.mdf; Initial Catalog=MeuDioSeriesDB; Integrated Security=True")
        {

        }

        public DbSet<Serie> Series { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new SeriesConfig());
        }
    }
}
