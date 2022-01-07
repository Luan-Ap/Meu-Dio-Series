using MeuDioSeries.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace MeuDioSeries.Infra.EntityConfiguration
{
    class SeriesConfig : EntityTypeConfiguration<Serie>
    {
        public SeriesConfig()
        {
            HasKey(s => s.SerieId);

            Property(s => s.Titulo)
                .IsRequired()
                .HasMaxLength(150);

            Property(s => s.Descricao)
                .IsRequired()
                .HasMaxLength(250);

            Property(s => s.AnoLancamento)
                .IsRequired();

            Property(s => s.Excluida)
                .IsRequired();

            Property(s => s.Genero)
                .IsRequired();
        }
    }
}
