using MeuDioSeries.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuDioSeries.Dominio.Interface
{
    public interface ISerieService : IServicoBase<SerieViewModel>
    {
        Task RemoveAsync(SerieViewModel obj);

        Task<IEnumerable<SerieViewModel>> GetSeriesByTitleAsync(string nome);
    }
}
