using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2021
{
    
    class Day5
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
            int s = 999;
            int count = 0;

            int[,] places = new int[s,s];
            for(int i = 0; i < s; i++)
            {
                for(int j = 0; j < s; j++)
                {
                    places[i, j] = 0;
                }
            }

            string[] lines = System.IO.File.ReadAllLines("./Day5Data.txt");
            foreach(string line in lines)
            {
                string[] coords = line.Split(" ");
                string[] XY1 = coords[0].Split(",");
                string[] XY2 = coords[2].Split(",");

                if(XY1[0].Equals(XY2[0]))
                {
                    //Console.WriteLine($"{XY1[0]}, {XY2[0]}");
                    //Console.WriteLine("--");
                    for (int i = int.Parse(XY1[1]); i <= int.Parse(XY2[1]); i++)
                    {
                        //Console.WriteLine($"{XY1[0]}, {i}");
                        places[int.Parse(XY1[0]), i]++;
                    }

                    for (int i = int.Parse(XY2[1]); i <= int.Parse(XY1[1]); i++)
                    {
                        //Console.WriteLine($"{XY1[0]}, {i}");
                        places[int.Parse(XY1[0]), i]++;
                    }
                } 
                else if (XY1[1].Equals(XY2[1]))
                {
                    //Console.WriteLine($"{XY1[0]}, {XY2[0]}");
                    //Console.WriteLine("--");
                    for (int i = int.Parse(XY1[0]); i <= int.Parse(XY2[0]); i++)
                    {
                        //Console.WriteLine($"{XY1[0]}, {i}");
                        places[i, int.Parse(XY1[1])]++;
                    }

                    for (int i = int.Parse(XY2[0]); i <= int.Parse(XY1[0]); i++)
                    {
                        //Console.WriteLine($"{XY1[0]}, {i}");
                        places[i, int.Parse(XY1[1])]++;
                    }
                }
            }

            for (int i = 0; i < s; i++)
            {
                for (int j = 0; j < s; j++)
                {
                    //Console.Write(places[i, j]);
                    if(places[i,j] >= 2)
                    {
                        count++;
                    }
                }
                //Console.WriteLine();
            }

            Console.WriteLine(count);

        }

        public void Part2()
        {
            int s = 999;
            int count = 0;

            int[,] places = new int[s, s];
            for (int i = 0; i < s; i++)
            {
                for (int j = 0; j < s; j++)
                {
                    places[i, j] = 0;
                }
            }

            string[] lines = System.IO.File.ReadAllLines("./Day5Data.txt");
            foreach (string line in lines)
            {
                string[] coords = line.Split(" ");
                string[] XY1 = coords[0].Split(",");
                string[] XY2 = coords[2].Split(",");

                if (XY1[0].Equals(XY2[0]))
                {
                    //Console.WriteLine($"{XY1[0]}, {XY2[0]}");
                    //Console.WriteLine("--");
                    for (int i = int.Parse(XY1[1]); i <= int.Parse(XY2[1]); i++)
                    {
                        //Console.WriteLine($"{XY1[0]}, {i}");
                        places[int.Parse(XY1[0]), i]++;
                    }

                    for (int i = int.Parse(XY2[1]); i <= int.Parse(XY1[1]); i++)
                    {
                        //Console.WriteLine($"{XY1[0]}, {i}");
                        places[int.Parse(XY1[0]), i]++;
                    }
                }
                else if (XY1[1].Equals(XY2[1]))
                {
                    //Console.WriteLine($"{XY1[0]}, {XY2[0]}");
                    //Console.WriteLine("--");
                    for (int i = int.Parse(XY1[0]); i <= int.Parse(XY2[0]); i++)
                    {
                        //Console.WriteLine($"{XY1[0]}, {i}");
                        places[i, int.Parse(XY1[1])]++;
                    }

                    for (int i = int.Parse(XY2[0]); i <= int.Parse(XY1[0]); i++)
                    {
                        //Console.WriteLine($"{XY1[0]}, {i}");
                        places[i, int.Parse(XY1[1])]++;
                    }
                }
                else
                {
                    int x1, y1, x2, y2;
                    x1 = int.Parse(XY1[0]);
                    y1 = int.Parse(XY1[1]);

                    x2 = int.Parse(XY2[0]);
                    y2 = int.Parse(XY2[1]);
                    if (x1 < x2 && y1 < y2)
                    {
                        for (int i = 0; i <= x2 - x1; i++)
                        {
                            places[x1 + i, y1 + i]++;
                        }
                    }
                    else if(x1 < x2 && y1 > y2)
                    {
                        for (int i = 0; i <= x2 - x1; i++)
                        {
                            places[x1 + i, y1 - i]++;
                        }
                    }
                    else if(x1 > x2 && y1 > y2)
                    {
                        for (int i = 0; i <= x1 - x2; i++)
                        {
                            places[x1 - i, y1 - i]++;
                        }
                    }
                    else
                    {
                        for (int i = 0; i <= x1 - x2; i++)
                        {
                            places[x1 - i, y1 + i]++;
                        }
                    }

                }
            }

            for (int i = 0; i < s; i++)
            {
                for (int j = 0; j < s; j++)
                {
                    //Console.Write(places[i, j]);
                    if (places[i, j] >= 2)
                    {
                        count++;
                    }
                }
                //Console.WriteLine();
            }

            Console.WriteLine(count);
        }
    }
}
