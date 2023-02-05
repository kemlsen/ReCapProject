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
            //AddBrand();
            //AddColor();
            //AddCar();
            CarManager manager = new CarManager(new EfCarDal());
            foreach (var cars in manager.CarDetails())
            {
                Console.WriteLine(cars.CarName + " - " + cars.BrandName + " - " + cars.ColorName);
            }
        }

        private static void AddCar()
        {
            CarManager manager = new CarManager(new EfCarDal());
            manager.Add(new Car { CarName = "320d", BrandId = 1, ColorId = 1, DailyPrice = 2650, ModelYear = 2012, Description = "Çok iyi bir araba" });
        }

        private static void AddColor()
        {
            ColorManager manager = new ColorManager(new EfColorDal());
            manager.Add(new Color { ColorName = "Siyah" });
        }

        private static void AddBrand()
        {
            BrandManager manager = new BrandManager(new EfBrandDal());
            manager.Add(new Brand { BrandName = "BMW" });
        }
    }
}
