using System;

namespace Properties
{
    class Program {
        static void Main(string[] args) {
            /* var person = new Person{ Birthdate = new DateTime(1982, 1, 1) }; */

            /* person.Birthdate = new DateTime(1982, 1, 1); => set private */
            var person = new Person(new DateTime(1982, 1, 1));
            Console.WriteLine(person.Age);
        }
    }
}

//prop + tab => create a property identifier template   
