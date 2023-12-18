using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{

    public class EfUserDal : EfEntityRepositoryBase<Users, RentCarDBContext>, IUserDal
    {
        public List<OperationClaims> GetClaims(Users user)
        {
            using (var context = new RentCarDBContext())
            {

                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaims { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

                //operaitonCLaims ve User;OperationClaims i joinleyip, userID si user id ye eşit olanları alıp OperatiınCLaim olarak return ediyor.


            }
        }
    }
}
