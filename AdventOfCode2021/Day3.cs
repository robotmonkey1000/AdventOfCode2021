using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2021
{
    class Day3
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
            int bitLength = 12;
            int[] ones = new int[bitLength];
            int[] zeros = new int[bitLength];
            int gamma = 0b000000000000;
            int epsilon = 0b000000000000;


            string[] lines = System.IO.File.ReadAllLines("./Day3Data.txt");
            foreach(string line in lines)
            {
                for(int i = 0; i < bitLength; i++)
                {
                    if(line[i] == '1')
                    {
                        ones[i]++;
                    } else
                    {
                        zeros[i]++;
                    }
                }
            }

            for(int i = 0; i < bitLength; i++)
            {
                if(ones[i] > zeros[i])
                {
                    gamma |= 1 << bitLength - i - 1;
                }
                else
                {
                    epsilon |= 1 << bitLength - i - 1;
                }
            }

            Console.WriteLine($"Gamma: {gamma}, Epsilon: {epsilon}, Power: {gamma * epsilon}");

        }

        public void Part2()
        {
            int bitLength = 12;
            int[] ones = new int[bitLength];
            int[] zeros = new int[bitLength];

            string[] lines = System.IO.File.ReadAllLines("./Day3Data.txt");
            foreach (string line in lines)
            {
                for (int i = 0; i < bitLength; i++)
                {
                    if (line[i] == '1')
                    {
                        ones[i]++;
                    }
                    else
                    {
                        zeros[i]++;
                    }
                }
            }

            List<string> oxy = new List<string>(lines);
            for(int i = 0; i < bitLength; i++)
            {
                Array.Fill(ones, 0);
                Array.Fill(zeros, 0);
                foreach (string line in oxy)
                {
                    for (int j = i; j < bitLength; j++)
                    {
                        if (line[j] == '1')
                        {
                            ones[j]++;
                        }
                        else
                        {
                            zeros[j]++;
                        }
                    }
                }
                for (int j = oxy.Count - 1; j >= 0; j--)
                {

                    Console.WriteLine($"{ones[i]} {zeros[i]}");
                    if (oxy.Count == 1) break;
                    string line = oxy[j];
                    if(ones[i] >= zeros[i])
                    {
                        if(line[i] != '1')
                        {
                            oxy.Remove(line);
                            Console.WriteLine($"Removing because no 1 {line}");
                        }
                    } 
                    else
                    {
                        if (line[i] != '0')
                        {
                            oxy.Remove(line);
                            Console.WriteLine($"Removing because no 0 {line}");
                        }
                    }
                }
            }

            Console.WriteLine("CO2");
            List<string> co2 = new List<string>(lines);
            for (int i = 0; i < bitLength; i++)
            {
                Array.Fill(ones, 0);
                Array.Fill(zeros, 0);
                foreach (string line in co2)
                {
                    for (int j = i; j < bitLength; j++)
                    {
                        if (line[j] == '1')
                        {
                            ones[j]++;
                        }
                        else
                        {
                            zeros[j]++;
                        }
                    }
                }
                for (int j = co2.Count - 1; j >= 0; j--)
                {

                    Console.WriteLine($"{ones[i]} {zeros[i]}");
                    if (co2.Count == 1) break;
                    string line = co2[j];
                    if (ones[i] >= zeros[i])
                    {
                        if (line[i] != '0')
                        {
                            co2.Remove(line);
                            Console.WriteLine($"Removing because no 0 {line}");
                        }
                    }
                    else
                    {
                        if (line[i] != '1')
                        {
                            co2.Remove(line);
                            Console.WriteLine($"Removing because no 1 {line}");
                        }
                    }
                }
            }


            Console.WriteLine($"Oxy: {oxy[0]}, CO2: {co2[0]}, Life: {Convert.ToInt32(oxy[0], 2) * Convert.ToInt32(co2[0], 2)}");

        }
    }
}
