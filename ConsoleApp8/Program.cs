using System;
using static System.Console;

namespace ConsoleApp5
{

    /* class Birthdayinfo
    {
    public string name
    {
    get;
    set;
    }
    public DateTime brithday
    {
    get;
    set;
    }

    public int age
    {
    get
    {
    return new DateTime(DateTime.Now.Subtract(brithday).Ticks).Year;
    }
    }

    }*/
    class Program
    {
        static void Main(string[] args)
        {
            /* Birthdayinfo birth = new Birthdayinfo()
            {
            name = "상민",
            brithday = new DateTime(1991, 6, 28)
            };
            */
            var a = new
            {
                name = "박상현",
                age = 123
            };

            WriteLine("이름 : " + a.name + " 나이 :" + a.age);


            /*WriteLine("이름 : "+birth.name);
            WriteLine("생년 월일 : "+birth.brithday.ToShortDateString());
            WriteLine("나이 : "+birth.age);*/
        }
    }
}