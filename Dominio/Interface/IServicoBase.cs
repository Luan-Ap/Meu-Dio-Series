using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuDioSeries.Dominio.Interface
{
    public interface IServicoBase<T>
    {
        Task Add(T obj);
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task Update(T obj);
        Task Remove(T obj);
    }
}
