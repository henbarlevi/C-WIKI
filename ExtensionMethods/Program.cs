using System;

namespace ExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Person { Name = "jhon", Age = 22 };
            p.SayHello();
            var p2 = new Person { Name = "Maya", Age = 17 };
            p2.SayHelloTo(p);

            
        }
    }

    public static class PersonExtensions
    {
        public static void SayHello(this Person person)
        {
            Console.WriteLine("{0} says Hello",person.Name);
        }

        public static void SayHelloTo(this Person person,Person person2)
        {
            Console.WriteLine("{0} says Hello to {1}", person.Name,person2.Name);
        }
    }


    //(in c# all instance mtethods are actually static methods that have reference to 'this')
    public class Cow
    {
        int moo = 0;
        //this instance method 
        public void Moo()
        {
            Console.WriteLine("Moo "+moo);
        }
        //is actually sugar syntax for this
        //public static void Moo2(this Cow _this)
        //{
        //    Console.WriteLine("Moo "+ _this.moo);
        //}
    }


}