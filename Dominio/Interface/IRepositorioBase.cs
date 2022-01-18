using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuDioSeries.Dominio.Interface
{
    public interface IRepositorioBase<T>
    {
        void Add(T obj);
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Update(T obj);
    }
}
