using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult(string message):base(true,message)
        {
            //base ifadesi, bir alt sınıfın üst sınıfına (temel sınıfına) erişim sağlar.
        // base Result u kullanabilmek için çağırdık.
        }
        public SuccessResult():base(true)
        {

        }
    }
}
