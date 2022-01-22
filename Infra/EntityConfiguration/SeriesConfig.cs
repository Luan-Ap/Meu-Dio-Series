using MeuDioSeries.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace MeuDioSeries.Infra.EntityConfiguration
{
    //Esta classe serve para definirmos uma configuração particular para a entidade Series
    //Ela irá sobrepor a configuração padrão
    class SeriesConfig : EntityTypeConfiguration<Serie>
    {
        public SeriesConfig()
        {
            //Definimos que essa propriedade se trata de uma chave primária
            HasKey(s => s.SerieId);

            Property(s => s.Titulo)
                .IsRequired() //Definimos que a propriedade Titulo é obrigatória
                .HasMaxLength(150);//e que sua capacidade máxima é 150

            Property(s => s.Descricao)
                .IsRequired()
                .HasMaxLength(250);

            Property(s => s.AnoLancamento)
                .IsRequired();

            Property(s => s.Excluida)
                .IsRequired();

            Property(s => s.GeneroId)
                .IsRequired();

            //Definimos um relacionamento de 1 para N entre as tabelas Series e Generos
            HasRequired(s => s.Genero) //Onde uma série está ligada a um gênero
                .WithMany(g => g.Series) //E um gênero pode estar ligado a várias séries
                .HasForeignKey(s => s.GeneroId); //Definimos que a propriedade GeneroId se trata da chave estrangeira
        }
    }
}
