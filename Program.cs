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

        static Player player1 = new Player("Abdallh");
        static Player player2 = new Player("Mostafa");

        static void Main(string[] args)
        {
            bool On = true;
            bool Restart = false;

            for (int i = 0; i < marks.Length; i++)        // initialize marks array

            {
                marks[i] = new Mark();
            }

            drawing.Grid(marks);                    // draw the standard grid with marks array


            while (On)                              // Game Loop , game starts from here.
            {
                /********** Player 1's Turn ***********/

                int pos = player1.Play(marks);      // get pos of player 1 move...
                nMoves++;                           // increase total number of moves
                MapSelection(pos, PLAYER1);          // change the marks array to reflect the move
                Console.Clear();
                drawing.Grid(marks);                // draw the new grid.

                int result = CheckWin();
                On = !Convert.ToBoolean(result);
                if (!On)
                {
                    AnnounceResult(result);                         // prints the winner! yaay
                    Restart = GameEnded_CheckRestart(result);       // checks if game restarts or quits
                    if (Restart)
                    {
                        On = true;
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }

                /********** Player 2's Turn ***********/

                pos = player2.Play(marks);      // get pos of player 2 move...
                nMoves++;                           // increase total number of moves
                MapSelection(pos, PLAYER2);          // change the marks array to reflect the move
                Console.Clear();
                drawing.Grid(marks);                // draw the new grid.

                result = CheckWin();
                On = !Convert.ToBoolean(result);
                if (!On)
                {
                    AnnounceResult(result);
                    Restart = GameEnded_CheckRestart(result);
                    if (Restart)
                    {
                        On = true;
                        continue;
                    }
                    else
                    {
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



        static int CheckWin()
        {

            if (nMoves >= 5)
            {
                if (nMoves == 9)
                {
                    return 3;           // draw
                }
                for (int i = 0; i < 8; i++)
                {
                    bool win = marks[rows[i, 0]].Label == marks[rows[i, 1]].Label
                    && marks[rows[i, 1]].Label == marks[rows[i, 2]].Label;
                    if (win && marks[rows[i, 0]].Label == "XMark")
                    {
                        return 1;       // player 1 won 
                    }
                    if (win && marks[rows[i, 0]].Label == "OMark")
                    {
                        return 2;       // player 2 won 
                    }
                }
                return 0;           // match not decided yet...
            }

            else
            {
                return 0;           // match not decided yet...
            }
        }

        static void AnnounceResult(int result)
        {
            switch (result)
            {
                case 1:
                    System.Console.WriteLine($"{player1.Name} Won The Game!!...");
                    break;
                case 2:
                    System.Console.WriteLine($"{player2.Name} Won The Game!!...");
                    break;
                case 3:
                    System.Console.WriteLine("I think it's draw :/");
                    break;
            }
        }
        static bool GameEnded_CheckRestart(int result)
        {

            System.Console.WriteLine("Do You Want To Restart ?  Y / N ");
            char state = Console.ReadKey().KeyChar;

            switch (state.ToString().ToLower())
            {
                case "y":
                    for (int i = 0; i < marks.Length; i++)        // initialize marks array
                    {
                        marks[i] = new Mark();
                    }
                    nMoves = 0;
                    Console.Clear();
                    drawing.Grid(marks);
                    return true;

                case "n":
                    System.Console.WriteLine("Game Has Ended...");
                    System.Console.ReadLine();
                    return false;

                default:
                    return false;
            }
        }
    }
}
