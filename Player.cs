using System;

namespace TicTac
{
    public class Player
    {
        public Player(string name)         // constructer takes name of player.
        {
            Name = name;
        }

        public int Play(IMark[] marks)       // gets player position
        {
           int Pos = ReadPos(marks);
           return Pos;
        }

        private int ReadPos(IMark[] marks)
        {
            int Pos = -1;
            System.Console.WriteLine("");
            System.Console.WriteLine($"{Name} - pick a Position from 1 - 9");
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
            return Pos;

        }





        public string Name
        {
            get;
        }

    }

}