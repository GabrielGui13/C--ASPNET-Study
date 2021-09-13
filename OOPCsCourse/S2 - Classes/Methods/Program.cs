using System;

namespace Methods
{
    class Program {
        public static void Main (string[] args) {
            //var number = int.Parse("abc"); => throw an Exception

            int number;
            var result = int.TryParse("abc", out number); //returns an boolean

            if (result) //if parse is possible, number will receive the parse value
                Console.WriteLine(number);
            else //if false, nothing happens
                Console.WriteLine("Conversion failed.");
        }

        static void UseParams() {
            var calculator = new Calculator();
            Console.WriteLine(calculator.Add(1, 2));
            Console.WriteLine(calculator.Add(1, 2, 3));
            Console.WriteLine(calculator.Add(1, 2, 3, 4));
            Console.WriteLine(calculator.Add(new int[] {1, 2, 3, 4}));
        }

        static void UsePoints() {
            try {
                var point = new Point(10, 20);
                point.Move(new Point(40, 60));
                Console.WriteLine($"Point is at {point.X}, {point.Y}");

                point.Move(100, 200);
                Console.WriteLine($"Point is at {point.X}, {point.Y}");
            }
            catch (Exception) {
                Console.WriteLine("An unexpected error ocurred.");
            }
        }
    }
}
