using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2021
{
    class Day1
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
            int prev = 0;
            int increases = 0;
            int decreases = 0;
            string[] lines = System.IO.File.ReadAllLines("./Day1Data.txt");
            foreach (string line in lines)
            {
                try
                {
                    int result = Int32.Parse(line);
                    if (result > prev)
                    {
                        increases++;
                    }
                    else
                    {
                        decreases++;
                    }
                    prev = result;
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Unable to parse '{line}'");
                }
            }

            Console.WriteLine($"Inc: {increases - 1}, Dec: {decreases}");
        }

        public void Part2()
        {
            int prev = 0;
            int increases = 0;
            int decreases = 0;
            string[] lines = System.IO.File.ReadAllLines("./Day1Data.txt");
            for (int i = 0; i < lines.Length - 2; i++)
            {
                try
                {
                    if (!(i + 2 > lines.Length))
                    {
                        int sum = Int32.Parse(lines[i]) + Int32.Parse(lines[i + 1]) + Int32.Parse(lines[i + 2]);
                        if (sum > prev)
                        {
                            increases++;
                        }
                        else
                        {
                            decreases++;
                        }
                        prev = sum;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Unable to parse");
                }
            }

            Console.WriteLine($"Inc: {increases - 1}, Dec: {decreases}");
        }
    }
}
