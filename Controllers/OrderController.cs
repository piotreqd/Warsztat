using System;
using System.Collections.Generic;
using System.Text;
using Warsztat.Model;

namespace Warsztat.Controllers
{
    public class OrderController
    {
        public void BeginOrder(int carId, string orderName)
        {
            using (var context = new WorkschopContext())
            {
                var order = new Order()
                {
                    CarId = carId,
                    Name = orderName,
                    StartDate = DateTime.Now,
                    EndDate = null
                };
                context.Orders.Add(order);
                context.SaveChanges();
            }
        }
        public void EndOrder(int orderId)
        {
            using (var context = new WorkschopContext())
            {
                try
                {
                    var order = context.Orders.Find(orderId);
                    order.EndDate = DateTime.Now;
                    context.SaveChanges();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }
    }
}
