using System;

class Base
{
    protected string Name;
    public Base(string Name)
    {
        this.Name = Name;
        Console.WriteLine(this.Name + ".Base()");
    }

    ~Base()
    {
        Console.WriteLine(this.Name + ".~Base()");
    }

    public void BaseMethod()
    {
        Console.WriteLine(Name + ".BaseMethod()");
    }
}

class Derived : Base//부모와 자식 클래스를 통한 상속
{
    public Derived(string Name) : base(Name)
    {
        Console.WriteLine($"{this.Name}.Derived()");
    }

    ~Derived()
    {
        Console.WriteLine($"{this.Name}.~Derived()");
    }

    public void DerivedMethod()
    {
        Console.WriteLine($"{Name}.DerivedMethod()");
    }
}

class MainApp
{
    static void Main(string[] args)
    {
        Base a = new Base("a");
        a.BaseMethod();

        Derived b = new Derived("b");
        b.BaseMethod();
        b.DerivedMethod();
    }
}