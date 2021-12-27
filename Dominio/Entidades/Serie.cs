using Dominio.Enum;

namespace Dominio.Entidades
{
    public class Serie
    {
        public int SerieId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int AnoLancamento { get; set; }
        public bool Excluida { get; set; }
        public Genero Genero { get; set; }

        public override string ToString()
        {
            return $"Gênero: {Genero}\n" +
                   $"Título: {Titulo}\n" +
                   $"Descrição: {Descricao}\n" +
                   $"Ano de Início: {AnoLancamento}";
        }
    }
}
