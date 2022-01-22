using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuDioSeries.Dominio.Entidades
{
    public class Genero
    {
        public int GeneroId { get; set; }
        public string Nome { get; set; }
        public ICollection<Serie> Series { get; set; }
    }
}
