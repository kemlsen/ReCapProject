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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
            ValidationTool.Validate(new CustomerValidator(), customer);
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(Customer customer)
        {
            if (customer == null)
            {
                return new ErrorResult(Messages.DeletedInvalidCustomer);
            }
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        public IDataResult<Customer> Get(int id)
        {
            var data = _customerDal.Get(p => p.Id == id);
            if (data == null)
            {
                return new ErrorDataResult<Customer>(Messages.InvalidCustomer);
            }
            return new SuccessDataResult<Customer>(data, Messages.CustomerListed);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            if (DateTime.Now.Hour == 1)
            {
                return new ErrorDataResult<List<Customer>>(Messages.MaintenanceTime);
            }
            var data = _customerDal.GetAll();
            return new SuccessDataResult<List<Customer>>(data, Messages.CustomersListed);
        }

        public IResult Update(Customer customer)
        {
            if (customer == null)
            {
                return new ErrorResult(Messages.UpdatedInvalidCustomer);
            }
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}
