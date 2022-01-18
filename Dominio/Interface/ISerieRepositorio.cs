using MeuDioSeries.Dominio.Entidades;
using System.Collections.Generic;

namespace MeuDioSeries.Dominio.Interface
{
    public interface ISerieRepositorio : IRepositorioBase<Serie>
    {
       // void Add(T obj);
        Serie GetSerieNaoExcluidaById(int id);
        IEnumerable<Serie> GetAllSeriesNaoExcluidas();
       // void Update(T obj);
        void Remove(Serie serie);
    }
}
