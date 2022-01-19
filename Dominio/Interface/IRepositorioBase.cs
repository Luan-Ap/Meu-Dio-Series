using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuDioSeries.Dominio.Interface
{
    public interface IRepositorioBase<T>
    {
        Task AddAsync(T obj);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task UpdateAsync(T obj);
    }
}
