using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImagesService
    {
        IResult Add(IFormFile file, CarImages carImages);
        IResult Update(IFormFile file, CarImages carImages);
        IResult Delete(CarImages carImages);

        IDataResult<List<CarImages>> GetAll();
        IDataResult<CarImages> GetByImageId(int imageId);
        IDataResult<List<CarImages>> GetByCarId(int carId);


    }
}
