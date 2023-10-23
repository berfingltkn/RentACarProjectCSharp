using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //IColorService colorService = new ColorManager(new EfColordal());
            //ICarService carService = new CarManager(new EfCarDal());
            IBrandService brandService = new BrandManager(new EfBrandDal());

            //Add(carService);
            //AddColor(colorService);
            Add(brandService);

            //carService.GetAll();
            //colorService.GetAll();
            //brandService.GetAll();

            //static void Add(ICarService carService)
            //{
            //    carService.Add(new Car
            //    {
            //        DailyPrice = 2000,
            //        Name = "RangeRover",
            //        BrandId = 1,
            //        ColorId = 1,
            //        Description = "cool car",
            //        ID = 1,
            //        ModelYear = 2023,

            //    });



            //}

          
           // static void AddColor(IColorService colorService)
           //{
           //     colorService.Add(new Color
           //     {
           //       ID = 2,
           //       Name = "Purple"

           //     });
                
           // }
            static void Add(IBrandService brandService)
            {
                brandService.Add(new Brand
               {
                    ID=1,Name="Land Rove"

              });

            }
        }
    }
}
