using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public bool Success { get; }

        public string Message { get; }

        public Result(bool success, string message):this(success)
        {
            //this(succes)-> Aşağıdakı constructer daki yapıyı tekrar buraya yazmaktansa thissuccess) diyip hem aşağıdakini hemde bu constructerın içindekini çalıştırdık. Kendi kodumuzu tekrar etmemiş olduk.
           //Success=success dememize gerek kalmadı
            Message = message;
        }

        public Result(bool success)
        {
            Success = success;
        }
    }
}
