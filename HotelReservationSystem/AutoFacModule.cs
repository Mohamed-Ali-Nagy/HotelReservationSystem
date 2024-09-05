using Autofac;
using HotelReservationSystem.Data;
using HotelReservationSystem.Repositories;
using HotelReservationSystem.Services.ReservationServices;
using HotelReservationSystem.Mediators.Room;
using HotelReservationSystem.Services.RoomServices;
using HotelReservationSystem.Services.ReviewService;
using HotelReservationSystem.Mediators.ReviewMediators;
using HotelReservationSystem.Mediators.Reservation;
using HotelReservationSystem.Services.FacilityServices;
using HotelReservationSystem.Mediators.FacilityMediators;
using HotelReservationSystem.Mediators.RoomAvailability;
using HotelReservationSystem.Services.UserServices;

namespace Hotel
{
    public class AutoFacModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Context>().InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

        

            builder.RegisterType<ReservationService>().As<IReservationService>().InstancePerLifetimeScope();
            builder.RegisterType<ReservationMediator>().As<IReservationMediator>().InstancePerLifetimeScope();

            builder.RegisterType<RoomService>().As<IRoomService>().InstancePerLifetimeScope();
            builder.RegisterType<RoomMediator>().As<IRoomMediator>().InstancePerLifetimeScope();

            builder.RegisterType<FacilityService>().As<IFacilityService>().InstancePerLifetimeScope();
            builder.RegisterType<FacilityMediator>().As<IFacilityMediator>().InstancePerLifetimeScope();

            builder.RegisterType<RoomAvailabilityMediator>().As<IRoomAvailabilityMediator>().InstancePerLifetimeScope();

            builder.RegisterType<ReviewService>().As<IReviewService>().InstancePerLifetimeScope();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterType<ReviewMeditator>().As<IReviewMeditator>().InstancePerLifetimeScope();
        }
    }
}
