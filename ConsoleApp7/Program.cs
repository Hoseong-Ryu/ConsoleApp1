using System;

namespace ConsoleApp1
{

    interface Irun
    {
        void run();
    }
    interface Ifly
    {
        void fly();
    }

    class flyme : Irun, Ifly
    {
        public void run()
        {
            Console.WriteLine("뛴다요");
        }

        public void fly()
        {
            Console.WriteLine("난다요");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            flyme me = new flyme();
            me.fly();
            me.run();

        }
    }

}