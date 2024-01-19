using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        List<CarsDetailDTO> GetCarDetails(Expression<Func<CarsDetailDTO, bool>> filter = null);
        List<CarsDetailDTO> GetCarDetailsByBrandId(int brandId);
        List<CarsDetailDTO> GetCarDetailsByColorId(int colorId);
        List<CarsDetailDTO> GetCarDetailsByCarId(int carId);
        List<CarsDetailDTO> GetCarDetailsByColorAndByBrand(int colorId, int brandId);
    }
}
