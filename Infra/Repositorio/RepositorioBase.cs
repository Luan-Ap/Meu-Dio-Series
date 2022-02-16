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

        public async Task AddAsync(T obj)
        {
            context.Set<T>().Add(obj);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var objects = await context.Set<T>().AsNoTracking().ToListAsync();
            return objects;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var obj = await context.Set<T>().FindAsync(id);
            return obj;
        }

        public async Task UpdateAsync(T obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
