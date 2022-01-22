using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuDioSeries.Dominio.Entidades
{
    public class GeneroViewModel
    {
        [Key]
        public int GeneroId { get; set; }

        public string Nome { get; set; }
        public ICollection<Serie> Series { get; set; }
    }
}
