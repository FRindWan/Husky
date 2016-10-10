using Autofac;
using Autofac.Builder;
using SkyCreative.Cub.Components;
using SkyCreative.Cub.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyCreative.Cub.ThirdParty.Autofacs
{
    public class AutofacContainer: Components.IContainer
    {
        private Autofac.IContainer container;

        public AutofacContainer()
        {
            this.container = new ContainerBuilder().Build();
        }

        public AutofacContainer(ContainerBuilder builder)
        {
            Ensure.NotNull(builder, "builder");

            this.container = builder.Build();
        }

        public void Register<TService>(LifeScope lifeScope = LifeScope.Transient)
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<TService>().AsSelf().SetLifeScope(lifeScope);
            builder.Update(container);
        }

        public void Register<TInterface, TService>(LifeScope lifeScope = LifeScope.Transient)where TService:TInterface
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<TService>().As<TInterface>().SetLifeScope(lifeScope);
            builder.Update(container);
        }

        public void Register(Type service, LifeScope lifeScope = LifeScope.Transient)
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType(service).AsSelf().SetLifeScope(lifeScope);
            builder.Update(container);
        }

        public void Register(Type @interface, Type service, LifeScope lifeScope = LifeScope.Transient)
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType(service).As(@interface).SetLifeScope(lifeScope);
            builder.Update(container);
        }

        public void Register<TService>(string name, LifeScope lifeScope = LifeScope.Transient)
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<TService>().Named(name,typeof(TService)).SetLifeScope(lifeScope);
            builder.Update(container);
        }

        public void Register<TInterface, TService>(string name, LifeScope lifeScope = LifeScope.Transient) where TService : TInterface
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<TService>().As<TInterface>().Named(name, typeof(TInterface)).SetLifeScope(lifeScope);
            builder.Update(container);
        }

        public void Register(Type service, string name, LifeScope lifeScope = LifeScope.Transient)
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType(service).Named(name, service).SetLifeScope(lifeScope);
            builder.Update(container);
        }

        public void Register(Type @interface, Type type, string name, LifeScope lifeScope = LifeScope.Transient)
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType(type).As(@interface).Named(name, @interface).SetLifeScope(lifeScope);
            builder.Update(container);
        }

        public void Register(System.Reflection.Assembly assembly, Func<Type, bool> predicate = null)
        {
            ContainerBuilder builder = new ContainerBuilder();
            if (predicate == null)
                builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces();
            else
                builder.RegisterAssemblyTypes(assembly).Where(predicate).AsImplementedInterfaces();
            builder.Update(container);
        }

        public void RegisterInstance<TInterface, TService>(TService instace, string serviceName = null) where TService : class, TInterface
        {
            ContainerBuilder builder = new ContainerBuilder();
            
            if (string.IsNullOrWhiteSpace(serviceName))
                builder.RegisterInstance<TService>(instace).As<TInterface>();
            else
                builder.RegisterInstance<TService>(instace).As<TInterface>().Named<TInterface>(serviceName);
            builder.Update(container);
        }

        public TService Resolver<TService>()
        {
            return this.container.Resolve<TService>();
        }

        public object Resolver(Type serviceType)
        {
            return this.container.Resolve(serviceType);
        }


        public TService ResolverNamed<TService>(string serviceName)
        {
            return this.container.ResolveNamed<TService>(serviceName);
        }

        public object ResolverNamed(string serviceName, Type serviceType)
        {
            return this.container.ResolveNamed(serviceName, serviceType);
        }

        public bool TryResolver<TService>(out TService instance)
        {
            return this.TryResolver<TService>(out instance);
        }

        public bool TryResolver(Type type, object instance)
        {
            return this.TryResolver(type,instance);
        }

        public bool TryResolverNamed(string serviceName, Type serviceType, out object instance)
        {
            throw new NotImplementedException();
        }
    }

    public static class AutofacLiftStyleExetension
    {
        public static IRegistrationBuilder<TLimit, TReflectionActivatorData, TStyle> SetLifeScope<TLimit, TReflectionActivatorData, TStyle>(this IRegistrationBuilder<TLimit, TReflectionActivatorData, TStyle> builder, LifeScope lifeScope)
        {
            if (lifeScope == LifeScope.Single)
            {
                return builder.SingleInstance();
            }

            return builder;
        }
    }
}
