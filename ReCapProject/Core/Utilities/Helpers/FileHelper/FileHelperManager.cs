using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelperManager : IFileHelper
    {
        public void Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public string Update(IFormFile file, string filePath, string root)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);//eğer dosya var ise dosyayı bulunduğu yerden sil
            }

            return Upload(file, root);
        }

        public string Upload(IFormFile file, string root)
        {
            //root dizin yolu/klasör yoludur.  C:\Users\KullaniciAdi\Documents\Images gibi
            if (file.Length > 0)
            {
                //dosya boş mu değil mi onu kontrol ediyoruz.
                if (!Directory.Exists(root))
                {
                    //root dizin yolunda bir dizinin var olup olmadığını kontrol eder.
                    Directory.CreateDirectory(root);
                    //directory system.IO nun bir class ı, 
                    //eğer dizin yoksa dizin oluştur.
                }
                //eğer dizin varsa;
                string extension = Path.GetExtension(file.FileName);//seçili dosyanın uzantısını elde etmek için kullanılır. Dosya adının uzantısını alır ve geri döndürür.
                string guid = GuidHelper.CreateGuid();//GuidHelper sınıfındaki yazdığımız methodu kullanarak eşsiz isim atadık.
                string filePath = guid + extension;//dosya adı+dosya uzantısı, örneğin berfinPicture.jpg

                using(FileStream fileStream = File.Create(root + filePath))
                {
                    //Filestream nesnesi, dosyanın okunması, yazılması, oluşturulmasını sağlıyor.
                    //belirtilen yolda bir dosya oluşturduk. root+filepath dosyanın tam halini oluşturur.

                    file.CopyTo(fileStream);
                    fileStream.Flush();//arabellekten sildik.
                    return filePath;//dosyanın tam adını döndürüyoruz ki sql e eklenince tam adı eklensin.

                }

            }

            return null;
        }
    }
}
