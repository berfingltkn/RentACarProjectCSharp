using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Hashing
{//hashingHelper; hash oluşturmaya ve hashi doğrulamaya yarar.
    public class HashingHelper
    {
        //bu class bizim için bir araç. O yüzden çıplak kalabilir
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            //verdiğimiz password un hashini oluşturucak. Saltını da oluşturucak.Biz bir password vericez bize hem passwordHash i hemde passwordSalt ı vericek
            //out keywordunu dışarı verilecek değer gibi düşünebiliriz. Method tarafından döndürülen birden fazla değeri döndürmek için kullanılır. 
            //yani out a boş değer versek bile onu doldurup öyle bize veriyor.

        using( var hmac=new System.Security.Cryptography.HMACSHA512())
            {
                //cryptograph de kullandığımız class a karşılık geliyor
                //kısaca bu yapı verdiğimiz bir password değerine göre salt ve hashini oluşturuyor.
                passwordSalt = hmac.Key;//salt olarak ilgili algoritmanın key değerini kullanıyoruz, isteyen başka bir şeyde kullanabilir
                //her kullanıcı için başka bir key değeri oluşturur
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));//encoding.UTF8.getbyte dediğimizde yazılan password u byte değerine çeviriyor.

            }
        }

        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            //password hash i doğrula 
            //burada out olmamalı çünkü bu değerleri biz vereceğiz
            //bu class da veritabanındaki hash ile kullanıcının gönderdiği password un hash i uyuşuyor mu onu kontrol ediyoruz.
            //eğer iki hash değeri eşitse true
            //string password parametresi kullanıcının sonradan girdiği parola oluyor.
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))//doğrulama yapacağımızdan parametre içerisine key i vermemiz gerekiyor, yani salt ı veriyoruz.
            {
                //hesaplanan hash- computeHash
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                for(int i = 0; i < computedHash.Length; i++)
                {//hesaplanan hash in tüm değerlerini tek tek dolaş.
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                    
                }
                return true;
            }

            }
    }
}
