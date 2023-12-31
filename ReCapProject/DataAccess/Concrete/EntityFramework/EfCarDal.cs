﻿using Core.DataAccess.EntityFramework;
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
    public class EfCarDal : EfEntityRepositoryBase<Car, RentCarDBContext>, ICarDal
    {
        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (RentCarDBContext context = new RentCarDBContext())
            {
                return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
            }
        }
        public List<CarsDetailDTO> GetCarDetails(Expression<Func<CarsDetailDTO,bool>> filter=null)
        {
            using(RentCarDBContext context= new RentCarDBContext())
            {
                var result = from c in context.Cars
                             join co in context.Colors
                             on c.ColorId equals co.ID

                             join b in context.Brands
                             on c.ID equals b.ID
                             select new CarsDetailDTO
                             {
                                BrandName=b.Name,
                                CarName=c.Name,
                                ColorName=co.Name,
                                DailyPrice=c.DailyPrice

                             };
                return result.ToList();

            }
        }

    }
}
