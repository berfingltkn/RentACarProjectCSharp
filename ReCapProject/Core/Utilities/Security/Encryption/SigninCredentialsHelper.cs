using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Encryption
{
    //
    public class SigninCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            //signing imzalama demektir.
            //bir sisteme girebilmek için elimizde olanlar Credentialdır. Anahtardır
            //bir key veriyoruz onu imzalama nesnesine döndürmüş oluyor.

            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
            //burada asp.net e diyoruz ki sen hashing işlemi yapıcaksın anahtar olarak verdiğim securityKey i kullan, şifreleme olarak da güvenlik algoritmalarından sha512 yi kullan diyoruz.

        }
    }
}
