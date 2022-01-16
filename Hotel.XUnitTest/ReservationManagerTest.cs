using Hotel.Business.Abstract;
using Hotel.Business.Concrete;
using Hotel.Business.Constants;
using Hotel.Core.Utilities.Results;
using Hotel.DataAccess.Abstract;
using Hotel.Entities.Concrete;
using Moq;
using System;
using Xunit;

namespace Hotel.XUnitTest
{
    public class ReservationManagerTest
    {
        private readonly ReservationManager _reservationRoomManager;
        private readonly Mock<IReservationDal> _reservationDal;
        private readonly Mock<IHotelRoomService> _hotelRoomService;


        public ReservationManagerTest()
        {
            _reservationDal = new Mock<IReservationDal>();
            _hotelRoomService = new Mock<IHotelRoomService>();
            _reservationRoomManager = new ReservationManager(_reservationDal.Object, _hotelRoomService.Object);
        }

        [Fact]
        public void CreateReservation_BestPractice()
        {
            var hotelId = 1;
            var roomTypeId = 1;
            int requestedRoomCount = 1;
            var bookingDateStart = DateTime.Now;
            var bookingDateEnd = DateTime.Now.AddDays(1);
            var hotelRoom = new HotelRoom()
            {
                Id = 1,
                HotelInformationId = 1,
                IsDeleted = false,
                Price = 10.0M,
                MaxAllotment = 40,
                SoldAllotment = 10,
                RoomTypeId = 1,
                HotelInformation = new HotelInformation
                {
                    Id = 1,
                    HotelName = "Hotel California",
                    IsDeleted = false
                },
                RoomType = new RoomType
                {
                    Id = 1,
                    RoomTypeName = "Single"
                }
            };

            var reservationModel = new Reservation
            {
                HotelRoomId = hotelId,
                StartDate = bookingDateStart,
                EndDate = bookingDateEnd,
                IsDeleted = false,
                RoomCount = requestedRoomCount,
                CreatedAt = DateTime.Now
            };

            _hotelRoomService.Setup(p => p.GetHotelRoomByHotelAndRoomTypeId(hotelId, roomTypeId)).Returns(new SuccessDataResult<HotelRoom>(hotelRoom));
            _hotelRoomService.Setup(p => p.Update(hotelRoom)).Returns(new SuccessResult(Messages.HotelRoomUpdated));

            _reservationDal.Setup(p => p.Add(reservationModel));

            var result = _reservationRoomManager.CreateReservation(hotelId, roomTypeId, requestedRoomCount, bookingDateStart, bookingDateEnd);
            Assert.True(result.Success);
        }

        [Fact]
        public void CreateReservation_RequestedRoomCount_Bigger_Than_NotSoldAllotment()
        {
            var hotelId = 1;
            var roomTypeId = 1;
            int requestedRoomCount = 40;
            var bookingDateStart = DateTime.Now;
            var bookingDateEnd = DateTime.Now.AddDays(1);
            var hotelRoom = new HotelRoom()
            {
                Id = 1,
                HotelInformationId = 1,
                IsDeleted = false,
                Price = 10.0M,
                MaxAllotment = 40,
                SoldAllotment = 10,
                RoomTypeId = 1,
                HotelInformation = new HotelInformation
                {
                    Id = 1,
                    HotelName = "Hotel California",
                    IsDeleted = false
                },
                RoomType = new RoomType
                {
                    Id = 1,
                    RoomTypeName = "Single"
                }
            };


            _hotelRoomService.Setup(p => p.GetHotelRoomByHotelAndRoomTypeId(hotelId, roomTypeId)).Returns(new SuccessDataResult<HotelRoom>(hotelRoom));

            var result = _reservationRoomManager.CreateReservation(hotelId, roomTypeId, requestedRoomCount, bookingDateStart, bookingDateEnd);
            Assert.False(result.Success);
        }

        [Fact]
        public void CreateReservation_BookingDateStart_Bigger_Than_BookingDateEnd()
        {
            var hotelId = 1;
            var roomTypeId = 1;
            int requestedRoomCount = 1;
            var bookingDateStart = DateTime.Now.AddDays(1);
            var bookingDateEnd = DateTime.Now;
            var hotelRoom = new HotelRoom()
            {
                Id = 1,
                HotelInformationId = 1,
                IsDeleted = false,
                Price = 10.0M,
                MaxAllotment = 40,
                SoldAllotment = 10,
                RoomTypeId = 1,
                HotelInformation = new HotelInformation
                {
                    Id = 1,
                    HotelName = "Hotel California",
                    IsDeleted = false
                },
                RoomType = new RoomType
                {
                    Id = 1,
                    RoomTypeName = "Single"
                }
            };


            _hotelRoomService.Setup(p => p.GetHotelRoomByHotelAndRoomTypeId(hotelId, roomTypeId)).Returns(new SuccessDataResult<HotelRoom>(hotelRoom));

            var result = _reservationRoomManager.CreateReservation(hotelId, roomTypeId, requestedRoomCount, bookingDateStart, bookingDateEnd);
            Assert.False(result.Success);
        }

        [Fact]
        public void CreateReservation_BookingDateStart_Bigger_Than_Now()
        {
            var hotelId = 1;
            var roomTypeId = 1;
            int requestedRoomCount = 1;
            var bookingDateStart = DateTime.Now.AddDays(-1);
            var bookingDateEnd = DateTime.Now;
            var hotelRoom = new HotelRoom()
            {
                Id = 1,
                HotelInformationId = 1,
                IsDeleted = false,
                Price = 10.0M,
                MaxAllotment = 40,
                SoldAllotment = 10,
                RoomTypeId = 1,
                HotelInformation = new HotelInformation
                {
                    Id = 1,
                    HotelName = "Hotel California",
                    IsDeleted = false
                },
                RoomType = new RoomType
                {
                    Id = 1,
                    RoomTypeName = "Single"
                }
            };


            _hotelRoomService.Setup(p => p.GetHotelRoomByHotelAndRoomTypeId(hotelId, roomTypeId)).Returns(new SuccessDataResult<HotelRoom>(hotelRoom));

            var result = _reservationRoomManager.CreateReservation(hotelId, roomTypeId, requestedRoomCount, bookingDateStart, bookingDateEnd);
            Assert.False(result.Success);
        }

        [Fact]
        public void CancelReservation_True()
        {
            var reservationId = 1;
            var hotelId = 1;
            var roomTypeId = 1;
            int requestedRoomCount = 1;
            var bookingDateStart = DateTime.Now;
            var bookingDateEnd = DateTime.Now.AddDays(1);
            var hotelRoom = new HotelRoom()
            {
                Id = 1,
                HotelInformationId = 1,
                IsDeleted = false,
                Price = 10.0M,
                MaxAllotment = 40,
                SoldAllotment = 10,
                RoomTypeId = 1,
                HotelInformation = new HotelInformation
                {
                    Id = 1,
                    HotelName = "Hotel California",
                    IsDeleted = false
                },
                RoomType = new RoomType
                {
                    Id = 1,
                    RoomTypeName = "Single"
                }
            };

            var reservationModel = new Reservation
            {
                HotelRoomId = hotelId,
                StartDate = bookingDateStart,
                EndDate = bookingDateEnd,
                IsDeleted = false,
                RoomCount = requestedRoomCount,
                CreatedAt = DateTime.Now,
                Id = 1
            };

            _reservationDal.Setup(p => p.Get(p => p.Id == reservationId && p.IsDeleted == false)).Returns(reservationModel);
            _hotelRoomService.Setup(p => p.GetHotelRoomById(reservationModel.HotelRoomId)).Returns(new SuccessDataResult<HotelRoom>(hotelRoom));
            _hotelRoomService.Setup(p => p.Update(hotelRoom)).Returns(new SuccessResult(Messages.HotelRoomUpdated));
            reservationModel.IsDeleted = true;
            _reservationDal.Setup(p => p.Update(reservationModel));

            var result = _reservationRoomManager.CancelReservation(reservationId);
            Assert.True(result.Success);
        }
        [Fact]
        public void CancelReservation_False()
        {
            var reservationId = 2;
            _reservationDal.Setup(p => p.Get(p => p.Id == reservationId && p.IsDeleted == false));

            var result = _reservationRoomManager.CancelReservation(reservationId);
            Assert.False(result.Success);
        }
    }
}
