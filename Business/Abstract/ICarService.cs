using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetCarsByBrandId(int id);
        List<Car> GetCarsByColorId(int id);
        List<CarDetailDto> CarDetails();
        List<Car> GetAll();
        Car Get(int id);
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
    }
}
