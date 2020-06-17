using System;
using static System.Console;
namespace ConsoleApp2
{

    class Program
    {
        static void Doso(int arg)
        {
            if (arg < 10)
            {
                WriteLine(arg);
            }
            else
                throw new Exception("arg가 10보다 큽니다.");
        }
        static void Main(string[] args)
        {

            try
            {
                Doso(1);
                Doso(3);
                Doso(5);
                Doso(9);
                Doso(11);
                Doso(13);

            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }

        }
    }
}