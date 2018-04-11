/*********************************
 * Jason Thatcher       April 2018
 * 
 * Program.cs
 * 
 * Entry point. Sets number of sets
 * and number of spins per set.
 * 
 *********************************/

using System;

namespace Roulette
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fair Roulette Simulator");
            Console.WriteLine();
            Console.WriteLine("The simulator will execute the number of spins equal to the number of spins designated below.  This is an example Monte Carlo simulation.  Monte Carlo simulations are useful when trying to model the probability of different outcomes.");
            Console.WriteLine();
            Console.Write("Enter number of sets (default = 1): ");

            int sets = 1;
            int spins = 1;

            while (!int.TryParse(Console.ReadLine(), out sets))
            {
                Console.Write("Error value was not a number.  Please enter the number of sets of spins: ");                
            }

            Console.Write("Enter the number of spins: ");
            
            while (!int.TryParse(Console.ReadLine(), out spins))
            {
                Console.Write("Error value was not a number.  Please enter the number of spins and press enter to spin: ");
            }

            for (int i = 0; i<sets; i++)
            {
                Roulette game = new Roulette();
                game.Spin(spins);
                game.PrintSummaryResults();
                // game.PrintSpinValueResults();
            }
            
            Console.ReadKey();
        }
    }
}
