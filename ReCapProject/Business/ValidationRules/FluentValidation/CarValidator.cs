using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        //hangi nesne için validator yazıyorsak kuralları buraya yazıyoruz.
        public CarValidator()
        {
            RuleFor(c => c.BrandId).GreaterThan(0);
            RuleFor(c => c.ColorId).GreaterThan(0);
            RuleFor(c => c.ModelYear).GreaterThanOrEqualTo((short)1800);
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(0);
            RuleFor(c => c.Description).MinimumLength(0);
        }
    }
}
