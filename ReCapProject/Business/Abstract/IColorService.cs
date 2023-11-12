﻿using Core.Utilities.Results;
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
        
        IDataResult<List<Color>> GetAll();
        IDataResult<Color>GetColorByID(int colorId);
        IResult Add(Color color);
        IResult Remove(Color color);
        IResult Update(Color color);
       

    }
}
