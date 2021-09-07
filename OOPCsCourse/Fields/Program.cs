using System;

namespace Fields
{
    class Program {
        static void Main(string[] args) {
            var customer = new Customer(1);
            customer.Orders.Add(new Order());
            customer.Orders.Add(new Order());

            customer.Promote(); //it would restart the list (accidentally)

            Console.WriteLine(customer.Orders.Count); //2
        }
    }
}
