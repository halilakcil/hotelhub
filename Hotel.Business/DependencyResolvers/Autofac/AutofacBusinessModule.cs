using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using DataAccess.Concrete.EntityFramework;
using Hotel.Business.Abstract;
using Hotel.Business.Concrete;
using Hotel.Core.Utilities.Interceptors.Autofac;
using Hotel.Core.Utilities.Security.JWT;
using Hotel.DataAccess.Abstract;
using Hotel.DataAccess.Concrete.EntityFramework;

namespace Hotel.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<HotelRoomManager>().As<IHotelRoomService>();
            builder.RegisterType<EfHotelRoomDal>().As<IHotelRoomDal>();
            
            builder.RegisterType<ReservationManager>().As<IReservationService>();
            builder.RegisterType<EfReservationDal>().As<IReservationDal>();

            builder.RegisterType<HotelInformationManager>().As<IHotelInformationService>();
            builder.RegisterType<EfHotelInformationDal>().As<IHotelInformationDal>();

            builder.RegisterType<RoomTypeManager>().As<IRoomTypeService>();
            builder.RegisterType<EfRoomTypeDal>().As<IRoomTypeDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();

        }
    }
}
