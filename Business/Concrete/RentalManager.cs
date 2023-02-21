using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            var rentableCar = _rentalDal.GetLastValue(rental);
            if (rentableCar == null|| _rentalDal.isReturn(rental))
            {
                _rentalDal.Add(rental);
                return new SuccessResult();
            }
            return new ErrorResult();

        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<Rental> Get(int id)
        {
            _rentalDal.Get(p => p.Id == id);
            return new SuccessDataResult<Rental>();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            _rentalDal.GetAll();
            return new SuccessDataResult<List<Rental>>();
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }
    }
}
