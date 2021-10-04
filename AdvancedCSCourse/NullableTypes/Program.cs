using System;

namespace NullableTypes
{
    class Program
    {
        public static void Main (string[] args) {
            //DateTime date = null; => would throw an error
            //Nullable<DateTime> date = null; => correct syntax
            DateTime? date = null; //shorthand

            Console.WriteLine("GetValueOrDefault(): " + date.GetValueOrDefault()); //returns a value if the object is initialized or the data type default if it's not
            Console.WriteLine("HasValue: " + date.HasValue); //true if it has a value, false if it's null
            //Console.WriteLine("Value: " + date.Value);  =>  must have a value or the app crashes, GetValueOrDefault is the preferred way

            date = new DateTime(2021, 10, 04);
            //DateTime date2 = date;  =>  error, because is trying to give a nullable DateTime to a normal one, what if it's null, compiler doesn't know what to do
            DateTime date2 = date.GetValueOrDefault(); //right way
            Console.WriteLine(date2);

            //DateTime date3 = (Date != null) ? date.GetValueOrDefault() : DateTime.Today;
            DateTime date3 = date ?? DateTime.Today; //null coalescing operator
            //good use instead of if and else (if date has a value, will be date, else, DateTime.Today)
        }
    }
}
