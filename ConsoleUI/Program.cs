using Business.Concrete.Managers;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductTest();
            //OrderTest();
        }

        private static void OrderTest()
        {
            OrderManager orderManager = new OrderManager(new EfOrderDal());
            foreach (var order in orderManager.GetOrders())
            {
                Console.WriteLine($"{order.OrderID} - {order.OrderDate} - {order.ShipCity}");
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            var result = productManager.GetProductsByUnitPrice(10,15);
            if (result.Success)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine($"{product.ProductName} - {product.UnitPrice}");
                }
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
