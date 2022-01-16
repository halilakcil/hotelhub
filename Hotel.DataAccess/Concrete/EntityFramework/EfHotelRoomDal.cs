using Hotel.Core.EntityFramework;
using Hotel.DataAccess.Abstract;
using Hotel.DataAccess.Concrete.EntityFramework.Contexts;
using Hotel.Entities.Concrete;

namespace Hotel.DataAccess.Concrete.EntityFramework
{
    public class EfHotelRoomDal : EfEntityRepositoryBase<HotelRoom, HotelHubDbContext>, IHotelRoomDal
    {
        public IList<HotelRoom> AdvancedRoomSearch(List<int> roomTypeIds, List<int>? selectedHotelIds)
        {
            return selectedHotelIds == null ?
                GetList(p => p.IsDeleted == false && roomTypeIds.Contains(p.RoomTypeId), p => p.HotelInformation, p => p.RoomType).ToList() :
                GetList(p => p.IsDeleted == false && selectedHotelIds.Contains(p.HotelInformationId) && roomTypeIds.Contains(p.RoomTypeId), p => p.HotelInformation, p => p.RoomType).ToList();

        }

        public IList<HotelRoom> GetCheapestRoomPrices()
        {
            return GetList(p => p.IsDeleted == false, p => p.HotelInformation, p => p.RoomType).ToList();
        }

        public int RoomAvailabilityCount(List<int> roomTypeIds, List<int>? hotelIds)
        {
            return hotelIds == null ?
                GetList(p => p.IsDeleted == false && roomTypeIds.Contains(p.RoomTypeId)).Count() :
                GetList(p => p.IsDeleted == false && roomTypeIds.Contains(p.RoomTypeId) && hotelIds.Contains(p.HotelInformationId)).Count();
        }
    }
}
