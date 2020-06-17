using System;
using static System.Console;

namespace ConsoleApp4
{
    class fillter : Exception
    {
        public int Errono { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine(" 0~10 사이 숫자를 입력하세요 ");
            string input = ReadLine();
            try
            {
                int num = Int32.Parse(input);

                if (num < 0 || num > 10)
                {
                    throw new fillter() { Errono = num };

                }
                else
                    WriteLine(" 당신이 입력한 숫자는 : " + num);
            }
            catch (fillter e) when (e.Errono < 0)
            {
                WriteLine(" 입력 숫자가 0보다 작습니다. ");

            }
            catch (fillter e) when (e.Errono > 10)
            {
                WriteLine(" 입력 숫자가 10보다 큽니다. ");

            }


        }
    }
}

