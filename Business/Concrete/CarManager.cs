using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car carDal)
        {
            if (carDal.BrandModel.Length>=2 && carDal.DailyPrice > 0)
            {
                _carDal.Add(carDal);
            }
            else
            {
                Console.WriteLine("Yanlış yada Eksik ifade girdiniz.");
            }
        }
        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(p => p.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(p => p.ColorId == id);
        }
        public List<Car> GetCarsByCarId(int id)
        {
            return _carDal.GetAll(p => p.CarId == id);
        }

    }
}
