using System;

namespace ConsoleApp3
{

    class myclass
    {
        private int myint;

        public int getmyint()
        { return myint; }

        public void setmyint(int value1)
        {
            myint = value1;
        }

        public int myfield
        {
            get { return myfield; }

            set { myint = value; }
        }

        public string name { get; set; } = "unknown";
    }
    class Program
    {
        static void Main(string[] args)
        {
            myclass my = new myclass();

            my.name = "ryu";

            Console.WriteLine(my.name);

        }
    }
}