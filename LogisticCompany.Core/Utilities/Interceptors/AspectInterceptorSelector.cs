using Castle.DynamicProxy;
using LogisticCompany.Core.Aspects.Autofac.Exception;
using System.Reflection;

namespace LogisticCompany.Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);
            classAttributes.Add(new ExceptionLogAspect { Priority = -1 });

            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}