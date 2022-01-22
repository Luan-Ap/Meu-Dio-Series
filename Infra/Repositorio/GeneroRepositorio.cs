using MeuDioSeries.Dominio.Entidades;
using MeuDioSeries.Dominio.Interface;
using MeuDioSeries.Infra.Contexto;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;

namespace MeuDioSeries.Infra.Repositorio
{
    public class GeneroRepositorio : RepositorioBase<Genero>, IGeneroRepositorio
    {

    }
}
