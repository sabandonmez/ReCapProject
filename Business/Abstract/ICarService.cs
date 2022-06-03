using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetCarDetails(int id);
        List<Car> GetCarsByColorId(int id);
        void Add(Car car);
        List<Car> GetCarsByCarId(int id);
        List<CarDetailDto> GetCarDetails();
    }
}
