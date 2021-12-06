using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2021
{
    
    class Day6
    {
        public void Run()
        {
            Console.WriteLine("~~Part 1~~");
            Part1();

            Console.WriteLine("~~Part 2~~");
            Part2();
        }
        public void Part1()
        {
            string[] lines = System.IO.File.ReadAllLines("./Day6Data.txt");
            List<int> days = new List<int>();
            foreach(string day in lines[0].Split(","))
            {
                days.Add(int.Parse(day));
            }

            for(int i = 0; i < 80; i++)
            {
                //Console.Write($"Day {i}: ");
                int count = days.Count;
                for(int j = 0; j < count; j++)
                {
                    //Console.Write($"{days[j]} ");
                    if (days[j] == 0)
                    {
                        days[j] = 7;
                        days.Add(8);
                    }
                    days[j]--;

                }
                //Console.WriteLine();
            }

            Console.WriteLine($"Fish Count: {days.Count}");
        }

        public void Part2()
        {
            string[] lines = System.IO.File.ReadAllLines("./Day6Data.txt");
            ulong[] fishDays = new ulong[9];
            Array.Fill<ulong>(fishDays, 0);
            foreach (string day in lines[0].Split(","))
            {
                fishDays[ulong.Parse(day)]++;
            }

            for (int i = 0; i < 256; i++)
            {
                ulong zeroes = fishDays[0];

                for(int j = 1; j < 9; j++)
                {
                    fishDays[j - 1] = fishDays[j];
                    fishDays[j] = 0;
                }

                fishDays[6] += zeroes;
                fishDays[8] += zeroes;
            }

            ulong count = 0;
            for(int i = 0; i < 9; i++)
            {
                count += fishDays[i];
            }

            Console.WriteLine($"Fish Count: {count}");
        }
    }
}
