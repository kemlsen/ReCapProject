using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            if (color == null)
            {
                return new ErrorResult(Messages.AddedInvalidColor);
            }
            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Delete(Color color)
        {
            if (color == null)
            {
                return new ErrorResult(Messages.DeletedInvalidColor);
            }
            _colorDal.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);
        }

        public IDataResult<Color> Get(int id)
        {
            var data = _colorDal.Get(p => p.Id == id);
            if (data == null)
            {
                return new ErrorDataResult<Color>(Messages.InvalidColor);
            }
            return new SuccessDataResult<Color>(data, Messages.ColorListed);
        }

        public IDataResult<List<Color>> GetAll()
        {
            if (DateTime.Now.Hour == 1)
            {
                return new ErrorDataResult<List<Color>>(Messages.MaintenanceTime);
            }
            var data = _colorDal.GetAll();
            return new SuccessDataResult<List<Color>>(data, Messages.ColorsListed);
        }

        public IResult Update(Color color)
        {
            if (color == null)
            {
                return new ErrorResult(Messages.UpdatedInvalidColor);
            }
            _colorDal.Update(color);
            return new SuccessResult(Messages.ColorUpdated);
        }
    }
}
