using Autofac;
using SmartHealthcare.Api.JWT;
using SmartHealthcare.Infrastructure;
using SmartHealthcare.Service.UserInfo;
using System.Reflection;

namespace SmartHealthcare.Api
{
    public class AutofacModuleRegister :Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var IAppRepository = Assembly.Load(typeof(UserRepository).Assembly.ToString());
            var AppRepository = Assembly.Load(typeof(UserRepository).Assembly.ToString());
            builder.RegisterAssemblyTypes(IAppRepository, AppRepository).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces();

            var IAppServices = Assembly.Load(typeof(UserService).Assembly.ToString());
            var AppServices = Assembly.Load(typeof(UserService).Assembly.ToString());
            builder.RegisterAssemblyTypes(IAppServices, AppServices).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces();

            //var IAppUser = Assembly.Load(typeof(IJwtuser).Assembly.ToString());
            //var AppUser= Assembly.Load(typeof(IJwtuser).Assembly.ToString());
            //builder.RegisterAssemblyTypes(IAppUser, AppUser).Where(x => x.Name.EndsWith("User")).AsImplementedInterfaces();
        }
    }
}
