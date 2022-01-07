using System.ComponentModel.DataAnnotations;

namespace MeuDioSeries.Dominio.Enum
{
    public enum Genero
    {
        [Display(Name = "Ação")]
        Acao = 1,
        Aventura = 2,
        [Display(Name = "Comédia")]
        Comedia = 3,
        [Display(Name = "Documentário")]
        Documentario = 4,
        Drama = 5,
        Espionagem = 6,
        Faroeste = 7,
        Fantasia = 8,
        [Display(Name = "Ficção Científica")]
        Ficcao_Cientifica = 9,
        Musical = 10,
        Roamnce = 11,
        Suspense = 12,
        Terror = 13
    }
}
