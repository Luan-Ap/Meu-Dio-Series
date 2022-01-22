namespace MeuDioSeries.Infra.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using MeuDioSeries.Infra.Contexto;
    using System.Linq;
    using MeuDioSeries.Dominio.Entidades;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<DioSeriesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DioSeriesContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            var generos = new List<Genero>
            {
                new Genero
                {
                    GeneroId = 1,
                    Nome = "Ação"
                },
                new Genero
                {
                    GeneroId = 2,
                    Nome = "Aventura"
                },
                new Genero
                {
                    GeneroId = 3,
                    Nome = "Comédia"
                },
                new Genero
                {
                    GeneroId = 4,
                    Nome = "Documentário"
                },
                new Genero
                {
                    GeneroId = 5,
                    Nome = "Drama"
                },
                new Genero
                {
                    GeneroId = 6,
                    Nome = "Espionagem"
                },
                new Genero
                {
                    GeneroId = 7,
                    Nome = "Faroeste"
                },
                new Genero
                {
                    GeneroId = 8,
                    Nome = "Fantasia"
                },
                new Genero
                {
                    GeneroId = 9,
                    Nome = "Ficção Científica"
                },
                new Genero
                {
                    GeneroId = 10,
                    Nome = "Músical"
                },
                new Genero
                {
                    GeneroId = 11,
                    Nome = "Romance"
                },
                new Genero
                {
                    GeneroId = 12,
                    Nome = "Suspense"
                },
                new Genero
                {
                    GeneroId = 13,
                    Nome = "Terror"
                }
            };

            generos.ForEach(g => context.Generos.AddOrUpdate(s => s.Nome, g));
            context.SaveChanges();
        }
    }
}
