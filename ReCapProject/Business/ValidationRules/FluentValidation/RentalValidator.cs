using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator:AbstractValidator<Rentals>
    {
        public RentalValidator()
        {
            RuleFor(r => r.CarID).GreaterThan(0);
            RuleFor(r => r.CustomerID).GreaterThan(0);
            RuleFor(r => r.RentDate).NotEmpty();
            
        }
    }
}
