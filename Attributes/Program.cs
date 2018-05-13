using System;
using System.Linq;
using System.Reflection;

namespace Attributes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }


    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)] /* define where this attribute can be, (by default all) */
    public class myAttribute : Attribute
    {
        public string Id { get; set; }
        public int Version { get; set; }
    }
    [my(Id ="abc",Version =1)] //myAttirbute - shortcuting it by removing the 'Attirbute' Word
    public class File
    {
        //[my] - NOT VALID, cant use this attribute on property(see AttributeUsage)
        public int Age { get; set; }
    }

    

    
}