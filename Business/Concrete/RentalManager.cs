using Business.Abstract;
using Core.Utilities.Results;
using Business.Constans.Messages;
using DataAccess.Abstract;
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
            _rentalDal=rentalDal;
        }

        public IResult Add(Rental rental)
        {
            if (rental.ReturnDate!=null)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Message.ItemAdded);
            }
            else
                return new ErrorResult(Message.ItemNotAdded);

        }

        public IResult Delete(Rental rental)
        {
            if (rental.ReturnDate != null)
            {
                _rentalDal.Delete(rental);
                return new SuccessResult(Message.ItemDeleted);
            }
            else
                return new ErrorResult(Message.ItemNotDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Message.ItemListed);

        }

        public IDataResult<List<Rental>> GetByRentalId(int id)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(p=> p.RentalId==id));

        }

        public IResult Update(Rental rental)
        {
            if (rental.RentDate!=null)
            {
                _rentalDal.Update(rental);
                return new SuccessResult(Message.ItemUpdated);
            }
            else
                return new ErrorResult(Message.ItemNotUpdated);
        }
    }
}
