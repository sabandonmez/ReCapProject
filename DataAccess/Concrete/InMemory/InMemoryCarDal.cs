using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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
                new Car { Id = 1, BrandId = 2 , ColorId = 1,DailyPrice=100_000,ModelYear="2002",Description="Sedan"},
                new Car { Id = 2, BrandId = 2 , ColorId = 4,DailyPrice=300_000,ModelYear="2009",Description="Hatchback"},
                new Car { Id = 3, BrandId = 1 , ColorId = 2,DailyPrice=350_000,ModelYear="2007",Description="Hatchback"},
                new Car { Id = 4, BrandId = 3 , ColorId = 3,DailyPrice=400_000,ModelYear="2016",Description="Cabrio"},
                new Car { Id = 5, BrandId = 4 , ColorId = 4,DailyPrice=900_000,ModelYear="2022",Description="Pick up"}

            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);

        }

        public List<Car> GetAll()
        {
           return _cars;
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(c => c.Id == id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
            
        }


    }
}
