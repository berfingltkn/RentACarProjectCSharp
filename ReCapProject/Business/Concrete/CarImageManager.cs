using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImagesService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal,IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }
        public IResult Add(IFormFile file, CarImages carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimit(carImage.CarId));//mevcut iş kuralı varsa onu çalıştırır.
            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = _fileHelper.Upload(file,PathConstants.ImagesPath);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult("image uploaded successfully :)");

            
        }

        public IResult Delete(CarImages carImages)
        {
            _fileHelper.Delete(PathConstants.ImagesPath + carImages.ImagePath);
            //pathconstants.ImagePath ifadesi, resim dosyalarının bulunduğu dosya yolunu temsil eder, carimage.ımagepath ise silinecek resim dosyasının yolunu içerir. Bu iki ifade birleştirilerek silinecek resim dosyasının tam yolu elde edilir

            _carImageDal.Delete(carImages);
            return new SuccessResult();
        }

        public IResult Update(IFormFile file, CarImages carImages)
        {
            carImages.ImagePath = _fileHelper.Update(file, PathConstants.ImagesPath + carImages.ImagePath, PathConstants.ImagesPath);
            //mevcut resim dosyalarının bulunduğu klasor yoluna yeni resim yolu eklenir
            _carImageDal.Update(carImages);
            return new SuccessResult();
        }

        public IDataResult<List<CarImages>> GetAll()
        {
            return new SuccessDataResult<List<CarImages>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImages>> GetByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckCarImage(carId));
            if (result != null)
            {
                //eğer araba resmi varsa hata
                return new ErrorDataResult<List<CarImages>>(GetDefaultImage(carId).Data);
            }
            //eger araba resmi yoksa default resmi getiriyor
            return new SuccessDataResult<List<CarImages>>(_carImageDal.GetAll(c => c.CarId == carId));
        }

        public IDataResult<CarImages> GetByImageId(int imageId)
        {
            return new SuccessDataResult<CarImages>(_carImageDal.Get(x=>x.Id==imageId));
        }

        private IResult CheckIfCarImageLimit(int carId)
        {
            //maximum resim boyutunu kontrol ediyor. eğer bir arabanın 5 den fazla resmi varsa error
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        private IResult CheckCarImage(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }


       private IDataResult<List<CarImages>> GetDefaultImage(int carId)
       {
            List<CarImages> carImage = new List<CarImages>();
            carImage.Add(new CarImages
            {
                CarId = carId,
                Date = DateTime.Now,
                ImagePath = "DefaultImage.jpg"
            }) ;

            return new SuccessDataResult<List<CarImages>>(carImage);
       }
    }
}
