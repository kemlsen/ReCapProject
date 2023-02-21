using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            AddRent();
            //UpdateRent();
        }

        private static void UpdateRent()
        {
            RentalManager rental = new RentalManager(new EfRentalDal());
            rental.Update(new Rental { Id = 2, CarId = 1, CustomerId = 1, RentDate = new DateTime(2022, 01, 01), ReturnDate = new DateTime(2022, 01, 03) });
        }

        private static void AddRent()
        {
            RentalManager rental = new RentalManager(new EfRentalDal());
            rental.Add(new Rental { Id = 3, CarId = 1, CustomerId = 1, RentDate = new DateTime(2022, 08, 08) });
        }

        private static void AddCar()
        {
            CarManager car = new CarManager(new EfCarDal());
            car.Add(new Car { CarName = "320d", ColorId = 1, BrandId = 1, ModelYear = 2015, DailyPrice = 1500, Description = "56 bin kilometre" });
        }

        private static void AddBrand()
        {
            BrandManager brand = new BrandManager(new EfBrandDal());
            brand.Add(new Brand { BrandName = "Bmw" });
        }

        private static void AddCustomer()
        {
            CustomerManager customer = new CustomerManager(new EfCustomerDal());
            customer.Add(new Customer { UserId = 1, CompanyName = "Rea Tech" });
        }

        private static void AddUser()
        {
            UserManager user = new UserManager(new EfUserDal());
            user.Add(new User { FirstName = "Kemal", LastName = "Şen", Email = "kemlsen96@gmail.com", Password = "123456" });
        }

        private static void AddColor()
        {
            ColorManager manager = new ColorManager(new EfColorDal());
            manager.Add(new Color { ColorName = "Siyah" });
        }

    }
}
