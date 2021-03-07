using Business.Concrete.Managers;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //ProductTest();
            OrderTest();
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
            foreach (var product in productManager.GetProductsByUnitPrice(10, 15))
            {
                Console.WriteLine($"{product.ProductName} - {product.UnitPrice}");
            }
        }
    }
}
