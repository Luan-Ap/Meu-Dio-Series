using MeuDioSeries.Dominio.Interface;
using MeuDioSeries.Infra.Contexto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuDioSeries.Infra.Repositorio
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T : class
    {
        protected DioSeriesContext context = new DioSeriesContext();

        public void Add(T obj)
        {
            context.Set<T>().Add(obj);
            context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            var objects = context.Set<T>().ToList();
            return objects;
        }

        public T GetById(int id)
        {
            var obj = context.Set<T>().Find(id);
            return obj;
        }

        public void Update(T obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
