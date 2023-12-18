using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.IoC
{

    public interface ICoreModule
    {
        void Load(IServiceCollection serviceCollection);//genel bağımlılıları yükleyecek
                                                        //serviceCollection verdik, yükleme işini serviceColection yapıcak.

    }
}
