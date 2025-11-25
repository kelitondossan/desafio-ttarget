using System;

namespace DesafioTTarget.Challenges
{
    public class InterestCalculator
    {
        public static void Execute()
        {
            Console.WriteLine("--- Calculadora de Juros ---");
            
            Console.WriteLine("Informe o valor original da dívida (R$):");
            if (double.TryParse(Console.ReadLine(), out double value))
            {
                Console.WriteLine("Informe a data de vencimento (dd/MM/yyyy):");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime dueDate))
                {
                    DateTime today = DateTime.Now.Date; []
                    if (today > dueDate)
                    {
                        TimeSpan difference = today - dueDate;
                        int daysOverdue = difference.Days;
                        
                        double interestRate = 0.025;
                        double totalInterest = value * interestRate * daysOverdue;
                        double totalValue = value + totalInterest;

                        Console.WriteLine($"\nDias em atraso: {daysOverdue}");
                        Console.WriteLine($"Valor Original: {value:C2}");
                        Console.WriteLine($"Juros (2,5% ao dia): {totalInterest:C2}");
                        Console.WriteLine($"Valor Total a Pagar: {totalValue:C2}");
                    }
                    else
                    {
                        Console.WriteLine("O boleto não está vencido. Juros não aplicáveis.");
                    }
                }
                else
                {
                    Console.WriteLine("Data inválida.");
                }
            }
            else
            {
                Console.WriteLine("Valor inválido.");
            }
        }
    }
}
