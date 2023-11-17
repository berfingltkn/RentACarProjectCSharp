using Castle.DynamicProxy;
using System;
using System.Linq;
using System.Reflection;

namespace Core.Utilities.Interceptors
{
    public partial class Class1
    {
        public class AspectInterceptorSelector : IInterceptorSelector
        {
            public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
            {
                var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>//class ın attribute larını oku
                    (true).ToList();
                var methodAttributes = type.GetMethod(method.Name)//ilgili methodun attribute larını oku
                                                                  //ve onları bir listeye koy.
                    .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
                classAttributes.AddRange(methodAttributes);

                return classAttributes.OrderBy(x => x.Priority).ToArray();
            }
        }
    }
}
