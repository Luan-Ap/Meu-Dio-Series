using System.Collections.Generic;

namespace Dominio.Interface
{
    public interface ISerieRepositorio<T>
    {
        void Add(T obj);
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Update(T obj);
        void Remove(T obj);
    }
}
