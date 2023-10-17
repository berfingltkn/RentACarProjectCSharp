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
    public class ColorManager : IColorService
    {
        
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        public void Add(Color color)
        {
            _colorDal.Add(color);
        }

        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }

        public Color GetColorByID(int colorId)
        {
            return _colorDal.Get(p => p.ID == colorId);//getAll yapılmaz buraya, yapınca hata verdi
        }

        public void Remove(Color color)
        {
            _colorDal.Delete(color);
        }

        public void Update(Color color)
        {
            _colorDal.Update(color);
        }
    }
}
