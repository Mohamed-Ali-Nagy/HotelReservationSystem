using Autofac;

using HotelReservationSystem.Data;
using HotelReservationSystem.Mediators.Room;
using HotelReservationSystem.Repositories;
using HotelReservationSystem.Services.RoomServices;

namespace Hotel
{
    public class AutoFacModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Context>().InstancePerLifetimeScope();
            builder.RegisterType<RoomService>().As<IRoomService>().InstancePerLifetimeScope();
            builder.RegisterType<RoomMediator>().As<IRoomMediator>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

        }
    }
}
