using System;
using static System.Console;

namespace ConsoleApp7
{

    class Program
    {
        static void Main(string[] args)
        {
            /*string[] array1 = new string[3] { "안녕", "hello", "hi" };//1
            string[] array2 = new string[] { "안녕", "hello", "hi" };//2
            string[] array3 = { "안녕", "hello", "hi" };//3*/

            int[,] array_1 = new int[2, 3] { { 1, 2, 3 }, { 1, 2, 3 } };//2.1
            int[,] array_2 = new int[,] { { 1, 2, 3 }, { 1, 2, 3 } };//2.2
            int[,] array_3 = { { 1, 2, 3 }, { 1, 2, 3 } };//2.3


            int[,,] array_4 = new int[2, 3, 5];



            /*
            WriteLine(array1.Length);
            WriteLine(array1.Rank);

            foreach (string greeting in array1)
            WriteLine(greeting);
            */


            /* for (int i = 0; i < array_1.GetLength(0); i++)
            {
            for (int j = 0; j < array_1.GetLength(1); j++)
            {
            Write(array_1[i, j]);
            }
            WriteLine("");
            }*/

            int[][] jagged = new int[3][];

            jagged[0] = new int[5] { 1, 2, 3, 4, 5 };
            jagged[1] = new int[] { 10, 20, 30 };
            jagged[2] = new int[] { 100, 200 };

            foreach (int[] arr in jagged)
            {
                Write("배열의 길이 : " + arr.Length);
                foreach (int e in arr)
                {
                    Write(", " + e);
                }
                WriteLine("");
            }


        }
    }
}