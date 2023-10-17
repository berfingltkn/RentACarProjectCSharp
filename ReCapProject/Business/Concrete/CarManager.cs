using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;

        } 
        public void Add(Car car)
        {
            if(car.Name?.Length>=2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
                Console.WriteLine("The car has been added successfully");

            }
            else
            {
                Console.WriteLine("The name of the car must be a least 2 characters and the daily price must be greater than 0");

            }
            
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public Car GetCarById(int carID)
        {
            return _carDal.Get(p => p.ID == carID);
        }

        public List<Car> GetCarsByBrandId(int brandID)
        {
            return _carDal.GetAll(p => p.BrandId == brandID);
        }

        public List<Car> GetCarsByColorID(int colorID)
        {
            return _carDal.GetAll(p=>p.ColorId==colorID);
        }

        public void Remove(Car car)
        {
            _carDal.Delete(car);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
