using System;

namespace ConstraintsOnTypeParameters
{
    class StructArray<T> where T : struct
    {
        public T[] Array { get; set; }
        public StructArray(int size)
        {
            Array = new T[size];
        }
    }

    class RefArray<T> where T : class
    {
        public T[] Array { get; set; }
        public RefArray(int size)
        {
            Array = new T[size];
        }
    }
    
    
    class Base { }
    class Derived : Base { }
    class BaseArray<U> where U : Base
    {
        public U[] Array { get; set; }
        public BaseArray(int size)
        {
            Array = new U[size];
        }

        public void CopyyArray<T>(T[] Target) where T : U
        {
            Target.CopyTo(Array, 0);
        }
    }
    public interface inf
    {

    }
    public interface intf : inf
    {
        
    }

    public class InterfaceArray<T> where T : inf
    {
        public T[] Array { get; set; }
        public int Length { get; set; }
        public InterfaceArray(int size)
        {
            Array = new T[size];
            Length = Array.Length;
        }
    }
    class MainApp
    {
        public static T CreateInstance<T>() where T : new()
        {
            return new T();
        }

        static void Main(string[] args)
        {
            StructArray<int> a = new StructArray<int>(3);
            a.Array[0] = 0;
            a.Array[1] = 1;
            a.Array[2] = 2;
            for(int i=0; i<a.Array.Length; i++)
            {
                Console.WriteLine(a.Array[i]);
            }
            

            RefArray<StructArray<double>> b = new RefArray<StructArray<double>>(3);
            b.Array[0] = new StructArray<double>(5);
            b.Array[1] = new StructArray<double>(10);
            b.Array[2] = new StructArray<double>(1005);
            Console.WriteLine();
            for (int i = 0; i < b.Array.Length; i++)
            {
                Console.WriteLine(b.Array[i]);
            }

            BaseArray<Base> c = new BaseArray<Base>(3);
            c.Array[0] = new Base();
            c.Array[1] = new Derived();
            c.Array[2] = CreateInstance<Base>();
            Console.WriteLine();
            for (int i = 0; i < c.Array.Length; i++)
            {
                Console.WriteLine(c.Array[i]);
            }

            BaseArray<Derived> d = new BaseArray<Derived>(3);
            d.Array[0] = new Derived(); // Base 형식은 여기에 할당 할 수 없다.
            d.Array[1] = CreateInstance<Derived>();
            d.Array[2] = CreateInstance<Derived>();

            Console.WriteLine();
            for (int i = 0; i < d.Array.Length; i++)
            {
                Console.WriteLine(d.Array[i]);
            }

            BaseArray<Derived> e = new BaseArray<Derived>(3);
            e.CopyyArray<Derived>(d.Array);
            Console.WriteLine();
            Console.WriteLine(e.Array);

            InterfaceArray<intf> f = new InterfaceArray<intf>(3);
            Console.WriteLine();
            Console.WriteLine(f.Array);

        }
    }
}