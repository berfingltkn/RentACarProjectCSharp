using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUsersService
    {
        IResult Add(Users user);
        IResult Delete(Users user);
        IResult Update(Users user);
        IDataResult<Users> GetById(int id);
        IDataResult<List<Users>> GetAll();

    }
}
