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
            ICarService carService = new CarManager(new EfCarDal());
            Add(carService);
            static void Add(ICarService carService)
            {
                carService.Add(new Car
                {
                    DailyPrice = 2000,
                    Name = "RangeRover",
                    BrandId = 1,
                    ColorId = 1,
                    Description = "cool car",
                    ID = 1,
                    ModelYear = 2023,

                });

            }

        }
    }
}
