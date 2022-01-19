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
    public class SeriesRepositorio : RepositorioBase<Serie>, ISerieRepositorio
    {
        //public IEnumerable<Serie> GetAllSeriesNaoExcluidasAsync()
        //{
        //    var series = context.Series.Where(s => s.Excluida == false).ToList();
        //    return series;
        //}

        //public Serie GetSerieNaoExcluidaByIdAsync(int id)
        //{
        //    var serie = context.Series.Where(s => s.Excluida == false && s.SerieId == id).FirstOrDefault();
        //    return serie;
        //}

        //public void Remove(Serie serie)
        //{
        //    context.Set<Serie>().AddOrUpdate(serie);

        //    context.SaveChanges();
        //}

        public async Task RemoveAsync(Serie serie)
        {
            context.Set<Serie>().AddOrUpdate(serie);

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Serie>> GetAllSeriesNaoExcluidasAsync()
        {
            var series = await context.Series.Where(s => s.Excluida == false).ToListAsync();
            return series;
        }

        public async Task<Serie> GetSerieNaoExcluidaByIdAsync(int id)
        {
            var serie = await context.Series.Where(s => s.Excluida == false && s.SerieId == id).FirstOrDefaultAsync();
            return serie;
        }
    }
}
