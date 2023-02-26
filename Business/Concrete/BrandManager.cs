using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            ValidationTool.Validate(new BrandValidator(), brand);
            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        public IResult Delete(Brand brand)
        {
            if (brand == null)
            {
                return new ErrorResult(Messages.DeletedInvalidBrand);
            }
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }

        public IDataResult<Brand> Get(int id)
        {
            var data = _brandDal.Get(p => p.Id == id);
            if (data == null)
            {
                return new ErrorDataResult<Brand>(Messages.InvalidBrand);
            }
            return new SuccessDataResult<Brand>(data, Messages.BrandListed);

        }

        public IDataResult<List<Brand>> GetAll()
        {
            if (DateTime.Now.Hour == 1)
            {
                return new ErrorDataResult<List<Brand>>(Messages.MaintenanceTime);
            }
            var data = _brandDal.GetAll();
            return new SuccessDataResult<List<Brand>>(data, Messages.BrandsListed);
        }

        public IResult Update(Brand brand)
        {
            if (brand == null)
            {
                return new ErrorResult(Messages.UpdatedInvalidBrand);
            }
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }
    }
}
