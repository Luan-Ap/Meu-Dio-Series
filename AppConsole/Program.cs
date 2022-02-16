using AutoMapper;
using MeuDioSeries.Dominio.Entidades;
using MeuDioSeries.Dominio.Interface;
using MeuDioSeries.Infra.Repositorio;
using MeuDioSeries.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MeuDioSeries.AppConsole
{
    class Program
    {
        static ISerieService _serviceSerie;
        static IGeneroService _serviceGenero;
        static void Main(string[] args)
        {
            var services = new ServiceCollection();

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


            var provider = services.BuildServiceProvider();

            _serviceSerie = provider.GetRequiredService<ISerieService>();
            _serviceGenero = provider.GetRequiredService<IGeneroService>();


            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;

                    case "2":
                        InserirSerie();
                        break;

                    case "3":
                        AtualizarSerie();
                        break;

                    case "4":
                        ExcluirSerie();
                        break;

                    case "5":
                        VisualizarSerie();
                        break;

                    default:
                        Console.WriteLine("Opção Inválida! Pressione ENTER para escolher novamente...");
                        Console.ReadLine();
                        break;
                }
                Console.Clear();
                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.WriteLine("Pressione Enter para sair...");
            Console.ReadLine();
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("========= DIO Séries a seu dispor =========");
            Console.WriteLine("\nInforme a opção desejada:\n");

            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static void ListarSeries()
        {
            Console.Clear();
            Console.WriteLine("========= Listar séries =========\n");

            var lista = _serviceSerie.GetAllAsync();

            if (lista.Result.Any())
            {
                foreach (var serie in lista.Result)
                {
                    Console.WriteLine("#ID: {0} - Título: {1}", serie.SerieId, serie.Titulo);
                }
            }

            Console.Write("\n\nPressione Enter para continuar...");
            Console.ReadLine();
        }

        private static void InserirSerie()
        {
            Console.Clear();
            Console.WriteLine("========= Inserir nova série =========\n");

            foreach (var genero in _serviceGenero.GetAllAsync().Result)
            {
                Console.WriteLine("#ID: {0} - Gênero: {1}", genero.GeneroId, genero.Nome);
            }
            try
            {

                Console.Write("\nDigite o genêro entre as opções acima(Ex: 1): ");
                int entradaGenero = int.Parse(Console.ReadLine());

                Console.Write("\nDigite o Título da Série: ");
                string entradaTitulo = Console.ReadLine();

                Console.Write("\nDigite a Descrição da Série: ");
                string entradaDescricao = Console.ReadLine();

                Console.Write("\nDigite o Ano de Início da Série(Ex: 2015): ");
                int entradaAno = int.Parse(Console.ReadLine());

                SerieViewModel novaSerie = new SerieViewModel
                {
                    Titulo = entradaTitulo,
                    Descricao = entradaDescricao,
                    AnoLancamento = entradaAno,
                    GeneroId = entradaGenero,
                    Excluida = false
                };

                _serviceSerie.AddAsync(novaSerie);

                Console.Write("\n\nSérie inserida com sucesso.");

            }
            catch
            {
                Console.Write("\n\nErro ao inserir nova Série. Verifique se as entradas estão corretas e tente novamente.");
            }
            finally
            {
                Console.Write("\nPressione ENTER para continuar...");
                Console.ReadLine();
            }
        }

        private static void AtualizarSerie()
        {
            Console.Clear();
            Console.WriteLine("========= Atualizar série =========\n");

            if (_serviceSerie.GetAllAsync() == null)
            {
                return;
            }

            try
            {
                Console.Write("Digite o id da série que deseja atualizar(Ex: 3): ");
                var serie = _serviceSerie.GetByIdAsync(int.Parse(Console.ReadLine()));

                if (serie != null)
                {
                    Console.Write("\n");
                    DetalhesSerieViewModel(serie.Result);
                    Console.WriteLine("\n------------------------------------\n");

                    foreach (var genero in _serviceGenero.GetAllAsync().Result)
                    {
                        Console.WriteLine("#ID: {0} - Gênero: {1}", genero.GeneroId, genero.Nome);
                    }

                    Console.Write("\nDigite o genêro entre as opções acima(Ex: 1): ");
                    serie.Result.GeneroId = int.Parse(Console.ReadLine());

                    Console.Write("\nDigite o Título da Série: ");
                    serie.Result.Titulo = Console.ReadLine();

                    Console.Write("\nDigite a Descrição da Série: ");
                    serie.Result.Descricao = Console.ReadLine();

                    Console.Write("\nDigite o Ano de Início da Série(Ex: 2015): ");
                    serie.Result.AnoLancamento = int.Parse(Console.ReadLine());

                    _serviceSerie.UpdateAsync(serie.Result);

                    Console.Write("\n\nSérie atualizada com sucesso.");
                }
                else
                {
                    Console.Write("\n\nSérie não encontrada.");
                }
            }
            catch
            {
                Console.Write("\n\nErro ao atualizar Série. Verifique se as entradas estão corretas e tente novamente.");
            }
            finally
            {
                Console.Write("\nPressione ENTER para continuar...");
                Console.ReadLine();
            }
        }

        private static void ExcluirSerie()
        {
            Console.Clear();
            Console.WriteLine("========= Excluir série =========\n");

            if (_serviceSerie.GetAllAsync() == null)
            {
                return;
            }

            try
            {
                Console.Write("Digite o id da série que deseja excluir(Ex: 3): ");
                var serie = _serviceSerie.GetByIdAsync(int.Parse(Console.ReadLine()));

                if (serie != null)
                {
                    Console.Write("\n");
                    DetalhesSerieViewModel(serie.Result);
                    Console.WriteLine("\n------------------------------------\n");

                    Console.WriteLine();
                    Console.Write("Deseja realmente excluir essa série?\nDigite 1 para SIM ou Digite 0 para NÃO: ");

                    if (Console.ReadLine().Contains("0"))
                    {
                        return;
                    }
                    else
                    {
                        _serviceSerie.RemoveAsync(serie.Result);
                        Console.Write("\n\nSérie excluida com sucesso.");
                    }
                }
                else
                {
                    Console.Write("\n\nSérie não encontrada ou já Excluída.");
                }
            }
            catch(Exception ex)
            {
                Console.Write(ex.Message + "\n\nErro ao excluir Série. Verifique se as entradas estão corretas e tente novamente.");
            }
            finally
            {
                Console.Write("\nPressione ENTER para continuar...");
                Console.ReadLine();
            }
        }

        private static void VisualizarSerie()
        {
            Console.Clear();
            Console.WriteLine("========= Visualizar série =========\n");

            if (_serviceSerie.GetAllAsync() == null)
            {
                return;
            }

            try
            {
                Console.Write("Digite o id da série que deseja visualizar: ");
                var serie = _serviceSerie.GetByIdAsync(int.Parse(Console.ReadLine()));

                if (serie != null)
                {
                    Console.WriteLine();
                    DetalhesSerieViewModel(serie.Result);
                }
                else
                {
                    Console.Write("\n\nSérie não encontrada ou já excluída.");
                }
            }
            catch
            {
                Console.Write("\n\nErro ao exibir Série. Verifique se as entradas estão corretas e tente novamente.");
            }
            finally
            {
                Console.Write("\nPressione ENTER para continuar...");
                Console.ReadLine();
            }
        }

        private static void DetalhesSerieViewModel(SerieViewModel serie)
        {
            Console.WriteLine($"Gênero: {serie.Genero.Nome}\n" +
                              $"Título: {serie.Titulo}\n" +
                              $"Descrição: {serie.Descricao}\n" +
                              $"Ano de Início: {serie.AnoLancamento}");
        }
    }
}
