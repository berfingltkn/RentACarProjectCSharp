using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<Users> Register(UserForRegisterDto userForRegisterDto, string password);//sign in de olabilmeli,
        IDataResult<Users> Login(UserForLoginDto userForLoginDto);//login de olabilmeli
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(Users user);
    }
}
