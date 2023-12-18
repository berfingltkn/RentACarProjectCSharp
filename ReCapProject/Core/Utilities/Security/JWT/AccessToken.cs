using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    //erişim anahtarıdır.
    public class AccessToken
    {
        //accesstoken ı string olarak tutuyoruz.
        //token ı ve token bitiş zamanını tanımlamamız lazım

        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
