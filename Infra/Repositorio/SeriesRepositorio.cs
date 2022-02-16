using MeuDioSeries.Dominio.Entidades;
using MeuDioSeries.Dominio.Interface;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;

namespace MeuDioSeries.Infra.Repositorio
{
    public class SeriesRepositorio : RepositorioBase<Serie>, ISerieRepositorio
    {
        public async Task RemoveAsync(Serie serie)
        {
            context.Set<Serie>().AddOrUpdate(serie);

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Serie>> GetAllSeriesNaoExcluidasAsync()
        {
            //Utilizamos o método de extensão Include para que o EntityFramework carregue os dados do Gênero relacionado às Séries
            var series = await context.Series.AsNoTracking().Include(s => s.Genero).Where(s => s.Excluida == false).ToListAsync();
            return series;
        }

        public async Task<Serie> GetSerieNaoExcluidaByIdAsync(int id)
        {
            var serie = await context.Series.AsNoTracking().Include(s => s.Genero).Where(s => s.Excluida == false && s.SerieId == id).FirstOrDefaultAsync();
            return serie;
        }

        public async Task<IEnumerable<Serie>> GetSeriesByTitleAsync(string nome)
        {
            var series = await context.Series.AsNoTracking().Include(s => s.Genero).Where(s => s.Titulo.Contains(nome)).ToListAsync();

            return series;
        }
    }
}
