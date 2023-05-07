using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using LogisticCompany.Business.Abstract;
using LogisticCompany.Business.Concrete;
using LogisticCompany.Core.Utilities.Interceptors;
using LogisticCompany.DataAccess.Abstract.Repository;
using LogisticCompany.DataAccess.Concrete.Repository;

namespace LogisticCompany.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ActionTypeService>().As<IActionTypeService>();
            builder.RegisterType<MaintenanceService>().As<IMaintenanceService>();
            builder.RegisterType<MaintenanceHistoryService>().As<IMaintenanceHistoryService>();
            builder.RegisterType<PictureGroupService>().As<IPictureGroupService>();
            builder.RegisterType<StatusService>().As<IStatusService>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<VehicleService>().As<IVehicleService>();
            builder.RegisterType<VehicleTypeService>().As<IVehicleTypeService>();
            builder.RegisterType<AuthService>().As<IAuthService>();

            builder.RegisterType<ActionTypeRepository>().As<IActionTypeRepository>();
            builder.RegisterType<MaintenanceRepository>().As<IMaintenanceRepository>();
            builder.RegisterType<MaintenanceHistoryRepository>().As<IMaintenanceHistoryRepository>();
            builder.RegisterType<PictureGroupRepository>().As<IPictureGroupRepository>();
            builder.RegisterType<StatusRepository>().As<IStatusRepository>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<VehicleRepository>().As<IVehicleRepository>();
            builder.RegisterType<VehicleTypeRepository>().As<IVehicleTypeRepository>();


            var assemblyBusiness = System.Reflection.Assembly.GetExecutingAssembly();
            var assemblyDataAccess = System.Reflection.Assembly.Load("LogisticCompany.DataAccess");

            builder.RegisterAssemblyTypes(assemblyBusiness, assemblyDataAccess).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                });
        }
    }
}
