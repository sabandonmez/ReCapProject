using Core.Utilities.Results;
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
        IDataResult<List<Car>> GetCarDetails(int id);
        IDataResult<List<Car>> GetCarsByColorId(int id);
        IResult Add(Car car);
        IDataResult<List<Car>> GetCarsByCarId(int id);
        IDataResult<List<CarDetailDto>> GetCarDetailDto();
        IDataResult<List<Car>> GetAll();
        IResult Delete(Car car);
        IResult Update(Car car);
        IResult AddTransactionalTest(Car car);



    }
}
