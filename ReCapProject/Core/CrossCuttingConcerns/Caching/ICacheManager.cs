using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        //Generik classlar gibi generic methodlarda tutabiliriz.
        T Get<T>(string key); //bir key vericez, bellekte o key e karşılık gelen datayı ver deriz.
        object Get(string key);


        void Add(string key, object value, int duration);
        //value değeri her şey olabileceğinden object olarak tutmak daha mantıklıdır.

        bool IsAdd(string key);//cache de var mı yok mu diye kontrol ediyor

        void Remove(string key);
        void RemoveByPattern(string pattern); //silmesini istediğimiz methodların ismine göre sildireceğiz, yani desen verdik-pattern

    }
}
