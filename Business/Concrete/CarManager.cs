using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
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
            var data = _carDal.GetAll(p => p.BrandId == id);
            if (data == null)
            {
                return new ErrorDataResult<List<Car>>(Messages.CarInvalid);
            }
            return new ErrorDataResult<List<Car>>(data, Messages.SuccessGetCar);
        }
        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            var data = _carDal.GetAll(p => p.ColorId == id);
            if (data == null)
            {
                return new ErrorDataResult<List<Car>>(Messages.CarInvalid);
            }
            return new SuccessDataResult<List<Car>>(data, Messages.SuccessGetCar);
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            ValidationTool.Validate(new CarValidator(), car);
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);

        }
        public IResult Delete(Car car)
        {
            if (car == null)
            {
                return new ErrorResult(Messages.DeletedInvalidCar);
            }
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }
        public IResult Update(Car car)
        {
            if (car == null)
            {
                return new ErrorResult(Messages.UpdatedInvalidCar);
            }
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 1)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            var data = _carDal.GetAll();
            return new SuccessDataResult<List<Car>>(data, Messages.CarsListed);
        }

        public IDataResult<Car> Get(int id)
        {
            var data = _carDal.Get(p => p.Id == id);
            if (data == null)
            {
                return new ErrorDataResult<Car>(Messages.InvalidCar);
            }
            return new SuccessDataResult<Car>(data, Messages.SuccessGetCar);
        }

        public IDataResult<List<CarDetailDto>> CarDetails()
        {
            if (DateTime.Now.Hour == 1)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }
            var data = _carDal.GetCarDetails();
            return new SuccessDataResult<List<CarDetailDto>>(data, Messages.CarDetail);
        }
    }
}
