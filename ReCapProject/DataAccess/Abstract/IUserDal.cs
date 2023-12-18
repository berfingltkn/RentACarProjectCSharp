using Core.DataAccess;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<Users>
    {
        List<OperationClaims> GetClaims(Users user);
        //veritabanından claimleri çekmek istiyoruz
    }
}
