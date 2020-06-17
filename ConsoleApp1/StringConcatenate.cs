//using System;
//using System.Collections;

//namespace _4._2StringConcatenate
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            string result = "123" + "456";//문자열도 + 사용 가능
//            Console.WriteLine(result);

//            result = "Hello" + " " + "World!";

//            Console.WriteLine(result);

//            Console.WriteLine("Testing && ... ");
//            Console.WriteLine($"1 > 0 && 4 < 5 : {1 > 0 && 4 < 5}");
//            //비교+논리연산자
//            //$표기를 해주면 중괄호 안에 변수를 입력할 수 있다.

//            ArrayList a = null; //list 자료형을 사용하기 위해선 collections가 필요하다.
//            a = new ArrayList();
//            a.Add("야구");//추가
//            a.Add("축구");
//            Console.WriteLine($"Count:{a.Count}");//a리스트의 길이 계산
//            a.RemoveAt(1);//하나제거
//            Console.WriteLine($"{a[1]}");
//            a.Clear();//모두제거
//        }
//    }
//}