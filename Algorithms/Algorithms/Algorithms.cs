using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Algorithms
{
    class Algorithms
    {
        public static void ReadNumbers(List<int> numbers)
        {
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

            while (pos > 0)
            {
                for (int i = 0; i < size; i++)
                {
                    j = i;
                    temp = unsorted[i];

                    while ((j >= pos) && (unsorted[j - pos] > temp))
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

        public static int BinarySearchDisplay(List<int> numbers, int lower, int upper, int search, ref string display)
        {
            int mid;
            if (upper >= lower)
            {
                mid = (lower + upper) / 2;
                if (numbers[mid] == search)
                {
                    int tempMid = mid;

                    while (numbers[tempMid - 1] == search)
                    {
                        tempMid--;
                    }

                    while (numbers[tempMid] == search)
                    {
                        display += $"{search} found at element {tempMid}\n";
                        tempMid++;
                    }

                    return mid;
                }
                else if (numbers[mid] < search)
                {
                    return BinarySearchDisplay(numbers, mid + 1, upper, search, ref display);
                }
                else
                {
                    return BinarySearchDisplay(numbers, lower, mid - 1, search, ref display);
                }
            }
            return -1;

        }

        public static void LinearSearchDisplay(List<int> numbers, int search, ref string display)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == search)
                {
                    display += $"{search} found at element {i}\n";
                }
            }

            if (display.Length == 0)
            {
                display = $"{search} was not found";
            }
        }

        public static void SearchForBinary(List<int> numbers, int[] numSearch)
        {
            string display = "";
            foreach (int num in numSearch)
            {
                BinarySearchDisplay(numbers, 0, numbers.Count - 1, num, ref display);
            }

            Console.WriteLine(display);
        }
        public static void SearchForLinear(List<int> numbers, int[] numSearch)
        {
            string display = "";
            foreach (int num in numSearch)
            {
                LinearSearchDisplay(numbers, num, ref display);
            }

            Console.WriteLine(display);
        }
        public static void Display(List<int> numbers)
        {
            foreach (int num in numbers)
            {
                Console.Write(num + "\t");
            }

            Console.WriteLine();
        }
    }
}
