using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _car = new List<Car>()
        {
            new Car(){ID=1,BrandId=1,ColorId=0,DailyPrice=5000,Description="Range Rover",ModelYear=2023},
            new Car(){ID=2,BrandId=1,ColorId=1,DailyPrice=4000,Description="BMW",ModelYear=2022},
            new Car(){ID=3,BrandId=1,ColorId=1,DailyPrice=3000,Description="Tesla",ModelYear=2021},
            new Car(){ID=4,BrandId=1,ColorId=2,DailyPrice=2000,Description="Porsche",ModelYear=2020},
            new Car(){ID=5,BrandId=1,ColorId=2,DailyPrice=1000,Description="Mercedes",ModelYear=2019}
        };

        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car entity)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }



        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }



        public List<Car> GetById(int id)
        {
            throw new NotImplementedException();
        }


        public List<CarsDetailDTO> GetCarDetails(Expression<Func<CarsDetailDTO, bool>> filter = null)
        {
            throw new NotImplementedException();
        }


        public void Update(Car entity)
        {
            throw new NotImplementedException();
        }
    }
}
