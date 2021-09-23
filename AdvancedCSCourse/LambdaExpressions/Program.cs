using System;
using System.Linq;

namespace LambdaExpressions
{
    class Program {
        public static void Main (string[] args) {
            // args => expression
            // () => ...
            // x => ...
            // (x, y, z) => ...

            //Console.WriteLine(Square(5)); => too much code

            //Delegate<params, return> = lambda
            Func<int, int> square = number => { //needs to be attached to a delegate, similar to js arrow functions
                return number * number;
            };

            var result = square(5);
            Console.WriteLine(result);
            //--------------------------------------------------
            
            var books = new BookRepository().GetBooks();
            //var cheapBooks = books.FindAll(IsCheaperThan10Dollars);
            var cheapBooks = books.FindAll(b => b.Price < 10);

            foreach (var book in cheapBooks) {
                Console.WriteLine(book.Title);
            }
        }

        static int Square(int number) { //no need to be used
            return number * number;
        }
        static bool IsCheaperThan10Dollars(Book book) { //predicate function to find methods
            return book.Price < 10;
        }
    }
}
