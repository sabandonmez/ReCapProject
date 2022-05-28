using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>

            {
                new Car { CarId = 1, BrandId = 2 , ColorId = 1,DailyPrice=100000,ModelYear="2002",Description="Sedan"},
                new Car { CarId = 2, BrandId = 2 , ColorId = 4,DailyPrice=300000,ModelYear="2009",Description="Hatchback"},
                new Car { CarId  = 3, BrandId = 1 , ColorId = 2,DailyPrice=350000,ModelYear="2007",Description="Hatchback"},
                new Car { CarId  = 4, BrandId = 3 , ColorId = 3,DailyPrice=400000,ModelYear="2016",Description="Cabrio"},
                new Car { CarId  = 5, BrandId = 4 , ColorId = 4,DailyPrice=900000,ModelYear="2022",Description="Pick up"}

            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);

        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
           return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(c => c.CarId == id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
            
        }


    }
}
