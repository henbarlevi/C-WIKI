using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates_Events
{
    class Program
    {
        /*
         ==== Delegate (Equivalent to simply Passing Functions in JS)==== 
        */
        delegate void myDel();/*
        - delegate is an encapsulation of a method
        - create a Class behind the scenes 
        - myDel can contain a method that returns Void and doesn't have any params input*/
        delegate void Operation(int num); //method that returns void and receive a number
        static void Main(string[] args)
        {
            myDel del = new myDel(sayHello);
            //how to invoke delegate:
            del.Invoke(); //will invoke sayHello
            //syntax sugar of above
            myDel del2 = sayHello;
            del2(); //instead of invoke
            //how to chaindelegates
            Operation op = Double;
            op += Triple; //concat also the triple method
            op(2);//will invoke Double and Triple

            /*
             ======================================
             Anonymous Methods & Lambda Expressions
             ======================================
             */
            Operation op2 = (num) => { Console.WriteLine(num); };//sugar syntax that let us avoid form declaring a method
             /*
            ======================================
            Generic Delegates
            ======================================
            */
            //- Let us avoid of declaring a Delegate Type  (for ex as we declared above Operation and myDel types)
            //Action - doesn't have a return value
            Action<int> action;//can contain methods that doesnt return value and has int as input
            action = Double;
            action(2);//will print 4
            action += Triple;//concating another method
            action(3);//will print 6 and then 9
            //Func - does have return value 
            Func<int, string> func;//can contain methods that return string value and has int as input
            func = (int num) => { return num.ToString(); };
            //action and func can have many inputs as we want
            Action<int, string, double> action2 = (num, s, d) => Console.WriteLine($"{num}{s}{d}"); ;
            Console.ReadKey();
        }
        static void sayHello()
        {
            Console.WriteLine("Hello");
        }

        static void Double(int num)
        {
            Console.WriteLine(num * 2);
        }
        static void Triple(int num)
        {
            Console.WriteLine(num * 3);
        }
    }
}
