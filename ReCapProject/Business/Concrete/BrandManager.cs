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
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        public void Add(Brand brand)
        {
            _brandDal.Add(brand);
            
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand GetBrandById(int brandID)
        {
            return _brandDal.Get(b => b.ID == brandID);
        }

        public void Remove(Brand brand)
        {
            _brandDal.Delete(brand);
        }

        public void Update(Brand brand)
        {
            _brandDal.Update(brand);
        }
    }
}
