using System;
using static System.Console;


namespace ConsoleApp2
{
    abstract class base1
    {
        protected void privatemethod1()
        {
            WriteLine("privatemethod1");
        }
        public void publictemethod1()
        {
            WriteLine("publictemethod1");
        }

        public abstract void abstractmethod1();
    }

    class derived : base1
    {
        public override void abstractmethod1()
        {
            WriteLine("derived : abstractmethod1");
            privatemethod1();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            base1 obj = new derived();

            obj.abstractmethod1();
            obj.publictemethod1();
        }
    }
}