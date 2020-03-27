using System;
using System.Collections.Generic;
using System.IO;


namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            int search;
            int option = 0;
            try
            {
                StreamReader reader = new StreamReader(File.OpenRead(Directory.GetCurrentDirectory() + "\\unsorted_numbers.csv"));

                Console.WriteLine("File Found");

                while (!reader.EndOfStream)
                {
                    numbers.Add(Convert.ToInt32(reader.ReadLine()));
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("File could not be found");
                Console.ReadLine();
            }

            //InsertionSort(numbers);

            ShellSort(numbers);

            Display(numbers);

            while(option != -1)
            {
                Console.WriteLine("Enter the number to search for or -1 to EXIT: ");
                search = Convert.ToInt32(Console.ReadLine());
                if (search != -1)
                {
                    option = LinearSearch(numbers, search);
                    if (option != -1)
                    {
                        Console.WriteLine(search + $" found at element {option}");
                    }
                    else
                    {
                        option = 0;
                        Console.WriteLine($"{search} not found");
                    }
                }
                else
                    option = -1;
            }


            Console.ReadLine();

            //Binary search
            /*while(LinearSearch return == -1) returns -1 if it has not been found
             * {
             * 
                }*/
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

        public static int LinearSearch(List<int> numbers, int search)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if(numbers[i] == search)
                {
                    return i;
                }
                i++;
            }

            return -1;
        }

        public static void Display(List<int> numbers)
        {
            foreach (int num in numbers)
            {
                Console.Write(num + "\t");
            }
        }
    }
}
