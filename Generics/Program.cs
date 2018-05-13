using System;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            //without using generics
            var stringResult = new ResultString { Success = true, Data = "someresult" };
            var intResult = new ResultInt { Success = true, Data = 3 };
            //using genrics
            var result = new Result<int> { Success = true, Data = 3 };
            var result2 = new Result<string> { Success = true, Data = "d" };

        }
    }

    //Generics let you avoid this:
    public class ResultInt
    {
        public bool Success { get; set; }
        public int Data { get; set; }
    }

    public class ResultString
    {
        public bool Success { get; set; }
        public string Data { get; set; }
    }
    //GENERICS

    public class Result<T> 
    {
        public bool Success { get; set; }
        public T Data { get; set; }
    }

    public class ResultPrinter
    {
        public static void print<T>(Result<T> result)
        {
            Console.WriteLine("result data is:"+result.Data);
        }
    }
}