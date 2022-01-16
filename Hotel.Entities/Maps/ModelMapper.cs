using AutoMapper;
using Hotel.Entities.Concrete;

namespace Hotel.Entites.Maps
{
    public class ModelMapper : Profile
    {
        public ModelMapper()
        {
            CreateMap<HotelRoom, CustomHotelRoom>()
                .ForMember(o => o.HotelName, opts => opts.MapFrom(source => source.HotelInformation.HotelName))
                .ForMember(o => o.RoomTypeName, opts => opts.MapFrom(source => source.RoomType.RoomTypeName));
            CreateMap<CustomHotelRoom, HotelRoom>();
        }
    }
}
