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
    public class UserManager : IUserService
    {

        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;   
        }


        public IResult Add(User user)
        {

            _userDal.Add(user);
            return new SuccesResult(Message.ItemAdded);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccesResult(Message.ItemDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccesDataResult<List<User>>(_userDal.GetAll(), Message.ItemListed);
        }

        public IDataResult<List<User>> GetByUserId(int id)
        {
            return new SuccesDataResult<List<User>>(_userDal.GetAll(p=> p.UserId== id));
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccesResult(Message.ItemUpdated);
        }
    }
}
