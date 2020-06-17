using System;

class Global
{
    public static int Count = 0;// 메소드나 필드가 클래스 자체에 소속되도록 하는 한정자, 프로그램전체에서 공유해야 하는 경우
}

class ClassA
{
    public ClassA()
    {
        Global.Count++;
    }
}

class ClassB
{
    public ClassB()
    {
        Global.Count++;
    }
}

class MainApp
{
    static void Main()
    {
        Console.WriteLine($"Global.Count : {Global.Count}");

        new ClassA();
        new ClassA();
        new ClassB();
        new ClassB();

        Console.WriteLine($"Global.Count : {Global.Count}");
    }
}