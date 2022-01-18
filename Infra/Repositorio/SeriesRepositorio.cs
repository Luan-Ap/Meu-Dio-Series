using MeuDioSeries.Dominio.Entidades;
using MeuDioSeries.Dominio.Interface;
using MeuDioSeries.Infra.Contexto;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Data.Entity.Migrations;

namespace MeuDioSeries.Infra.Repositorio
{
    public class SeriesRepositorio : RepositorioBase<Serie>, ISerieRepositorio
    {
        public IEnumerable<Serie> GetAllSeriesNaoExcluidas()
        {
            var series = context.Series.Where(s => s.Excluida == false).ToList();
            return series;
        }

        public Serie GetSerieNaoExcluidaById(int id)
        {
            var serie = context.Series.Where(s => s.Excluida == false && s.SerieId == id).FirstOrDefault();
            return serie;
        }

        public void Remove(Serie serie)
        {
            context.Set<Serie>().AddOrUpdate(serie);

            context.SaveChanges();
        }
    }
}
