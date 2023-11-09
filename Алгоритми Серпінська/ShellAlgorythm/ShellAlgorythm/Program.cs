using System;
using System.Collections.Generic;

namespace ShellAlgorythm
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> items = new List<int>();
            int itensLength = 10;
            FillItems(items, itensLength);
            var shell = new ShellSort<int>(items);

            ShowItems(shell.Items);

            Sort(shell);

        }

        private static void Sort(AlgorithmBase<int> algorithm)
        {
            var time = algorithm.Sort();

            Console.WriteLine();
            ShowItems(algorithm.Items);
            Console.WriteLine();

            Console.WriteLine("Time: " + time.TotalMilliseconds + " Milliseconds");
            Console.WriteLine("Swop Count: " + algorithm.SwopCount);
            Console.WriteLine("Comparison Count: " + algorithm.ComparisonCount);
        }
        private static void FillItems(List<int> items, int length)
        {
            var rnd = new Random();
            for (int i = 0; i < length; i++)
            {
                items.Add(rnd.Next(1000));
            }
        }
        private static void ShowItems(List<int> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                Console.Write(items[i] + " ");
                
            }
        }
    }
}
