using System;
using System.Collections;
using System.Collections.Generic;

namespace MethodOverriding
{
    class Program {
        public static void Main (string[] args) {
            var shapes = new List<Shape>();
            shapes.Add(new Circle());
            shapes.Add(new Rectangle());
            shapes.Add(new Triangle()); //independent of each other

            var canvas = new Canvas();
            canvas.DrawShapes(shapes);
        }
    }
}
