using System;
using System.IO; //StreamReader
using System.Collections;
using System.Collections.Generic;

namespace UpcastingDowncasting
{
    class Program {
        public static void Main (string[] args) {
            Text text = new Text();
            Shape shape = text; //both are pointing to the same reference in memory

            text.Width = 200;
            shape.Width = 100; //equal to text, but with a limited view (no fontsize or name)

            Console.WriteLine(text.Width); //100


            StreamReader reader = new StreamReader(new MemoryStream()); //accepts any reference or instance pointing to Stream type

            var list = new ArrayList();
            list.Add(1);	
            list.Add("Gabriel");	
            list.Add(new Text()); //can add any type

            var anotherList = new List<Shape>(); //correct way to declare a lis

/* 
            Shape shape = new Text(); //limited view to shape properties and methods
            Text text = (Text) shape; //access to everything because of casting */
        }
    }
}
