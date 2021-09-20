using System;

namespace Generics
{
    public class Product {
        public string Title { get; set; }
        public float Price { get; set; }
    }

    public class Book : Product {
        public string Isbn { get; set; }
    }
}