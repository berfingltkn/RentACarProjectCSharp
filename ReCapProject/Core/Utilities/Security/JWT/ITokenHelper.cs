using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(Users user, List<OperationClaims> operationClaims);

        //diyelim ki kullanıcı nickname password yazdı login e bastı, API ye gönderir.
        //Api de CreateToken operasyonu çalışır, eğer doğruysa ilgili kullanıcı (user) için db ye gider db de bu kullanıcının claimlerini bulur(OperationClaim)
        //bulduktan sonra orada bir jwt oluşturur ve bunu gönderir.


    }
}
