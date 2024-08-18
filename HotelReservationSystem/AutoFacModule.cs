using Autofac;

using HotelReservationSystem.Data;
using HotelReservationSystem.Repositories;
using HotelReservationSystem.Services.ReservationServices;

namespace Hotel
{
    public class AutoFacModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Context>().InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(IReservationService).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();

        }
    }
}
