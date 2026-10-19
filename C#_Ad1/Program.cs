
using System;
using System.Collections.Generic;
namespace C__Ad1
{
    class Program
    {
        static void Main(string[] args)
        {
            // q2 test
            Container<int> c = new Container<int>();
            c.Add(10);
            Console.WriteLine(c.Get());

            // q3 test
            Pair<int, string> p = new Pair<int, string>(1, "abc");

            // q4 test
            int x = 5, y = 20;
            Swap(ref x, ref y);

            // q5 test
            int max = FindMax(15, 42);

            // q14 test
            SafeList<string> list = new SafeList<string>();
            list.Add("hello");
            Console.WriteLine(list.Get(0));

            // q20 test
            Cache<string, string> cache = new Cache<string, string>();
            cache.Add("k1", "v1", TimeSpan.FromSeconds(2));
            Console.WriteLine(cache.Get("k1"));
        }

        #region Q1
        /*
        Q1: What is a generic class? Why use generics?

        generic class works with any data type using placeholder like T
        why use generics:
        1 type safety
        2 code reuse
        3 performance no boxing and unboxing
        */
        #endregion

        #region Q2
        
        //Q2: Write a generic class Container<T> with Add and Get methods.
        
        public class Container<T>
        {
            private T x;

            public void Add(T val)
            {
                x = val;
            }

            public T Get()
            {
                return x;
            }
        }
        #endregion

        #region Q3
        /*
        Q3: What are multiple type parameters? Write Pair<TKey, TValue>.

        multiple type parameters means using more than one placeholder like TKey and TValue separated by comma
        */
        public class Pair<TKey, TValue>
        {
            public TKey Key { get; set; }
            public TValue Value { get; set; }

            public Pair(TKey k, TValue v)
            {
                Key = k;
                Value = v;
            }
        }
        #endregion

        #region Q4
        /*
        Q4: What is a generic method? Write Swap<T> method.

        generic method uses type parameters for its arguments or return type
        */
        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
        #endregion

        #region Q5
        
        //Q5: Write a generic method FindMax<T> that finds maximum value
      
        public static T FindMax<T>(T a, T b) where T : IComparable<T>
        {
            if (a.CompareTo(b) > 0)
                return a;
            return b;
        }
        #endregion

        #region Q6
        /*
        Q6: What is a generic interface? Write IRepository<T>.

        generic interface defines method signatures with type placeholders for implementing classes
        */
        public interface IRepository<T>
        {
            void Add(T entity);
            T GetById(int id);
            List<T> GetAll();
        }
        #endregion

        #region Q7
        /*
        Q7: What is the 'struct' constraint? Write an example.

        struct constraint means type argument must be value type like int or struct
        */
        public class TestVal<T> where T : struct
        {
            public T data;
        }
        #endregion

        #region Q8
        /*
        Q8: What is the 'class' constraint? Write an example.

        class constraint means type argument must be reference type like string or custom class
        */
        public class TestRef<T> where T : class
        {
            public T item;
        }
        #endregion

        #region Q9
        /*
        Q9: What is the 'new()' constraint? Write an example.

        new constraint means type parameter must have public default constructor so we can use new T
        */
        public class Factory<T> where T : new()
        {
            public T Create()
            {
                return new T();
            }
        }
        #endregion

        #region Q10
        /*
        Q10: What is the interface constraint? Write an example.

        interface constraint means type parameter must implement specific interface
        */
        public class Manager<T> where T : IDisposable
        {
            public void Clean(T obj)
            {
                obj.Dispose();
            }
        }
        #endregion

        #region Q11
        /*
        Q11: What is the base class constraint? Write an example.

        base class constraint means type argument must inherit from specific parent class
        */
        public class Animal { }

        public class PetHandler<T> where T : Animal
        {
            public T pet;
        }
        #endregion

        #region Q12
        /*
        Q12: How do you apply multiple constraints? Write an example.

        apply multiple constraints by comma after where clause like class first then interface then new
        */
        public class Person { }

        public class MyClass<T> where T : Person, IComparable<T>, new()
        {
            public T val = new T();
        }
        #endregion

        #region Q13
        /*
        Q13: What does the 'default' keyword do in generics?

        default keyword returns default value of T like null for reference types or 0 for int
        */
        #endregion

        #region Q14
        
       // Q14: Write a SafeList<T> that returns default when the index is invalid.
        
        public class SafeList<T>
        {
            private List<T> list = new List<T>();

            public void Add(T item)
            {
                list.Add(item);
            }

            public T Get(int i)
            {
                if (i >= 0 && i < list.Count)
                    return list[i];
                return default(T);
            }
        }
        #endregion

        #region Q15
        /*
        Q15: What is covariance? Explain the 'out' keyword.
        covariance lets you use derived type instead of base type
        out keyword used in interfaces or delegates for return values only output
        */
        public interface ICovariant<out T>
        {
            T Get();
        }
        #endregion

        #region Q16
        /*
        Q16: What is contravariance? Explain the 'in' keyword.

        contravariance lets you use base type instead of derived type
        in keyword used for method parameters input
        */
        public interface IContravariant<in T>
        {
            void Set(T val);
        }
        #endregion

        #region Q17
        /*
        Q17: What is the difference between covariance and contravariance?
        covariance out keyword for output return types derived to base
        contravariance in keyword for input parameters base to derived
        */
        #endregion

        #region Q18
        /*
        Q18: How do static members work in generic types?

        static members are not shared between different type parameters each closed type gets its own static variable
        */
        public class CountHolder<T>
        {
            public static int c = 0;
        }
        #endregion

        #region Q19
        /*
        Q19: How can you inherit from a generic class?

        inherit by giving specific type to base class or keeping child class generic
        */
        public class Parent<T>
        {
            public T val;
        }

        public class Child1 : Parent<string> { }
        public class Child2<T> : Parent<T> { }
        #endregion

        #region Q20: 
        
        //Q20: Complete Exercise - Create a generic Cache<TKey, TValue> with Add, Get, Remove, Contains, and expiration support.
        
        public class Item<TValue>
        {
            public TValue val;
            public DateTime exp;

            public Item(TValue v, TimeSpan t)
            {
                val = v;
                exp = DateTime.Now.Add(t);
            }

            public bool Expired()
            {
                return DateTime.Now > exp;
            }
        }

        public class Cache<TKey, TValue>
        {
            private Dictionary<TKey, Item<TValue>> d = new Dictionary<TKey, Item<TValue>>();

            public void Add(TKey k, TValue v, TimeSpan t)
            {
                d[k] = new Item<TValue>(v, t);
            }

            public TValue Get(TKey k)
            {
                if (d.ContainsKey(k))
                {
                    Item<TValue> it = d[k];
                    if (!it.Expired())
                        return it.val;
                    d.Remove(k);
                }
                return default(TValue);
            }

            public bool Contains(TKey k)
            {
                if (d.ContainsKey(k))
                {
                    if (!d[k].Expired())
                        return true;
                    d.Remove(k);
                }
                return false;
            }

            public bool Remove(TKey k)
            {
                return d.Remove(k);
            }
        }
        #endregion
    }
}