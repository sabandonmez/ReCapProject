using Business.Abstract;
using Business.Constans.Messages;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            if (brand.BrandName.Length<2)
            {
                return new ErrorResult(Message.ItemNotListed);
            }
            return new SuccesResult(Message.ItemAdded);
            _brandDal.Add(brand);
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccesResult(Message.ItemDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccesDataResult<List<Brand>>(_brandDal.GetAll(), Message.ItemListed);
        }

        public IDataResult<List<Brand>> GetByBrandId(int id)
        {
            return new SuccesDataResult<List<Brand>>(_brandDal.GetAll(p=>p.BrandId == id), Message.ItemListed);
        }

        public IResult Update(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccesResult(Message.ItemUpdated);
        }
    }
}
