using Business.Abstract;
using Business.Concrete;
using Business.Constants;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            ICarService carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();

            if (result.Success == true)
            {
                foreach(var car in result.Data)
                {
                    Console.WriteLine(car);
                }
            }
            else { Console.WriteLine(result.Message); }

            //    AddCar();

            //static void AddCar()
            //    {
            //        ICarService carManager = new CarManager(new EfCarDal());
            //        var car1 = new Car();
            //        carManager.Add(new Car() {
            //        Name="deneme",
            //        BrandId=7,
            //        ColorId=4,
            //        DailyPrice=10,
            //        Description="deneme",
            //        ID=99,
            //        ModelYear=2030,


            //        });
            //        Console.WriteLine(Messages.CarAdded);
            //    }


            //ICarService carManager = new CarManager(new EfCarDal());
            //var result = carManager.GetCarById(1);
            //if (result.Success)
            //{
            //    Car car = result.Data;
            //    Console.WriteLine(car.Name);
            //}
        }
    }
}
