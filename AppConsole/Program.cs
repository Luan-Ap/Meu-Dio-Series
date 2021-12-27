﻿using Dominio.Entidades;
using Dominio.Enum;
using Infra.Repositorio;
using System;
using System.Linq;

namespace AppConsole
{
    class Program
    {
        static SeriesRepositorio seriesRepositorio = new SeriesRepositorio();
        static void Main(string[] args)
        {
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

            var lista = seriesRepositorio.GetAll();

            if (lista.Any())
            {
                foreach (var serie in lista)
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

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("#ID: {0} - Gênero: {1}", i, Enum.GetName(typeof(Genero), i));
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

                Serie novaSerie = new Serie
                {
                    Titulo = entradaTitulo,
                    Descricao = entradaDescricao,
                    AnoLancamento = entradaAno,
                    Genero = (Genero)entradaGenero,
                    Excluida = false
                };

                seriesRepositorio.Add(novaSerie);

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

            if (seriesRepositorio.GetAll() == null)
            {
                return;
            }

            try
            {
                Console.Write("Digite o id da série que deseja atualizar(Ex: 3): ");
                var serie = seriesRepositorio.GetById(int.Parse(Console.ReadLine()));

                if (serie != null)
                {
                    Console.WriteLine("\n" + serie + "\n------------------------------------\n");

                    foreach (int i in Enum.GetValues(typeof(Genero)))
                    {
                        Console.WriteLine("#ID: {0} - Gênero: {1}", i, Enum.GetName(typeof(Genero), i));
                    }

                    Console.Write("\nDigite o genêro entre as opções acima(Ex: 1): ");
                    serie.Genero = (Genero)int.Parse(Console.ReadLine());

                    Console.Write("\nDigite o Título da Série: ");
                    serie.Titulo = Console.ReadLine();

                    Console.Write("\nDigite a Descrição da Série: ");
                    serie.Descricao = Console.ReadLine();

                    Console.Write("\nDigite o Ano de Início da Série(Ex: 2015): ");
                    serie.AnoLancamento = int.Parse(Console.ReadLine());

                    seriesRepositorio.Update(serie);

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

            if (seriesRepositorio.GetAll() == null)
            {
                return;
            }

            try
            {
                Console.Write("Digite o id da série que deseja excluir(Ex: 3): ");
                var serie = seriesRepositorio.GetById(int.Parse(Console.ReadLine()));

                if (serie != null)
                {
                    Console.WriteLine("\n" + serie + "\n------------------------------------\n");

                    Console.WriteLine();
                    Console.Write("Deseja realmente excluir essa série?\nDigite 1 para SIM ou Digite 0 para NÃO: ");

                    if (Console.ReadLine().Contains("0"))
                    {
                        return;
                    }
                    else
                    {
                        seriesRepositorio.Remove(serie);
                        Console.Write("\n\nSérie excluida com sucesso.");
                    }
                }
                else
                {
                    Console.Write("\n\nSérie não encontrada ou já Excluída.");
                }
            }
            catch
            {
                Console.Write("\n\nErro ao excluir Série. Verifique se as entradas estão corretas e tente novamente.");
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

            if (seriesRepositorio.GetAll() == null)
            {
                return;
            }

            try
            {
                Console.Write("Digite o id da série que deseja visualizar: ");
                var serie = seriesRepositorio.GetById(int.Parse(Console.ReadLine()));

                if (serie != null)
                {
                    Console.WriteLine();
                    Console.WriteLine(serie);
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
    }
}