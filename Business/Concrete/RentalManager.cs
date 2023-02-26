using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var rentableCar = _rentalDal.GetLastValue(rental);
            if (rentableCar == null || _rentalDal.isReturn(rental))
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
            }
            return new ErrorResult(Messages.AddedInvalidRental);

        }

        public IResult Delete(Rental rental)
        {
            if (rental == null)
            {
                return new ErrorResult(Messages.DeletedInvalidRental);
            }
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<Rental> Get(int id)
        {
            var data = _rentalDal.Get(p => p.Id == id);
            if (data == null)
            {
                return new ErrorDataResult<Rental>(Messages.InvalidRental);
            }
            return new SuccessDataResult<Rental>(data, Messages.RentalListed);
        }

        public IDataResult<List<Rental>> GetAll()
        {

            if (DateTime.Now.Hour == 1)
            {
                return new ErrorDataResult<List<Rental>>(Messages.MaintenanceTime);
            }
            var data = _rentalDal.GetAll();
            return new SuccessDataResult<List<Rental>>(data, Messages.RentalsListed);
        }

        public IResult Update(Rental rental)
        {
            if (rental == null)
            {
                return new ErrorResult(Messages.UpdatedInvalidRental);
            }
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
