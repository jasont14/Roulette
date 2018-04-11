/*********************************
 * Jason Thatcher       April 2018
 * 
 * Program.cs
 * 
 * Represents a fair roulette game.
 * Fair insofar as there are no "zeros"
 * and equal probability of even/odd,
 * black / red, high / low outcomes.
 * 
 * Used to perform Monte Carlo simulation
 * of a fair roulette game.
 * 
 *********************************/

using System;
using System.Collections.Generic;
using System.Linq;

namespace Roulette
{
    class Roulette
    {
        private int spinCount = 0;
        private int redCount = 0;
        private int blackCount = 0;
        private int oddCount = 0;
        private int evenCount = 0;
        private int lowCount = 0;
        private int highCount = 0;
        private Dictionary<int, int> spinValueCount = new Dictionary<int, int>();
        private Random ran;
        //spin values that are red
        private int[] redKey = { 32, 19,21,25,34,27,36,30,23,5,16,1,14,9,18,7,12,3 };

        public Roulette()
        {
            //initialize dictionary
            for (int i = 1; i<37; i++)
            {
                spinValueCount.Add(i, 0);
            }

            ran = new Random();
        }
        
        //Roulette 1-36
        //Roulette Black / Red
        //Roulette low = 1-18 high 19-36
        //Roulette even when spinValue % 2 = 0

        public void Spin(int spins)
        {
            spinCount = spins;

           for (int i = 0; i<spins; i++)
            {
                int spinValue = ran.Next(1, 37);
                spinValueCount[spinValue] += 1;

                if (spinValue % 2 == 0)
                {
                    evenCount += 1;
                }
                else
                {
                    oddCount += 1;
                }

                if (!redKey.Contains(spinValue))
                {
                    redCount += 1;
                }
                else
                {
                    blackCount += 1;
                }

                if (spinValue < 19)
                {
                    lowCount += 1;
                }
                else
                {
                    highCount += 1;
                }
            }
        }

        public void PrintSummaryResults()
        {
            Console.WriteLine();
            Console.WriteLine("Spins".PadRight(15) + "Red/Black".PadRight(20) + "Odd/Even".PadRight(20) + "low/High".PadRight(20));
            Console.WriteLine(spinCount.ToString("N0").PadRight(15) + (redCount.ToString("N0") + "/" + blackCount.ToString("N0")).PadRight(20) + (oddCount.ToString("N0") + "/" + evenCount.ToString("N0")).PadRight(20) + (lowCount.ToString("N0") + "/" + highCount.ToString("N0")).PadRight(20));

            Console.WriteLine();
        }

        public void PrintSpinValueResults()
        {

            Console.WriteLine("Spin Count by Value (1-36)");
            int counter = 0;

            foreach (KeyValuePair<int, int> kvp in spinValueCount)
            {
                Console.WriteLine("Value: {0}\t{1}", kvp.Key.ToString(), kvp.Value.ToString());
                counter += kvp.Value;
            }

            Console.WriteLine("Spin Value Count Total: {0} ", counter.ToString());
        }
    }
}
