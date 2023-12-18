using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;//Configuration
using Microsoft.IdentityModel.Tokens;


namespace Core.Utilities.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }//API deki appsetting.json dosyasını okur
        private TokenOptions _tokenOptions;//dosyadan okuduklarını nesne olarak tutar.
        private DateTime _accessTokenExpiration;//accessToken ne zaman gerçekleşecek
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            //section->.json dosyasında yazdığımız iki süslü parantez arasındaki section oluyor.
            //burada diyoruz ki appsetting.json un içindeki "TokenOptions" bölümünü al, ve TokenOptions sınıfındaki değerleri kullanarak get le.
            //kısacası appsetting.json daki değerleri TokenOptions class ındaki değerler ile eşle.

        }
        public AccessToken CreateToken(Users user, List<OperationClaims> operationClaims)
        {
            //kullanıcı için bir tane token üretiyoruz.

            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);//token ı oluşturmak için bize bir key gerek. Bu keyi de yazdığımız SecurityKeyHelper sayesinde oluşturduk
            var signingCredentials = SigninCredentialsHelper.CreateSigningCredentials(securityKey);//hangi algoritmayı kullanacağımızı ve anahtarımızın ne olduğunu belirttik. 
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, Users user,
            SigningCredentials signingCredentials, List<OperationClaims> operationClaims)
        {
            var jwt = new JwtSecurityToken(// token oluşturmaya yarıyor
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(Users user, List<OperationClaims> operationClaims)
        {
            //claimler için bir method yaptık, burası önemli
            //claim yetki oluyor. Sadece yetki değil kullanıcıya karşılık gelen bir çok bilgi vardır
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");//başına $ eklersek tırnak içerisine kod yazabiliyoruz.
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());

            return claims;
        }
    }
}
