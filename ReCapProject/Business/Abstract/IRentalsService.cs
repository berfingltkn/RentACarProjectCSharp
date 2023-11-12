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
    public interface IRentalsService
    {
        IResult Add(Rentals rental);
        IResult Delete(Rentals rental);
        IResult Update(Rentals rental);
        IDataResult<List<Rentals>> GetAll();
        IDataResult<Rentals> GetById(int id);
        IDataResult<List<RentalDetailDto>> GetAllRentalDetails();

    }
}
