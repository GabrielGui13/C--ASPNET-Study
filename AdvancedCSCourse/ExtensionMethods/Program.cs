using System;

namespace ExtensionMethods
{
    class Program {
        static void Main(string[] args) {
            string post = "This is supposed to be a very long post of a blog bla bla bla"; 
		    Console.WriteLine(post.Shorten(5));
        }
    }
}
