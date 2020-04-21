using System;

namespace StringNumberConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 123;
            string b = a.ToString();//1. 정수 -> 문자형
            Console.WriteLine(b);

            float c = 3.14f;
            string d = c.ToString();
            Console.WriteLine(d);

            string e = "123456";
            int f = Convert.ToInt32(e);//2.문자형->정수형 int형 32
            Console.WriteLine(f);

            string g = "1.2345";

            float h = float.Parse(g);//3.parse 이용

            Console.WriteLine(h);
        }
    }
}