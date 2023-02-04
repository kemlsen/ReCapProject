using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemoryDal
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> { new Car { Id = 1, BrandId = 10, ColorId = 100, ModelYear = 2022, DailyPrice = 3500, Description = "Kaliteli araç" },
            new Car { Id = 2, BrandId = 11, ColorId = 101, ModelYear = 2001, DailyPrice = 1500, Description = "Dandik araç" },};

        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            var deletedCar = _cars.SingleOrDefault(p => p.Id == car.Id);
            _cars.Remove(deletedCar);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            var updatedCar = _cars.SingleOrDefault(p => p.Id == car.Id);
            updatedCar.BrandId = car.BrandId;
            updatedCar.ColorId = car.ColorId;
            updatedCar.ModelYear = car.ModelYear;
            updatedCar.Description = car.Description;
        }
    }
}
