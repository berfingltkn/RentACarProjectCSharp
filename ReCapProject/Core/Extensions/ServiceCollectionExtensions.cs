using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependenctResolvers(this IServiceCollection serviceCollection, ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(serviceCollection);
                //her bir modul için modulu yükle
                //yani birden fazla modulu ekleyebiliriz. 

            }

            return ServiceTool.Create(serviceCollection);

            //core katmanı da dahil olmak üzere ekleyeceğimiz bütün injectionları bir arada toplayabileceğimiz bir yapıya dönüştü.
        }
    }
}
