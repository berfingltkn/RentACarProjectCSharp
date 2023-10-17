using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IColorService
    {
        
        List<Color> GetAll();
        Color GetColorByID(int colorId);
        void Add(Color color);
        void Remove(Color color);
        void Update(Color color);
       

    }
}
