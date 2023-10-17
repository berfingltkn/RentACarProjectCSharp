using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetCarsByBrandId(int brandID);
        List<Car> GetCarsByColorID(int colorID);
        Car GetCarById(int carID);
        void Add(Car car);
        void Update(Car car);
        void Remove(Car car);

    }
}
