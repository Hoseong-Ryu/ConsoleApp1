using System;
using static System.Console;

namespace ConsoleApp3
{
    class Program
    {

        static int Divide(int divisor, int dividend)
        {
            try
            {
                WriteLine("Divide 시작");
                return divisor / dividend;
            }
            catch (DivideByZeroException e)
            {
                WriteLine("Divide 예외 발생");

                throw e;
            }
            finally
            {
                WriteLine("Divide 종료");
            }

        }
        static void Main(string[] args)
        {
            try
            {
                WriteLine("제수를 입력하세요");
                string temp = ReadLine();
                int divisor = Convert.ToInt32(temp);


                WriteLine("피제수를 입력하세요");
                temp = ReadLine();
                int dividend = Convert.ToInt32(temp);

                WriteLine(divisor + "/" + dividend + "=" + Divide(divisor, dividend));
            }
            catch (FormatException e)
            {
                WriteLine("에러:" + e.Message);

            }
            catch (DivideByZeroException e)
            {
                WriteLine("에러:" + e.Message);

            }
            finally
            {
                WriteLine("프로그램 종료");
            }

        }
    }
}