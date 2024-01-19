using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetCarsByBrandId(int brandID);
        IDataResult<List<Car>> GetCarsByColorID(int colorID);
        IDataResult<Car> GetCarById(int carID);
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Remove(Car car);

        IDataResult<List<CarsDetailDTO>> GetCarDetails();

        IDataResult<List<Car>> GetByBrandId(int brandId);
        IDataResult<List<CarsDetailDTO>> GetCarDetailsByCarId(int carId);

        IDataResult<List<CarsDetailDTO>> GetCarDetailsByColorAndByBrand(int colorId, int brandId);
    }
}
