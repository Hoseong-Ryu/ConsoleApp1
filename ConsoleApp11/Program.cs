using System;
using static System.Console;


namespace ConsoleApp8
{
    class mylist<T>
    {
        private T[] array;

        public mylist()
        {
            array = new T[3];
        }

        public T this[int index]
        {
            get
            {
                return array[index];
            }
            set
            {
                if (index >= array.Length)
                {
                    Array.Resize<T>(ref array, index + 1);
                    WriteLine("array resize: " + array.Length);
                }
            }
        }

        public int Length
        {
            get { return array.Length; }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}