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
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            if (user == null)
            {
                return new ErrorResult(Messages.AddedInvalidUser);
            }
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            if (user == null)
            {
                return new ErrorResult(Messages.DeletedInvalidUser);
            }
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<User> Get(int id)
        {
            var data = _userDal.Get(p => p.Id == id);
            if (data == null)
            {
                return new ErrorDataResult<User>(Messages.InvalidUser);
            }
            return new SuccessDataResult<User>(data, Messages.UserListed);
        }

        public IDataResult<List<User>> GetAll()
        {
            if (DateTime.Now.Hour == 1)
            {
                return new ErrorDataResult<List<User>>(Messages.MaintenanceTime);
            }
            var data = _userDal.GetAll();
            return new SuccessDataResult<List<User>>(data, Messages.UsersListed);
        }

        public IResult Update(User user)
        {
            if (user == null)
            {
                return new ErrorResult(Messages.UpdatedInvalidUser);
            }
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
