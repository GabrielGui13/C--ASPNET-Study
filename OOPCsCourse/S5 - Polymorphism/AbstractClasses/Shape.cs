using System;

namespace AbstractClasses
{
    public abstract class Shape { //needs to be abstract to have abstract members
        public int Width { get; set; }
        public int Height { get; set; }

        public abstract void Draw(); //inherits virtual

        public void Copy() {
            Console.WriteLine("Copied shape into clipboard");
        }

        public void Select() {
            Console.WriteLine("Selected shape");
        }
    }

    public class Circle : Shape {
        public override void Draw() {
            Console.WriteLine("Draw a circle");
        }
    }

    public class Rectangle : Shape {
        public override void Draw() {
            Console.WriteLine("Draw a rectangle");
        }
    }
}