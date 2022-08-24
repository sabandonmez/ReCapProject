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
    public class ColorManager : IColorService
    {

        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;

        }


        public IResult Add(Color color)
        {
            if (color.ColorName.Length<1)
            {
                return new ErrorResult(Message.ItemNotAdded);
            }
            _colorDal.Add(color);
            return new SuccessResult(Message.ItemAdded);

            
        }

        public IResult Delete(Color color)
        {
            //Business Codes..
            _colorDal.Add(color);
            return new SuccessResult(Message.ItemDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(),Message.ItemListed);
        }

        public IDataResult<List<Color>> GetByColorId(int id)
        {     
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(p=> p.ColorId == id));
        }

        public IResult Update(Color color)
        {
            //Business Codes..
            _colorDal.Update(color);
            return new SuccessResult(Message.ItemUpdated);
        }
    }
}
