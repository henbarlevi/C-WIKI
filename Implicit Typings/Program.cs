using System;
using System.Text;

namespace Implicit_Typings
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstName = "hen";
            int age = 3;
            //int age = "name"; NOT VALID
            //var test = null;//NOT VALID - the compiler must know what type this var is going to be
            var test = (string)null;
            dynamic dynamic = null;
            dynamic = 3;
            dynamic = "hen";

        }
    }
}