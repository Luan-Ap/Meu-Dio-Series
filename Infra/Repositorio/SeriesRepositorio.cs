﻿using Dominio.Entidades;
using Dominio.Interface;
using Infra.Contexto;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Infra.Repositorio
{
    public class SeriesRepositorio : ISerieRepositorio<Serie>
    {
        protected DioSeriesContext context = new DioSeriesContext();
        public void Add(Serie obj)
        {
            context.Series.Add(obj);
            context.SaveChanges();
        }

        public IEnumerable<Serie> GetAll()
        {
            var series = context.Series.Where(s => s.Excluida == false);
            return series;
        }

        public Serie GetById(int id)
        {
            var serie = context.Series.Where(s => s.SerieId == id && s.Excluida == false).SingleOrDefault();
            return serie;
        }

        public void Remove(Serie obj)
        {
            obj.Excluida = true;
            context.Entry(obj).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Update(Serie obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}