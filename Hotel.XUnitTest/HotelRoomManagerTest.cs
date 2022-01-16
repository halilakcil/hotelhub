using AutoMapper;
using Hotel.Business.Concrete;
using Hotel.Core.Utilities.Results;
using Hotel.DataAccess.Abstract;
using Hotel.Entities.Concrete;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Xunit;

namespace Hotel.XUnitTest
{
    public class HotelRoomManagerTest
    {
        private readonly HotelRoomManager _hotelRoomManager;
        private readonly Mock<IHotelRoomDal> _hotelRoomDal;
        private readonly Mock<IMapper> _mapper;


        private List<HotelRoom> _hotelRoomList;
        private List<CustomHotelRoom> _customHotelRoom;


        private List<HotelRoom> _availabilityRoomCheckHotelRoomList;
        //RoomAvailabilityCheck=>true;
        private List<int> _roomTypeIdsTrue = new List<int> { 1, 2 };
        private List<int> _hotelIdsTrue = new List<int> { 1, 2 };
        private int _requestedRoomCountTrue = 2;

        //RoomAvailabilityCheck=>false;
        private List<int> _roomTypeIdsFalse = new List<int> { 1 };
        private List<int> _hotelIdsFalse = new List<int> { 1, 2 };
        private int _requestedRoomCountFalse = 40;

        public HotelRoomManagerTest()
        {
            _mapper = new Mock<IMapper>();
            _hotelRoomDal = new Mock<IHotelRoomDal>();
            _hotelRoomManager = new HotelRoomManager(_hotelRoomDal.Object, _mapper.Object);


            _customHotelRoom = new List<CustomHotelRoom>()
            {
                new CustomHotelRoom
                {
                    HotelInformationId=1,
                    HotelName="Hotel California",
                    Price=10.0M,
                    RoomTypeId=1,
                    RoomTypeName="Single"
                },
                new CustomHotelRoom
                {
                    HotelInformationId=1,
                    HotelName="Hotel California",
                    Price=10.0M,
                    RoomTypeId=2,
                    RoomTypeName="Dublex"
                }
            };
            _hotelRoomList = new List<HotelRoom>
            {
                new HotelRoom{
                    Id = 1,
                    HotelInformationId=1,
                    IsDeleted=false,
                    Price=10.0M,
                    MaxAllotment=40,
                    SoldAllotment=10,
                    RoomTypeId=1,
                    HotelInformation = new HotelInformation
                    {
                        Id=1,
                        HotelName="Hotel California",
                        IsDeleted=false
                    },
                    RoomType=new RoomType
                    {
                        Id = 1,
                        RoomTypeName="Single"
                    }
                },
                new HotelRoom{
                    Id = 2,
                    HotelInformationId=1,
                    IsDeleted=false,
                    Price=10.0M,
                    MaxAllotment=40,
                    SoldAllotment=10,
                    RoomTypeId=2,
                    HotelInformation = new HotelInformation
                    {
                        Id=1,
                        HotelName="Hotel California",
                        IsDeleted=false
                    },
                    RoomType=new RoomType
                    {
                        Id = 2,
                        RoomTypeName="Dublex"
                    }
                },
                new HotelRoom{
                    Id = 3,
                    HotelInformationId=1,
                    IsDeleted=true,
                    Price=10.0M,
                    MaxAllotment=40,
                    SoldAllotment=10,
                    RoomTypeId=2,
                    HotelInformation = new HotelInformation
                    {
                        Id=1,
                        HotelName="Hotel California",
                        IsDeleted=false
                    },
                    RoomType=new RoomType
                    {
                        Id = 2,
                        RoomTypeName="Dublex"
                    }
                },
                new HotelRoom{
                    Id = 4,
                    HotelInformationId=2,
                    IsDeleted=true,
                    Price=10.0M,
                    MaxAllotment=40,
                    SoldAllotment=10,
                    RoomTypeId=2,
                    HotelInformation = new HotelInformation
                    {
                        Id=2,
                        HotelName="Hotel Antalya",
                        IsDeleted=false
                    },
                    RoomType=new RoomType
                    {
                        Id = 2,
                        RoomTypeName="Dublex"
                    }
                }
            };



            _availabilityRoomCheckHotelRoomList = new List<HotelRoom>
            {
                new HotelRoom{
                    Id = 1,
                    HotelInformationId=1,
                    IsDeleted=false,
                    Price=10.0M,
                    MaxAllotment=40,
                    SoldAllotment=10,
                    RoomTypeId=1,
                    HotelInformation = new HotelInformation
                    {
                        Id=1,
                        HotelName="Hotel California",
                        IsDeleted=false
                    },
                    RoomType=new RoomType
                    {
                        Id = 1,
                        RoomTypeName="Single"
                    }
                },
                new HotelRoom{
                    Id = 2,
                    HotelInformationId=1,
                    IsDeleted=false,
                    Price=10.0M,
                    MaxAllotment=40,
                    SoldAllotment=10,
                    RoomTypeId=2,
                    HotelInformation = new HotelInformation
                    {
                        Id=1,
                        HotelName="Hotel California",
                        IsDeleted=false
                    },
                    RoomType=new RoomType
                    {
                        Id = 2,
                        RoomTypeName="Dublex"
                    }
                },
                new HotelRoom{
                    Id = 3,
                    HotelInformationId=1,
                    IsDeleted=false,
                    Price=10.0M,
                    MaxAllotment=40,
                    SoldAllotment=10,
                    RoomTypeId=2,
                    HotelInformation = new HotelInformation
                    {
                        Id=1,
                        HotelName="Hotel California",
                        IsDeleted=false
                    },
                    RoomType=new RoomType
                    {
                        Id = 2,
                        RoomTypeName="Dublex"
                    }
                },
                new HotelRoom{
                    Id = 4,
                    HotelInformationId=2,
                    IsDeleted=false,
                    Price=10.0M,
                    MaxAllotment=40,
                    SoldAllotment=10,
                    RoomTypeId=2,
                    HotelInformation = new HotelInformation
                    {
                        Id=2,
                        HotelName="Hotel Antalya",
                        IsDeleted=false
                    },
                    RoomType=new RoomType
                    {
                        Id = 2,
                        RoomTypeName="Dublex"
                    }
                }
            };

        }

        [Fact]
        public void GetCheapestRoomPrices_Get_ReturnCountTwo()
        {
            _hotelRoomDal.Setup(p => p.GetCheapestRoomPrices()).Returns(_hotelRoomList);
            var customHotelRoomList = _mapper.Setup(p => p.Map<List<CustomHotelRoom>>(It.IsAny<object>())).Returns(_customHotelRoom);

            var result = _hotelRoomManager.GetCheapestRoomPrices();
            Assert.Equal(2, result.Data.Count);
        }

        [Fact]
        public void RoomAvailabilityCheck_IsHotelIdsNotNull_ReturnTrue()
        {
            var returnCount = _availabilityRoomCheckHotelRoomList.Where(p => p.IsDeleted == false && _hotelIdsTrue.Contains(p.HotelInformationId) && _roomTypeIdsTrue.Contains(p.RoomTypeId)).ToList().Count;
            _hotelRoomDal.Setup(p => p.RoomAvailabilityCount(_roomTypeIdsTrue, _hotelIdsTrue)).Returns(returnCount);

            var result = _hotelRoomManager.RoomAvailabilityCheck(_roomTypeIdsTrue, _requestedRoomCountTrue, _hotelIdsTrue);
            Assert.True(result);
        }

        [Fact]
        public void RoomAvailabilityCheck_IsHotelIdsNull_ReturnTrue()
        {
            var returnCount = _availabilityRoomCheckHotelRoomList.Where(p => p.IsDeleted == false && _roomTypeIdsTrue.Contains(p.RoomTypeId)).ToList().Count;
            _hotelRoomDal.Setup(p => p.RoomAvailabilityCount(_roomTypeIdsTrue, null)).Returns(returnCount);

            var result = _hotelRoomManager.RoomAvailabilityCheck(_roomTypeIdsTrue, _requestedRoomCountTrue, null);
            Assert.True(result);
        }

        [Fact]
        public void RoomAvailabilityCheck_IsHotelIdsNotNull_ReturnFalse()
        {
            var returnCount = _availabilityRoomCheckHotelRoomList.Where(p => p.IsDeleted == false && _hotelIdsFalse.Contains(p.HotelInformationId) && _roomTypeIdsFalse.Contains(p.RoomTypeId)).ToList().Count;
            _hotelRoomDal.Setup(p => p.RoomAvailabilityCount(_roomTypeIdsFalse, _hotelIdsFalse)).Returns(returnCount);

            var result = _hotelRoomManager.RoomAvailabilityCheck(_roomTypeIdsFalse, _requestedRoomCountFalse, _hotelIdsFalse);
            Assert.False(result);
        }

        [Fact]
        public void RoomAvailabilityCheck_IsHotelIdsNull_ReturnFalse()
        {
            var returnCount = _availabilityRoomCheckHotelRoomList.Where(p => p.IsDeleted == false && _roomTypeIdsFalse.Contains(p.RoomTypeId)).ToList().Count;
            _hotelRoomDal.Setup(p => p.RoomAvailabilityCount(_roomTypeIdsFalse, null)).Returns(returnCount);

            var result = _hotelRoomManager.RoomAvailabilityCheck(_roomTypeIdsFalse, _requestedRoomCountFalse, null);
            Assert.False(result);
        }

        [Fact]
        public void AdvancedRoomSearch_IsSelectedHotelIdsNull()
        {

            _customHotelRoom = new List<CustomHotelRoom>()
            {
                new CustomHotelRoom
                {
                    HotelInformationId=1,
                    HotelName="Hotel California",
                    Price=10.0M,
                    RoomTypeId=1,
                    RoomTypeName="Single"
                },
                new CustomHotelRoom
                {
                    HotelInformationId=1,
                    HotelName="Hotel California",
                    Price=10.0M,
                    RoomTypeId=2,
                    RoomTypeName="Dublex"
                },
                new CustomHotelRoom
                {
                    HotelInformationId=1,
                    HotelName="Hotel California",
                    Price=10.0M,
                    RoomTypeId=2,
                    RoomTypeName="Dublex"
                },
                new CustomHotelRoom
                {
                    HotelInformationId=1,
                    HotelName="Hotel Antalya",
                    Price=10.0M,
                    RoomTypeId=2,
                    RoomTypeName="Dublex"
                }
            };

            var resultList = _availabilityRoomCheckHotelRoomList.Where(p => p.IsDeleted == false && _roomTypeIdsTrue.Contains(p.RoomTypeId)).ToList();
            var customHotelRoomList = _mapper.Setup(p => p.Map<List<CustomHotelRoom>>(It.IsAny<object>())).Returns(_customHotelRoom);
            _hotelRoomDal.Setup(p => p.AdvancedRoomSearch(_roomTypeIdsTrue, null)).Returns(resultList);

            var result = _hotelRoomManager.AdvancedRoomSearch(_roomTypeIdsTrue, null);
            Assert.Equal(_customHotelRoom, result.Data);
        }

        [Fact]
        public void AdvancedRoomSearch_IsSelectedHotelIdsNotNull()
        {
            _customHotelRoom = new List<CustomHotelRoom>()
            {
                new CustomHotelRoom
                {
                    HotelInformationId=1,
                    HotelName="Hotel California",
                    Price=10.0M,
                    RoomTypeId=1,
                    RoomTypeName="Single"
                },
                new CustomHotelRoom
                {
                    HotelInformationId=1,
                    HotelName="Hotel California",
                    Price=10.0M,
                    RoomTypeId=2,
                    RoomTypeName="Dublex"
                },
                new CustomHotelRoom
                {
                    HotelInformationId=1,
                    HotelName="Hotel California",
                    Price=10.0M,
                    RoomTypeId=2,
                    RoomTypeName="Dublex"
                },
                new CustomHotelRoom
                {
                    HotelInformationId=1,
                    HotelName="Hotel Antalya",
                    Price=10.0M,
                    RoomTypeId=2,
                    RoomTypeName="Dublex"
                }
            };

            var resultList = _availabilityRoomCheckHotelRoomList.Where(p => p.IsDeleted == false && _roomTypeIdsTrue.Contains(p.RoomTypeId) && _hotelIdsTrue.Contains(p.HotelInformationId)).ToList();
            var customHotelRoomList = _mapper.Setup(p => p.Map<List<CustomHotelRoom>>(It.IsAny<object>())).Returns(_customHotelRoom);
            _hotelRoomDal.Setup(p => p.AdvancedRoomSearch(_roomTypeIdsTrue, _hotelIdsTrue)).Returns(resultList);

            var result = _hotelRoomManager.AdvancedRoomSearch(_roomTypeIdsTrue, _hotelIdsTrue);
            Assert.Equal(_customHotelRoom, result.Data);
        }
    }
}