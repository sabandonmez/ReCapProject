using Business.Abstract;
using Business.Constans.Messages;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal car)
        {
            _carDal = car;
        }

        public IResult Add(Car car)
        {
            if (car.BrandModel.Length<2)
            {
                return new SuccesResult(Message.CarIsNotAdded);
            }
            return new SuccesResult(Message.CarAdded);
            _carDal.Add(car);
        }
        public IDataResult<List<Car>> GetCarDetails(int id)
        {
            return new SuccesDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccesDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id));
        }
        public IDataResult<List<Car>> GetCarsByCarId(int id)
        {
            return new SuccesDataResult<List<Car>>(_carDal.GetAll(p => p.CarId == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailDto()
        {
            return new SuccesDataResult<List<CarDetailDto>>(_carDal.GetCarDetailDto());
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==18)
            {
                return new ErrorDataResult<List<Car>>(Message.CarsNotListed);
            }
            return new SuccesDataResult<List<Car>>(_carDal.GetAll(),Message.CarsListed);
        }
    }
}
