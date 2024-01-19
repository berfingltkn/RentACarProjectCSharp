using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalsDal : EfEntityRepositoryBase<Rentals, RentCarDBContext>, IRentalsDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RentCarDBContext context = new RentCarDBContext())
            {
                var result = from ca in context.Cars
                             join b in context.Brands
                             on ca.BrandId equals b.ID
                             join re in context.Rentals
                             on ca.ID equals re.Id
                             join co in context.Colors
                             on ca.ColorId equals co.ID
                             from u in context.Users
                             join cu in context.Customers
                             on u.Id equals cu.UserID
                             select new RentalDetailDto
                             {
                                 CarId = ca.ID,
                                 BrandId = b.ID,
                                 ColorName = co.Name,
                                 BrandName = b.Name,
                                 ModelName = ca.Name,
                                 RentalId = re.Id,
                                 RentDate = re.RentDate,
                                 ReturnDate = re.ReturnDate,
                                 CustomerName = u.FirstName,
                                 CustomerLastname = u.LastName

                             };
                return result.ToList();
            }
        }
    }
}
