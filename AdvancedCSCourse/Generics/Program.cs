using System;

namespace Generics
{
    class Program
    {
        public static void Main (string[] args) {
            var mybook = new Book { Isbn = "1111", Title = "C# Advanced" };

            //var numbers = new NumberList();
            //numbers.Add(1);

            //var books = new BookList();
            //books.Add(mybook);
            // is a good choice to make a generic list, because you won't have to complain about solving bugs in each class for each type, and will avoid boxing/unboxing for a list of objects

            var list = new GenericList<int>();
            //list.Add(1);  =>  would throw an error 

            var number = new Nullable<int>(5); // true, 5
            //var number = new Nullable<int>(); // false, 0 
            Console.WriteLine("Has Value? " + number.HasValue);
            Console.WriteLine("Value: " + number.GetValueOrDefault());
        }
    }
}
