using System;
using System.Collections.Generic;
using System.Linq;
using Warsztat.Model;

namespace Warsztat.Controllers
{
    public class CarController
    {
        public void Delete(int carId)
        {
            using (var context = new WorkschopContext())
            {
                try
                {
                    context.Remove(context.Cars.Find(carId));
                    context.SaveChanges();
                }
                catch (NullReferenceException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }

            }
        }
        public void Add(int ownerId, string mark, string model, string registration)
        {
            var newCar = new Car()
            {
                OwnerId = ownerId,
                Mark = mark,
                Model = model,
                Registration = registration
            };
            using (var context = new WorkschopContext())
            {
                context.Cars.Add(newCar);
                context.SaveChanges();
            }
        }
        public List<Car> GetCars(int OwnerId)
        {
            using (var context = new WorkschopContext())
            {
                return context.Cars.Where(c => c.OwnerId == OwnerId).ToList();
            }
        }
    }
}
