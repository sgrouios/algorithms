using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Algorithms;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            int[] numSearch = { 575154, 182339, 17132, 773788, 296934, 991395, 303270, 45231, 580, 629822 };
            int count = 0;
            int choice = 0;

            while (choice != 9)
            {
                Console.WriteLine("\nChoose an option:\n1. Clear current array and import from .csv\n2. Display current array\n3. Sort array using Insertion sort\n4. Sort array using Shell sort\n5. Search through array using Linear search and display details\n6. Search through array using Binary search and display details\n7. Run Analytics on Linear search\n8. Run Analytics on Binary search\n9. Exit\n");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        numbers.Clear();
                        Algorithms.ReadNumbers(numbers);
                        break;
                    case 2:
                        if (numbers.Count > 0)
                            Algorithms.Display(numbers);
                        else
                            Console.WriteLine("Import the csv before displaying the numbers");
                        break;
                    case 3:
                        if (numbers.Count > 0)
                            Algorithms.InsertionSort(numbers);
                        else
                            Console.WriteLine("Import the csv before sorting");
                        break;
                    case 4:
                        if (numbers.Count > 0)
                            Algorithms.ShellSort(numbers);
                        else
                            Console.WriteLine("Import the csv before sorting");
                        break;
                    case 5:
                        if (numbers.Count > 0)
                        {
                            Algorithms.SearchForLinear(numbers, numSearch);
                        }
                        break;
                    case 6:
                        if (numbers.Count > 0)
                        {
                            Algorithms.SearchForBinary(numbers, numSearch);
                        }
                        break;
                    case 7:
                        if (numbers.Count > 0)
                        {
                            count = 0;
                            Analysis.AnalyseLinearSearch(numbers, numSearch, ref count);
                            Console.WriteLine("Number of loops for Linear search: " + count);
                        }
                        break;
                    case 8:
                        if (numbers.Count > 0)
                        {
                            count = 0;
                            Analysis.AnalyseBinarySearch(numbers, numSearch, ref count);
                            Console.WriteLine("Number of loops for Binary search: " + count);
                        }
                        break;
                    case 9:
                        break;
                }
            }
        }
    }
}
