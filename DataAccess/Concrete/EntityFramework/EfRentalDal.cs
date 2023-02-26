using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapProjectContext>, IRentalDal
    {
        public Rental GetLastValue(Rental rental)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                return context.Rentals.OrderBy(p => p.Id).LastOrDefault(p => p.CarId == rental.CarId);
            }
        }

        public bool isReturn(Rental rental)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                //var result = context.Rentals.OrderByDescending(p => p.Id).FirstOrDefault(p => p.CustomerId == rental.CustomerId && p.CustomerId == rental.CustomerId && p.CarId == rental.CarId);
                var result = context.Rentals.OrderBy(p => p.Id).LastOrDefault(p => p.CarId == rental.CarId);
                if (result.ReturnDate == null)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
