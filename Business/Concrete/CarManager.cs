using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            _carDal.GetAll(p => p.BrandId == id);
            return new SuccessDataResult<List<Car>>();
        }
        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            _carDal.GetAll(p => p.ColorId == id);
            return new SuccessDataResult<List<Car>>();
        }
        public IResult Add(Car car)
        {
            if (car.CarName.Length > 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
                return new SuccessResult();
            }
            return new ErrorResult();
        }
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult();
        }
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult();
        }

        public IDataResult<List<Car>> GetAll()
        {
            _carDal.GetAll();
            return new SuccessDataResult<List<Car>>();
        }

        public IDataResult<Car> Get(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.Id == id), Messages.SuccessGetCar);
        }

        public IDataResult<List<CarDetailDto>> CarDetails()
        {
            _carDal.GetCarDetails();
            return new SuccessDataResult<List<CarDetailDto>>();
        }
    }
}
