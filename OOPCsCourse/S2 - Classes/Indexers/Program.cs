using System;

namespace Indexers
{
    class Program {
        static void Main(string[] args) {
            var cookie = new HttpCookie();
            cookie["name"] = "Gabriel"; //better to store data
            Console.WriteLine(cookie["name"]);
        }
    }
}
