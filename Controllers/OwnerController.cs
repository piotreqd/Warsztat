using System;
using System.Collections.Generic;
using System.Linq;
using Warsztat.Model;

namespace Warsztat.Controllers
{
    public class OwnerController
    {
        public void ChangePhoneNumber(int id, string newPhoneNumber)
        {
            using (var context = new WorkschopContext())
            {
                var changedOwner = context.Owners.Find(id);
                if (changedOwner != null)
                {
                    changedOwner.PhoneNumber = newPhoneNumber;
                    context.SaveChanges();
                }
            }
        }
        public void Delete(int id)
        {
            using (var context = new WorkschopContext())
            {
                var deletedOwner = context.Owners.Find(id);
                try
                {
                    context.Remove(deletedOwner);
                    context.SaveChanges();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }
        public void Add(string name, string surname, string phoneNumber)
        {
            var newOwner = new Owner()
            {
                Name = name,
                Surname = surname,
                PhoneNumber = phoneNumber
            };

            using (var context = new WorkschopContext())
            {
                context.Owners.Add(newOwner);
                context.SaveChanges();
            }
        }
        public List<Owner> GetOwners()
        {
            using (var context = new WorkschopContext())
            {
                return context.Owners.ToList();
            }
        }
    }
}
