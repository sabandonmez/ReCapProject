using Business.Abstract;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using Business.Constans.PathConstans;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Constans.Messages;
using Core.Utilities.Business;

namespace Business.Concrete
{
    public class CarImagesManager : ICarImagesService
    {
        private ICarImagesDal _carImagesDal;
        private IFileHelper _fileHelper;

        public CarImagesManager(ICarImagesDal carImageDal, IFileHelper fileHelper)
        {
            _carImagesDal = carImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file, CarImages carImage)
        {
            IResult result = BusinessRules.Run(CheckIfImageLimitExceeded(carImage.CarId));
            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = _fileHelper.Upload(file, PathConstants.ImagesPath);
            carImage.Date = DateTime.Now;
            _carImagesDal.Add(carImage);
            return new SuccessResult("Resim başarıyla yüklendi.");
        }

        public IResult Delete(CarImages carImage)
        {
            _fileHelper.Delete(PathConstants.ImagesPath + carImage.ImagePath);
            _carImagesDal.Delete(carImage);
            return new SuccessResult();
        }

        public IResult Update(IFormFile file, CarImages carImage)
        {
            carImage.ImagePath = _fileHelper.Update(file, PathConstants.ImagesPath + carImage.ImagePath, PathConstants.ImagesPath);
            _carImagesDal.Update(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImages>> GetAll()
        {
            return new SuccessDataResult<List<CarImages>>(_carImagesDal.GetAll());
        }

        public IDataResult<List<CarImages>> GetByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckIfAnyImageExists(carId));
            {
                if (result != null)
                {
                    return new ErrorDataResult<List<CarImages>>(GetDefaultImage(carId).Data);
                }

                return new SuccessDataResult<List<CarImages>>(_carImagesDal.GetAll(c => c.CarId == carId));
            }
        }

        public IDataResult<CarImages> GetByImageId(int imageId)
        {
            return new SuccessDataResult<CarImages>(_carImagesDal.Get(c => c.Id == imageId));
        }

        private IDataResult<List<CarImages>> GetDefaultImage(int carId)
        {
            List<CarImages> defaultImage = new List<CarImages>();
            defaultImage.Add(new CarImages { CarId = carId, Date = DateTime.Now, ImagePath = "wwwroot\\DefaultImage.jpg" });
            return new SuccessDataResult<List<CarImages>>(defaultImage);
        }

        private IResult CheckIfImageLimitExceeded(int carId)
        {
            var result = _carImagesDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }

        private IResult CheckIfAnyImageExists(int carId)
        {
            var result = _carImagesDal.GetAll(c => c.CarId == carId).Any();
            if (result)
            {
                return new SuccessResult();
            }

            return new ErrorResult();
        }
    }
}
