using AutoMapper;
using MeuDioSeries.Dominio.Entidades;
using MeuDioSeries.Dominio.Interface;
using MeuDioSeries.Infra.Repositorio;
using MeuDioSeries.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MeuDioSeries.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddAuthentication("CookieSeries")
                .AddCookie("CookieSeries", c => 
                {
                    c.Cookie.Name = "CookieSeries";
                    c.LoginPath = "/Conta/Login";
                    c.AccessDeniedPath = "/Conta/AcessoNegado";
                });

            //Aqui criamos uma configuração do AutoMapper para realizar o mapeamento
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<SerieViewModel, Serie>();
                c.CreateMap<Serie, SerieViewModel>();

                c.CreateMap<GeneroViewModel, Genero>();
                c.CreateMap<Genero, GeneroViewModel>();
            });

            //Aqui criamos um mapper com a configuração definida
            IMapper mapper = config.CreateMapper();


            //Aqui adicionamos as dependências para serem injetadas
            
            services.AddSingleton(mapper);

            services.AddTransient<ISerieRepositorio, SeriesRepositorio>();
            services.AddTransient<IGeneroRepositorio, GeneroRepositorio>();

            services.AddTransient<ISerieService, SerieService>();
            services.AddTransient<IGeneroService, GeneroService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
