using System.Reflection;
using Autofac;
using MediatR;
using ToolPedia.Application.Auth.Services;
using ToolPedia.Application.Common.Interfaces;

namespace ToolPedia.Application
{
    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = Assembly.GetExecutingAssembly();

            builder.RegisterType<Mediator>().As<IMediator>().InstancePerLifetimeScope();

            builder
                .RegisterAssemblyTypes(assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>))
                .AsImplementedInterfaces();
            builder.RegisterType<JwtService>().As<IJwtService>();
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>();
            builder.RegisterType<PasswordHasher>().As<IPasswordHasher>();
        }
    }
}
