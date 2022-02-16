using MeuDioSeries.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuDioSeries.Dominio.Interface
{
    public interface ISerieRepositorio : IRepositorioBase<Serie>
    {
        Task<Serie> GetSerieNaoExcluidaByIdAsync(int id);
        Task<IEnumerable<Serie>> GetAllSeriesNaoExcluidasAsync();
        Task<IEnumerable<Serie>> GetSeriesByTitleAsync(string nome);
        Task RemoveAsync(Serie serie);
    }
}
