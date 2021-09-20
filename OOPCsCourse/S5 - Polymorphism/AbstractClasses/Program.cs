using System;

namespace AbstractClasses
{
    class Program {
        public static void Main (string[] args) {
            //var shape = new Shape();

            var circle = new Circle();
            circle.Draw();

            var rectangle = new Rectangle();
            rectangle.Draw();
        }
    }
}
