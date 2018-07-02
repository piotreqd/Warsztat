using System;
using System.Collections.Generic;
using System.Text;
using Warsztat.Model;

namespace Warsztat.Controllers
{
    public class PartController
    {
        public void Delete(int partId)
        {
            using (var context = new WorkschopContext())
            {
                try
                {
                    var part = context.Parts.Find(partId);
                    context.Parts.Remove(part);
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
        public void Add(int activityId, string name, decimal price)
        {
            var part = new Part()
            {
                ActivityId = activityId,
                Name = name,
                Price = price
            };
            using(var context = new WorkschopContext())
            {
                context.Parts.Add(part);
                context.SaveChanges();
            }
        }
    }
}
