using System;

namespace TicTac
{
    class draw
    {
        public void Grid(IMark[] marks)
        {

            DrawExample();

            System.Console.WriteLine("   _ _ _ _ _ _ _");

            System.Console.WriteLine("");
            System.Console.Write("  |  ");

            for (int i = 0; i < 3; i++)
            {
                marks[i].DrawMark();            }
            System.Console.Write("  |  ");
            System.Console.WriteLine("");
            System.Console.WriteLine("");
            System.Console.Write("  |  ");

            for (int i = 3; i < 6; i++)
            {
                marks[i].DrawMark();            }
            System.Console.Write("  |  ");

            System.Console.WriteLine("");
            System.Console.WriteLine("");
            System.Console.Write("  |  ");

            for (int i = 6; i < 9; i++)
            {
                marks[i].DrawMark();            }
            System.Console.Write("  |  ");

            System.Console.WriteLine("");

            System.Console.WriteLine("   _ _ _ _ _ _ _");

        }

        void DrawExample()
        {

            System.Console.WriteLine("Numbers Guide..");
            System.Console.WriteLine("   _ _ _ _ _ _ _");

            System.Console.WriteLine("");
            System.Console.Write("  |  ");

            for (int i = 0; i < 3; i++)
            {
                System.Console.Write($" {i + 1} ");
            }
            System.Console.Write("  |  ");
            System.Console.WriteLine("");
            System.Console.WriteLine("");
            System.Console.Write("  |  ");

            for (int i = 3; i < 6; i++)
            {
                System.Console.Write($" {i + 1} ");
            }
            System.Console.Write("  |  ");

            System.Console.WriteLine("");
            System.Console.WriteLine("");
            System.Console.Write("  |  ");

            for (int i = 6; i < 9; i++)
            {
                System.Console.Write($" {i + 1} ");
            }
            System.Console.Write("  |  ");

            System.Console.WriteLine("");

            System.Console.WriteLine("   _ _ _ _ _ _ _");

        }


    }

}