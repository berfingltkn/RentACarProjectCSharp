using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logigcs) 
        {
            foreach(var logic in logigcs)
            {
                if (!logic.Success)//başarısız olan iş kurallarım var ise
                {
                    return logic;//mevcut hata varsa onu döndür.
                }

            }

            return null;//tüm kurallar başarılı ise null döndür
        }
    }
}
