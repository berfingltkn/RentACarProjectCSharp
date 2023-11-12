using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ErrorResult : Result
    {
        public ErrorResult(string message) : base(false, message)
        {
            //base ifadesi, bir alt sınıfın üst sınıfına (temel sınıfına) erişim sağlar.
            // base Result u kullanabilmek için çağırdık.
        }
        public ErrorResult() : base(false)
        {

        }
    }
}
