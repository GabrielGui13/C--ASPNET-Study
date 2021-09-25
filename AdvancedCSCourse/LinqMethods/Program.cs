using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace LinqMethods
{
    class Program
    {
        static void Main(string[] args) {
            /* var cheapBooks = new List<Book>();

            foreach (var book in books) {
                if (book.Price < 10) cheapBooks.Add(book);
            }
                    too much code
            */

            var books = new BookRepository().GetBooks();

            // LINQ Query Operator
            var cheaperBooks = //always start with from and finish with select
                from b in books
                where b.Price < 10
                orderby b.Title
                select b.Title;

            // LINQ Extension Methods
            var cheapBooks = books
                                .Where(b => b.Price < 10)
                                .OrderBy(b => b.Title)
                                .Select(b => b.Title);

            var higherPricedBook = books
                                    .Single(b => b.Price == books.Max(bk => bk.Price));

            Console.WriteLine($"Highest priced book is called {higherPricedBook.Title}");

            //Linq methods can chain in each other
		    //cheapBooks after Select (used for projections or transformations) is now an array of strings (book's titles)

            foreach (var book in cheapBooks) Console.WriteLine(book);
			//Console.WriteLine(book.Title + " " + book.Price);

            Console.WriteLine(); //blank space


            var bookAsp = books.Single(b => b.Title == "ASP.NET MVC");
            Console.WriteLine("Single book = " + bookAsp.Title); //one and only one object that satisfies the condition

            Console.WriteLine(); //blank space


            var noBookAsp = books.SingleOrDefault(b => b.Title == "ASP.NET MVC++"); //returns null if it dont match anything
            Console.WriteLine(noBookAsp == null);

            Console.WriteLine(); //blank space


            var firstBookTitleName = books.FirstOrDefault(b => b.Title == "C# Advanced Topics"); //first or default same thinking
            Console.WriteLine($"{firstBookTitleName.Title} + {firstBookTitleName.Price}");

            Console.WriteLine(); //blank space


            var lastBookTitleName = books.LastOrDefault(b => b.Title == "C# Advanced Topics");
            Console.WriteLine($"{lastBookTitleName.Title} + {lastBookTitleName.Price}");

            Console.WriteLine(); //blank space


            var pagedBooks = books.Skip(2).Take(3); //skipped 2 books and took 3
            foreach (var pagedBook in pagedBooks)
            {
                Console.WriteLine(pagedBook.Title);
            }

            Console.WriteLine(); //blank space


            var count = books.Count(); //count of objects
            Console.WriteLine(count);

            Console.WriteLine(); //blank space


            var maximumPrice = books.Max(b => b.Price); //max of something of the list
            Console.WriteLine(maximumPrice);

            Console.WriteLine(); //blank space
            

            var minimumPrice = books.Min(b => b.Price); //max of something of the list
            Console.WriteLine(minimumPrice);

            Console.WriteLine(); //blank space


            var totalPrice = books.Sum(b => b.Price); //min of something of the list
            Console.WriteLine(totalPrice);

            Console.WriteLine(); //blank space


            var averagePrice = books.Average(b => b.Price); //average of something of the list
            Console.WriteLine(averagePrice);
        }
    }
}
