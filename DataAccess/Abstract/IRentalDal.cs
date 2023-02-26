using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IRentalDal : IEntityRepository<Rental>
    {
        bool isReturn(Rental rental);
        Rental GetLastValue(Rental rental);
    }
}
