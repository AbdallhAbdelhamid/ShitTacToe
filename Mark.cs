using System;


namespace TicTac
{
    public interface IMark
    {
        void DrawMark();
        string Label
        {
            get;
        }
    }


    class Mark : IMark
    {
        public virtual void DrawMark()
        {
            System.Console.Write(" _ ");
        }

        public string Label
        {
            get;
            private protected set;
        } = "Empty";
    }

    class XMark : Mark
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

    class OMark : Mark
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