using System;
using System.Collections.Generic;

namespace TicTac
{
    class Program
    {
         const int PLAYER1 = 1;
         const int PLAYER2 = 2;
        static int nMoves = 0;
        static Mark[] marks = new Mark[9];
        static draw drawing = new draw();

        static readonly int[,] rows = new int[8, 3]
       {
          {0 , 1 , 2}
       , {3 , 4 , 5 }
       , {6 , 7 , 8 }
       , {0 , 3 , 6 }
       , {1 , 4 , 7 }
       , {2 , 5 , 8 }
       , {0 , 4 , 8 }
       , {2 , 4 , 6 }
       };

        static void Main(string[] args)
        {

            for (int i = 0; i < marks.Length; i++)        // initialize marks array

            {
                marks[i] = new Mark();
            }



            drawing.Grid(marks);
            bool On = true;
            bool Restart = false;       // not yet implemented 
            while (On)
            {

                Play(PLAYER1);            // player 1 play
                int result = CheckWin();
                On = !Convert.ToBoolean(result);
                if (!On)
                {
                    System.Console.WriteLine($"Player {result} Won The Game!!...");
                    
                    System.Console.WriteLine("Do You Want To Restart ?  Y / N ");
                    char state = Console.ReadKey().KeyChar;

                    switch (state.ToString().ToLower())
                    {
                        case "y":
                            On = true;
                            for (int i = 0; i < marks.Length; i++)        // initialize marks array
                            {
                                marks[i] = new Mark();
                            }
                            nMoves = 0;
                            Console.Clear();
                            drawing.Grid(marks);

                            continue;

                        case "n":
                            System.Console.WriteLine($"Game Has Ended...");
                            System.Console.ReadLine();
                            break;
                    }
                }

                Play(PLAYER2);

                result = CheckWin();
                On = !Convert.ToBoolean(result);
                if (!On)
                {
                    System.Console.WriteLine($"Player {result} Won The Game!!...");
                    System.Console.WriteLine("Do You Want To Restart ?  Y / N ");
                    char state = Console.ReadKey().KeyChar;

                    switch (state.ToString().ToLower())
                    {
                        case "y":
                            On = true;
                            for (int i = 0; i < marks.Length; i++)        // initialize marks array
                            {
                                marks[i] = new Mark();
                            }
                            nMoves = 0;
                            Console.Clear();
                            drawing.Grid(marks);

                            continue;

                        case "n":
                            System.Console.WriteLine($"Game Has Ended...");
                            System.Console.ReadLine();
                            break;

                    }
                }
            }

            Console.ReadLine();
        }

        static void MapSelection(int pos, int player)
        {

            if (player == 1)
            {
                marks[pos - 1] = new XMark();
            }

            if (player == 2)
            {
                marks[pos - 1] = new OMark();
            }

        }

        static int ReadPos(int player)
        {
            int Pos = -1;
            System.Console.WriteLine("");
            System.Console.WriteLine($"Player {player} - pick a Position from 1 - 9");
            do
            {
                do
                {
                    try
                    {
                        Pos = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException ex)
                    {

                        Console.WriteLine("Invalid Input.. Try again");
                        continue;
                    }

                    if (Pos > 9 || Pos < 0)
                    {
                        System.Console.WriteLine("Enter only from 1-9..");
                    }

                } while (Pos > 9 || Pos < 0);

                bool v = marks[Pos - 1].Label.Equals("Empty");

                System.Console.WriteLine("This is picked Already!");

            } while (!marks[Pos - 1].Label.Equals("Empty"));
            nMoves++;
            return Pos;
        }

        static int CheckWin()
        {
            if (nMoves >= 5)
            {
                for (int i = 0; i < 8; i++)
                {
                    bool win = marks[rows[i, 0]].Label == marks[rows[i, 1]].Label
                    && marks[rows[i, 1]].Label == marks[rows[i, 2]].Label;
                    if (win && marks[rows[i, 0]].Label == "XMark")
                    {
                        return 1;
                    }
                    if (win && marks[rows[i, 0]].Label == "OMark")
                    {
                        return 2;
                    }
                }
                return 0;
            }

            else
            {
                return 0;
            }
        }

        static void Play(int player)
        {
        
            int Pos = ReadPos(player);
            MapSelection(Pos, player);
            Console.Clear();
            drawing.Grid(marks);

        }
    }
}
