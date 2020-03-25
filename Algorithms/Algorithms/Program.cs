using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();

            try
            {
                //Directory.GetCurrentDirectory();
                StreamReader reader = new StreamReader(File.OpenRead("C:\\Users\\Stephen\\OneDrive\\Swinburne\\Anh class\\Tasks\\Algorithms\\algorithms\\Algorithms\\unsorted_numbers.csv"));
                Console.WriteLine("File Found");

                while (!reader.EndOfStream)
                {
                    numbers.Add(Convert.ToInt32(reader.ReadLine()));
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("File could not be found");
                Console.ReadLine();
            }

            //InsertionSort(numbers);

            ShellSort(numbers);

            Display(numbers);

            Console.WriteLine(numbers.Count);
            //Console.WriteLine(numbers[0]);
            Console.ReadLine();
        }

        public static void InsertionSort(List<int> unsorted)
        {
            int n = unsorted.Count;

            for (int i = 1; i < n; i++)
            {
                int currentNumber = unsorted[i];
                int j = i - 1;

                while (j >= 0 && unsorted[j] > currentNumber)
                {
                    unsorted[j + 1] = unsorted[j];
                    j = j - 1;
                }
                unsorted[j + 1] = currentNumber;
            }
        }

        public static void ShellSort(List<int> unsorted)
        {
            int size = unsorted.Count;
            int j, temp;
            int pos = 3;
            
            while(pos > 0)
            {
                for(int i = 0; i < size; i++)
                {
                    j = i;
                    temp = unsorted[i];

                    while((j >= pos) && (unsorted[j - pos] > temp))
                    {
                        unsorted[j] = unsorted[j - pos];
                        j = j - pos;
                    }
                    unsorted[j] = temp;
                }

                if (pos / 2 != 0)
                {
                    pos = pos / 2;
                }
                else if (pos == 1)
                {
                    pos = 0;
                }
                else
                    pos = 1;
            }
        }

        public static void Display(List<int> numbers)
        {
            foreach (int num in numbers)
            {
                Console.WriteLine(num);
            }
        }
    }
}
