using Business.Abstract;
using Business.BusinessAspects;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<Car>> GetAll()
        {
           
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

      

        public IDataResult<Car> GetCarById(int carID)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.ID == carID));
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandID)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == brandID));
        }

        public IDataResult<List<Car>> GetCarsByColorID(int colorID)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p=>p.ColorId==colorID));

        }

        [SecuredOperation("admin")]
       [ CacheRemoveAspect("ICarService.Get")]
        public IResult Remove(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdate);
        }

        [SecuredOperation("admin,car.add")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
           // ValidationTool.Validate(new CarValidator(), car);--> bunu ayrı ayrı her cross cutting için yazmaktansa aop ile yukarıdaki attribute u oluşturduk.
            //business code lar gelecek.
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);

           

        }

        public IDataResult<List<CarsDetailDTO>> GetCarDetails()
        {
            var result = new SuccessDataResult<List<CarsDetailDTO>>(_carDal.GetCarDetails(), "SUCCESS");
            return result;
        }

        public IDataResult<List<Car>> GetByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId== brandId));
        }

        public IDataResult<List<CarsDetailDTO>> GetCarDetailsByCarId(int carId)
        {
            return new SuccessDataResult<List<CarsDetailDTO>>(_carDal.GetCarDetailsByCarId(carId));
        }

        public IDataResult<List<CarsDetailDTO>> GetCarDetailsByColorAndByBrand(int colorId, int brandId)
        {
            return new SuccessDataResult<List<CarsDetailDTO>>(_carDal.GetCarDetailsByColorAndByBrand(colorId, brandId));
        }
    }
}
