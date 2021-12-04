using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2021
{
    class Board
    {
        const int boardSize = 5;
        string[,] board = { { "", "", "", "", "" }, { "", "", "", "", "" }, { "", "", "", "", "" }, { "", "", "", "", "" }, { "", "", "", "", "" }};
        

        public void setPosition(int x, int y, string num)
        {
            board[x, y] = num;
        }

        public bool checkNum(string num)
        {
            for(int i = 0; i < boardSize; i++)
            {
                for(int j = 0; j < boardSize; j++)
                {
                    if(!board[i,j].Equals(" *") && int.Parse(board[i, j]) == int.Parse(num))
                    {
                        board[i, j] = " *";
                    }
                }
            }

            if(checkWinner())
            {
                CalculateWinning(num);
                return true;
            }

            return false;
        }

        public bool checkWinner()
        {

            //Check each row from left to right
            for(int i = 0; i < boardSize; i++)
            {

                int row = 0;
                for(int j = 0; j < boardSize; j++)
                {
                    if(board[i, j].Equals(" *"))
                    {
                        row++;
                    }

                    if (row == boardSize)
                    { 
                        Console.WriteLine("Row Found");
                        return true;
                    }
                }
            }

            //Check each colum from top to bottom.
            for(int i = 0; i < boardSize; i++)
            {
                int col = 0;
                for(int j = 0; j < boardSize; j++)
                {
                    if(board[j, i].Equals(" *"))
                    {
                        col++;
                    }

                    if (col == boardSize)
                    {
                        Console.WriteLine("Column Found");
                        return true;
                    }
                }
            }


            return false;
        }

        public void printBoard()
        {
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    Console.Write(board[i, j] + " ");
                }

                Console.WriteLine("");
            }
        }

        public void CalculateWinning(string num)
        {
            int sum = 0;
            for(int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    Console.Write(board[i, j] + " ");
                    if (!board[i, j].Equals(" *"))
                    {
                        sum += int.Parse(board[i, j]);
                    }
                }

                Console.WriteLine("");
            }

            Console.WriteLine($"Final {sum * int.Parse(num)}");
        }

    }
    class Day4
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
            string[] lines = System.IO.File.ReadAllLines("./Day4Data.txt");
            string[] numbers = lines[0].Split(",");
            List<Board> boards = new List<Board>();
            int boardSize = 5;

            int currentRow = 0;
            int currentBoard = -1;
            for(int i = 2; i < lines.Length; i++)
            {
                if(currentRow == 0)
                {
                    boards.Add(new Board());
                    currentBoard++;
                }

                //Also just check if line is empty
                if(currentRow != 5)
                {
                    for(int j = 0; j < boardSize; j++)
                    {
                        boards[currentBoard].setPosition(currentRow, j, lines[i].Substring(j*3, 2));
                    }
                }
                
                currentRow++;
                currentRow %= boardSize + 1;
            }

            foreach (string number in numbers)
            {
                bool found = false;
                Console.WriteLine($"Checking {number}");
                foreach (Board board in boards)
                {
                    found = board.checkNum(number);
                    if(found)
                    {
                        break;
                    }
                }
                if (found) break;

                foreach (Board board in boards)
                {
                    board.printBoard();
                    Console.WriteLine();
                }
            }

        }

        public void Part2()
        {
            string[] lines = System.IO.File.ReadAllLines("./Day4Data.txt");
            string[] numbers = lines[0].Split(",");
            List<Board> boards = new List<Board>();
            int boardSize = 5;

            int currentRow = 0;
            int currentBoard = -1;
            for (int i = 2; i < lines.Length; i++)
            {
                if (currentRow == 0)
                {
                    boards.Add(new Board());
                    currentBoard++;
                }

                //Also just check if line is empty
                if (currentRow != 5)
                {
                    for (int j = 0; j < boardSize; j++)
                    {
                        boards[currentBoard].setPosition(currentRow, j, lines[i].Substring(j * 3, 2));
                    }
                }

                currentRow++;
                currentRow %= boardSize + 1;
            }
            List<Board> winners = new List<Board>();
            foreach (string number in numbers)
            {
                bool found = false;
                Console.WriteLine($"Checking {number}");
                for(int i = boards.Count - 1; i >= 0; i--)
                {
                    found = boards[i].checkNum(number);
                    if (found)
                    {
                        winners.Add(boards[i]);
                        boards.Remove(boards[i]);
                    }
                }

                if (boards.Count == 0) break;

                foreach (Board board in boards)
                {
                    board.printBoard();
                    Console.WriteLine();
                }
            }



        }
    }
}
