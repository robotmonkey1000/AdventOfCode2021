using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2021
{
    class Day2
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
            int depth = 0;
            int horz = 0;


            string[] lines = System.IO.File.ReadAllLines("./Day2Data.txt");
            foreach(string line in lines)
            {
                string[] actions = line.Split(' ');
                if(actions[0].Equals("forward"))
                {
                    horz += int.Parse(actions[1]);
                }
                else if(actions[0].Equals("up"))
                {
                    depth -= int.Parse(actions[1]);
                }
                else if (actions[0].Equals("down"))
                {
                    depth += int.Parse(actions[1]);
                }
            }

            Console.WriteLine($"Depth: {depth}, Horz: {horz}, Final: {depth * horz}");

        }

        public void Part2()
        {
            int depth = 0;
            int horz = 0;
            int aim = 0;


            string[] lines = System.IO.File.ReadAllLines("./Day2Data.txt");
            foreach (string line in lines)
            {
                string[] actions = line.Split(' ');
                if (actions[0].Equals("forward"))
                {
                    horz += int.Parse(actions[1]);
                    depth += aim * int.Parse(actions[1]);
                }
                else if (actions[0].Equals("up"))
                {
                    aim -= int.Parse(actions[1]);
                }
                else if (actions[0].Equals("down"))
                {
                    aim += int.Parse(actions[1]);
                }
            }

            Console.WriteLine($"Depth: {depth}, Horz: {horz}, Final: {depth * horz}");
        }
    }
}
