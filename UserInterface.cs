using System;
using System.Collections.Generic;
using System.Text;
using Warsztat.Controllers;

namespace Warsztat.Model
{
    class UserInterface
    {
        public void PrintOptions()
        {
            Console.WriteLine(" 1 - wyświetl klientów\n"
                            + " 2 - wyświetl auta klienta\n"
                            + " 3 - pokaż wykonywane naprawy\n"
                            + " 4 - generuj kosztorys naprawy\n");
        }

        public void EndOrder()
        {
            Console.WriteLine("Podaj numer zlecenia do zakończenia");
            string textOrderId = Console.ReadLine();
            var orderController = new OrderController();

            try
            {
                int orderId = Int32.Parse(textOrderId);
                orderController.EndOrder(orderId);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
        public void AddOrder()
        {
            Console.WriteLine("Podaj numer naprawianego samochodu");
            string textCarId = Console.ReadLine();
            Console.WriteLine("Podaj nazwę nowego zlecenia");
            string orderName = Console.ReadLine();
            var orderController = new OrderController();

            try
            {
                int carId = Int32.Parse(textCarId);
                orderController.BeginOrder(carId, orderName);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
        public void DeleteCar()
        {
            Console.WriteLine("Podaj numer samochodu do usunięcia");
            string textCarId = Console.ReadLine();
            try
            {
                int carId = Int32.Parse(textCarId);
                var carController = new CarController();
                carController.Delete(carId);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
        public void AddCar()
        {
            Console.WriteLine("Podaj numer klienta :");
            string textOwnerId = Console.ReadLine();
            Console.WriteLine("Podaj markę :");
            string mark = Console.ReadLine();
            Console.WriteLine("Podaj numer model :");
            string model = Console.ReadLine();
            Console.WriteLine("Podaj numer numer rejestracyjny :");
            string registration = Console.ReadLine();
            try
            {
                int ownerId = Int32.Parse(textOwnerId);
                var carController = new CarController();
                carController.Add(ownerId, mark, model, registration);
            }
            catch (Exception exception)
            {

                Console.WriteLine(exception.Message);
            }
        }
        public void PrintCars()
        {
            Console.WriteLine("Podaj numer klienta którego chcesz wyświetlić");
            string textOwnerId = Console.ReadLine();
            try
            {
                int OwnerId = Int32.Parse(textOwnerId);
                var carController = new CarController();
                var cars = carController.GetCars(OwnerId);

                foreach (var car in cars)
                    Console.WriteLine($"Numer {car.Id} Marka {car.Mark} {car.Model} Numer rejestracyjny {car.Registration}");
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
        public void ChangeContact()
        {
            Console.WriteLine("Podaj numer użytkownika :");
            string stringId = Console.ReadLine();
            Console.WriteLine("Nowy numer telefonu :");
            string newPhone = Console.ReadLine();
            try
            {
                int id = Int32.Parse(stringId);
                var ownerController = new OwnerController();
                ownerController.ChangePhoneNumber(id, newPhone);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public void DeleteOwner()
        {
            Console.WriteLine("Podaj numer właściciela do usunięcia :");
            string stringId = Console.ReadLine();
            try
            {
                int id = Int32.Parse(stringId);
                var ownerController = new OwnerController();
                ownerController.Delete(id);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void AddOwner()
        {
            Console.WriteLine("Podaj imię :");
            string name = Console.ReadLine();
            Console.WriteLine("Podaj nazwisko :");
            string surname = Console.ReadLine();
            Console.WriteLine("Podaj numer telefonu :");
            string phoneNumber = Console.ReadLine();
            name.Trim();
            surname.Trim();
            phoneNumber.Trim();

            var ownerController = new OwnerController();
            ownerController.Add(name, surname, phoneNumber);
        }
        public void PrintOwners()
        {
            var ownerController = new OwnerController();
            var owners = ownerController.GetOwners();
            foreach (var owner in owners)
            {
                Console.WriteLine($"Właściciel {owner.Id} Imię : {owner.Name}, Nazwisko : {owner.Surname}, Telefon : {owner.PhoneNumber}");
            }
        }
    }
}
