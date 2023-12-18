using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Encryption
{
    //SecurityKeyHelper; apideki appsetting.json da oluşturduğumuz keyi aslında tam olarak oluşturmuş olmuyoruz. uyduruk bir string veriyoruz, o key i bir byte array haline getirip parametre geçmemiz gerek. 
    //yani kısaca oluşturduğumuz key i byte array haline getirmeye yarıyor
    //bunlar jwt nin ihtiyaç duyduğu yapılar.
    public class SecurityKeyHelper
    {
        //işin içinde şifreleme olan her şeyde byte formatında veri yollamamız gerekiyor.
        //yani asp.net deki jwt nin anlayacağı formata getirmemiz gerekiyor.

        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
            //anahtarlar simetrik ve simetrik olmayan olarak ikiye ayrılıyor. Biz burada simetrik olanı kullanacağımızı söylüyoruz.


        }
    }
}
