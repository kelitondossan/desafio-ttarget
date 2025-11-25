using System;
using DesafioTTarget.Challenges;

namespace DesafioTTarget
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Desafio TTarget - Menu Principal ===");
                Console.WriteLine("1. Desafio 1: Comissão de Vendas");
                Console.WriteLine("2. Desafio 2: Gestão de Estoque");
                Console.WriteLine("3. Desafio 3: Calculadora de Juros");
                Console.WriteLine("0. Sair");
                Console.WriteLine("========================================");
                Console.Write("Escolha uma opção: ");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Clear();
                        SalesCommission.Execute();
                        Pause();
                        break;
                    case "2":
                        Console.Clear();
                        StockMovement.Execute();
                        Pause();
                        break;
                    case "3":
                        Console.Clear();
                        InterestCalculator.Execute();
                        Pause();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opção inválida.");
                        Pause();
                        break;
                }
            }
        }

        static void Pause()
        {
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }
    }
}
