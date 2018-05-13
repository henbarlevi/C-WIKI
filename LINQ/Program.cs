using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
           ================ 
           Basic Examples
           ================ 
            */
            var sample = "i enjoy writing ubser-software in C#";
            //1
            IEnumerable<char> allLeters = from c in sample select c;//get all chars of the string to a collection
            //2 WHERE
            IEnumerable<char> selectiveLetters = from c in sample.ToLower() where c == 'i' || c == 'a' || c == 'b' select c;//lowercase the string and get only specic chars
            //3 orderby , ascending descending
            IEnumerable<char> example3 = from c in sample
                                         orderby c descending
                                         select c;//lowercase the string and get only specic chars
            //4 groupby
            var people = new List<Person>
            {
                new Person {FirstName="Hen",LastName="Bar levi"},
                new Person {FirstName="jane",LastName="Williams"},
                new Person {FirstName="john",LastName="Williams"},
                new Person {FirstName="bob",LastName="Williams"},
                new Person {FirstName="bar",LastName="Doe"}

            };
            //gouped by family name
            var peopleGroups = from p in people
                               orderby p.LastName
                               group p by p.LastName;

            foreach (var group in peopleGroups)
            {
                Console.WriteLine($"{group.Key} - {group.Count()}"); /*
                        Bar Levi - 1
                        Williams - 3
                        Doe - 1
                 */
            }

            /*
            ================ 
            LINQ TRANSLATION
            ================ 
             */
            Console.WriteLine("==== LINQ TRANSLATION ==== ");
            int[] numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            //this is a sugar syntax:
            var result = from n in numbers where n > 4 select n;
            //of this:
            result = numbers.Where(n => n > 5).Select(n => n);
            //which is also sugar syntax from this:
            result = Enumerable.Select(Enumerable.Where(numbers, n => n > 5)
                , n => n);//(in c# all instance mtethods are actually static methods that have reference to 'this')
                          //(LINQ) is extension methods added Generally to IEnumarble type

            /*using my LINQ method*/
            result = numbers.MyFilter(n => n > 5).Select(n=>n);
            foreach (var n in result)
            {
                Console.WriteLine(n);
            }
            Console.ReadLine();
        }


        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }

        }

    }
        /*
    ================ 
    Adding My Own LINQ extension Method
    ================ 
    */
    public static class LINQExtension
    {
        public static IEnumerable<int> MyFilter(this IEnumerable<int> source, Func<int, bool> predicate/*function that take an [int] and returns[bool] */)
        {
            //var newCollection = new List<int>();
            foreach (var n in source)
            {
                Console.WriteLine("MyFilter");
                if (predicate(n)) yield return n;//newCollection.Add(n); 

            }

             //return newCollection;
        }
    }
}
