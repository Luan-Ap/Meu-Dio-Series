

namespace MeuDioSeries.Dominio.Entidades
{
    //Aqui definimos a entidade Serie e suas propriedades
    public class Serie
    {
        public int SerieId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int AnoLancamento { get; set; }
        public bool Excluida { get; set; }
        public int GeneroId { get; set; }
        public Genero Genero { get; set; }

        public override string ToString()
        {
            return $"Gênero: {Genero.Nome}\n" +
                   $"Título: {Titulo}\n" +
                   $"Descrição: {Descricao}\n" +
                   $"Ano de Início: {AnoLancamento}";
        }
    }
}
