using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuDioSeries.Dominio.Interface
{
    public interface IServicoBase<T>
    {
        Task AddAsync(T obj);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task UpdateAsync(T obj);
    }
}
