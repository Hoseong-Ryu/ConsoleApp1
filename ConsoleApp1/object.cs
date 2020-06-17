//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Object
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            //객체 지향 프로그램의 특징, 모든 데이터 형식을 담을 수 있다.
//            object a = 123;
//            object b = 3.141592653589793238462643383279m;
//            object c = true;
//            object d = "안녕하세요.";

//            Console.WriteLine(a);
//            Console.WriteLine(b);
//            Console.WriteLine(c);
//            Console.WriteLine(d);

//            //1. 박싱 : 스택->힙
//            //2. 언박식 : 힙->스택
//            //3. 단점

//            //3.1 boxing 및 unboxing 과정에는 많은 처리 작업이 필요합니다. 값 형식을 boxing할 때는 완전히 새로운 개체가
//            //만들어져야 하며, 이러한 작업에는 할당 작업보다 최대 20배의 시간이 걸립니다.unboxing을 할 때는 캐스팅
//            //과정에 할당 작업보다 4배의 시간이 걸린다.

//            //3.2 언박싱은 박싱한 객체에 대해서만 가능하다 ->
//            //object o = new object(); -> 박싱이 일어나지 않음 즉 초기화 X 되면 사용할 수 없다.
//            //int j = (int)o; //캐스팅 예외 발생

//            //3.3 언박싱은 박싱하기 전 형식을 준수해야 한다.
//            //short i = 123; //값 형식
//            //object o = i; //박싱
//            //int j = (int)o; //int로 언박싱 불가능

//            int e = 123;
//            object f = (object)a; // a의 담긴 값을 박싱해서 힙에 저장
//            int g = (int)b; // b에 담긴 값을 언박싱해서 스택에 저장

//            Console.WriteLine(e);
//            Console.WriteLine(f);
//            Console.WriteLine(g);

//            double x = 3.1414213;
//            object y = x; // x에 담긴 값을 박싱해서 힙에 저장 ->묵시적 데이터 전환
//            double z = (double)y; // y에 담긴 값을 언박싱해서 스택에 저장

//            Console.WriteLine(x);
//            Console.WriteLine(y);
//            Console.WriteLine(z);

//        }
//    }
//}