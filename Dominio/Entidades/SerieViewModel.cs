using MeuDioSeries.Dominio.Enum;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MeuDioSeries.Dominio.Entidades
{
    //Aqui definimos uma ViewModel da entidade Serie
    //Ela é composta com algumas DataAnnotations para auxiliar na validação do modelo
    public class SerieViewModel
    {
        [Key]
        public int SerieId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O Campo Título é obrigatório")]
        [MaxLength(150, ErrorMessage = "Máximo: 150 caracteres")]
        [MinLength(1, ErrorMessage = "Mínimo: 1 caracter")]
        [DisplayName("Título")]
        public string Titulo { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O Campo Descrição é obrigatório")]
        [MaxLength(250, ErrorMessage = "Máximo: 250 caracteres")]
        [MinLength(1, ErrorMessage = "Mínimo: 5 caracter")]
        [DataType(DataType.MultilineText)]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O Campo Ano de Lançamento é obrigatório")]
        [Range(1970, 2050, ErrorMessage = "O Ano de Lançamento deve estar entre 1970 e 2050")]
        [DisplayName("Ano de Lançamento")]
        public int AnoLancamento { get; set; }

        [ScaffoldColumn(false)]
        public bool Excluida { get; set; }

        [Required(ErrorMessage = "O Campo Gênero é obrigatório")]
        [DisplayName("Gênero")]
        public Genero Genero { get; set; }
    }
}
