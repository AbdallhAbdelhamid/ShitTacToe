using System;


namespace TicTac
{
    public interface IMark
    {
        void DrawMark();
    }


    public class Mark : IMark
    {
        public virtual void  DrawMark()
        {
            System.Console.Write(" _ ");
        }
        public string Label = new string("Empty");
    }

    public class XMark : Mark
    {
        public XMark()
        {
            Label = "XMark";
        }

        public override void DrawMark()
        {
            System.Console.Write(" X ");

        }
    }

    public class OMark : Mark
    {
        
        public OMark()
        {
            Label = "OMark";
        }
        public override void DrawMark()
        {
            System.Console.Write(" O ");

        }
    }



}