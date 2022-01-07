using System.Collections.Generic;

namespace MeuDioSeries.Dominio.Interface
{
    public interface ISerieService<T>
    {
        void Add(T obj);
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Update(T obj);
        void Remove(T obj);
    }
}
