using System;

namespace Testability
{
    public class OrderProcessor {
        private readonly IShippingCalculator _shippingCalculator;

        public OrderProcessor(IShippingCalculator shippingCalculator) {
            _shippingCalculator = shippingCalculator; 
            //no more instances os ShippingCalculator in this class
        }

        public void Process(Order order) {
            if (order.IsShipped) 
                throw new InvalidOperationException("This order is already processed.");
            
            order.Shipment = new Shipment {
                Cost = _shippingCalculator.CalculateShipping(order),
                ShippingDate = DateTime.Today.AddDays(1)
            };

            Console.WriteLine("Order processed.");
        }
    }
}