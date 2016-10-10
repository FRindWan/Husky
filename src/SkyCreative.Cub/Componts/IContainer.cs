using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SkyCreative.Cub.Componts
{
    public interface IContainer
    {
        void Register<TService>(LifeScope lifeScope = LifeScope.Transient);

        void Register<TInterface, TService>(LifeScope lifeScope = LifeScope.Transient)where TService:TInterface;

        void Register(Type service, LifeScope lifeScope = LifeScope.Transient);

        void Register(Type @interface, Type service, LifeScope lifeScope = LifeScope.Transient);

        void Register<TService>(string name, LifeScope lifeScope = LifeScope.Transient);

        void Register<TInterface, TService>(string name, LifeScope lifeScope = LifeScope.Transient)where TService:TInterface;

        void Register(Type service, string name, LifeScope lifeScope = LifeScope.Transient);

        void Register(Type @interface, Type type, string name, LifeScope lifeScope = LifeScope.Transient);

        void Register(Assembly assembly,Func<Type,bool> predicate=null);

        TService Resolver<TService>();

        object Resolver(Type serviceType);

        TService ResolverNamed<TService>(string serviceName);

        object ResolverNamed(string serviceName, Type serviceType);

        bool TryResolver<TService>(out TService instance);

        bool TryResolver(Type type, object instance);

        bool TryResolverNamed(string serviceName, Type serviceType, out object instance);
    }
}
