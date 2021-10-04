using System;

namespace DynamicTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            //C# is a static language, such as Java
            //A dynamic language is referred to Ruby, Python or Javascript
            //The difference is that static langauges are ran at compile time, and dynamic languages are ran at run time
            //it's faster to write code

            dynamic name = "Gabriel";
            //name++; => exception, with dynamic we need to write more unit tests
            name = 10; //no problems on doing that

            int i = 5;
            dynamic d = i;
            long l = d;

            System.Console.WriteLine(l);
        }
    }
}
