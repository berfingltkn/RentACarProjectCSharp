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
    public class EfCarDal : EfEntityRepositoryBase<Car, RentCarDBContext>, ICarDal
    {
        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (RentCarDBContext context = new RentCarDBContext())
            {
                return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
            }
        }
        public List<CarsDetailDTO> GetCarDetails(Expression<Func<CarsDetailDTO, bool>> filter = null)
        {
            using (RentCarDBContext context = new RentCarDBContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.ID

                             join co in context.Colors
                             on c.ColorId equals co.ID

                             select new CarsDetailDTO
                             {
                                 ID = c.ID,
                                 BrandName = b.Name,
                                 ColorName = co.Name,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 BrandId = b.ID,
                                 Name = c.Name,
                                 ColorId = co.ID,
                                 Description = c.Description,
                                 ImagePath = (from m in context.CarImages where m.CarId == c.ID select m.ImagePath).FirstOrDefault()


                             };
                return result.ToList();

            }
        }

        public List<CarsDetailDTO> GetCarDetailsByBrandId(int brandId)
        {
            using (RentCarDBContext context = new RentCarDBContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.ID
                             join co in context.Colors
                             on c.ColorId equals co.ID
                             where b.ID == brandId
                             select new CarsDetailDTO
                             {
                                 ID = c.ID,
                                 BrandName = b.Name,
                                 ColorName = co.Name,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 BrandId = b.ID,
                                 Name = c.Name,
                                 ColorId = co.ID,
                                 Description = c.Description,
                                 ImagePath = (from m in context.CarImages where m.CarId == c.ID select m.ImagePath).FirstOrDefault()
                             };
                return result.ToList();
            }
        }

        public List<CarsDetailDTO> GetCarDetailsByCarId(int carId)
        {
            using (RentCarDBContext context = new RentCarDBContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.ID
                             join co in context.Colors
                             on c.ColorId equals co.ID
                             where c.ID == carId
                             select new CarsDetailDTO
                             {
                                 ID = c.ID,
                                 BrandName = b.Name,
                                 ColorName = co.Name,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 BrandId = b.ID,
                                 Name = c.Name,
                                 ColorId = co.ID,
                                 Description = c.Description,
                                 ImagePath = (from m in context.CarImages where m.CarId == c.ID select m.ImagePath).FirstOrDefault()
                             };
                return result.ToList();
            }
        }

        public List<CarsDetailDTO> GetCarDetailsByColorAndByBrand(int colorId, int brandId)
        {

            using (RentCarDBContext context = new RentCarDBContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.ID
                             join co in context.Colors
                             on c.ColorId equals co.ID
                             where co.ID == colorId & b.ID == brandId
                             select new CarsDetailDTO
                             {
                                 ID = c.ID,
                                 BrandName = b.Name,
                                 ColorName = co.Name,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 BrandId = b.ID,
                                 Name = c.Name,
                                 ColorId = co.ID,
                                 Description = c.Description,
                                 ImagePath = (from m in context.CarImages where m.CarId == c.ID select m.ImagePath).FirstOrDefault()
                             };
                return result.ToList();
            }
        }

        public List<CarsDetailDTO> GetCarDetailsByColorId(int colorId)
        {
            using (RentCarDBContext context = new RentCarDBContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.ID
                             join co in context.Colors
                             on c.ColorId equals co.ID
                             where c.ColorId == colorId
                             select new CarsDetailDTO
                             {
                                 ID = c.ID,
                                 BrandName = b.Name,
                                 ColorName = co.Name,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 BrandId = b.ID,
                                 Name = c.Name,
                                 ColorId = co.ID,
                                 Description = c.Description,
                                 ImagePath = (from m in context.CarImages where m.CarId == c.ID select m.ImagePath).FirstOrDefault()
                             };
                return result.ToList();
            }
        }
    }
}
