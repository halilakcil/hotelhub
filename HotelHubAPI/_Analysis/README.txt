■ Veritabanı kurulumu için;
	1 - (localdb)\MSSQLLocalDB database'nizde HotelHubDb isimli boş bir database oluşturun.
	2 - _Analysis klasörü altındaki HotelHubDbScript.sql scriptini bu database'e execute edin. (NOT: Script, Schema & Data içermektedir.)

■ Uygulama swagger ile çalışmaktadır.

■ Postman ile de çalışmak isterseniz; _Analysis klasörü altındaki HotelHubEndPoints.postman_collection.json dosyasını postmana import edebilirsiniz.

■ Uygulamada log4Net kütüphanesi kullanılmıştır. Exception log, information log bilgileri database'de Logs tablosunda tutulmaktadır.
   Loglama yapısı Database veya FileLog olarak kullanılabilir. FileLog ile çalışmak isterseniz; C:\Log\log.json dosyasını oluşturduktan sonra
   Hotel.Business.Concrete içindeki herhangi bir managerin metoduna [LogAspect(typeof(FileLogger))],[ExceptionLogAspect(typeof(FileLogger))] attribute'lerini
   eklemeniz gerekmektedir.

■ Uygulama JWT kullanılmıştır. Her metod için header'da Authorization bearer şeklinde gönderilmelidir.

■ Hotel.Business.Concrete.HotelRoomManager.GetCheapestRoomPrices() metodunda cache kullanılmıştır. Bu cache'e bağlı olarak ilgili tabloda güncelleme case'ine bağlı olarak 
  ilgili cache temizlenmektedir. Ayrıca manuel olarak cache temizlemek isterseniz; ClearCache endpoint'ini kullanabilirsiniz.

■ Uygulamanın testleri Hotel.XUnitTest katmanında bulunmaktadır.
	1 - HotelRoomManagerTest.cs içerisindeki metodlar;
		 - GetCheapestRoomPrices_Get_ReturnCountTwo(), geriye count'u 2 olan liste dönmesi,
		 - RoomAvailabilityCheck_IsHotelIdsNotNull_ReturnTrue(), hotelIds parametresinin null olmadığı ve geriye true değer dönmesi,
		 - RoomAvailabilityCheck_IsHotelIdsNull_ReturnTrue(), hotelIds parametresinin null olduğu ve geriye true değer dönmesi,
		 - RoomAvailabilityCheck_IsHotelIdsNotNull_ReturnFalse(), hotelIds parametresinin null olmadığı ve geriye false değer dönmesi,
		 - RoomAvailabilityCheck_IsHotelIdsNull_ReturnFalse(), hotelIds parametresinin null olduğu ve geriye false değer dönmesi,
		 - AdvancedRoomSearch_IsSelectedHotelIdsNull(), selectedHotelIds parametresinin null olduğu geriye değer dönmesi,
		 - AdvancedRoomSearch_IsSelectedHotelIdsNotNull(), selectedHotelIds parametresinin null olmadığı geriye değer dönmesi,
		 - CreateReservation_BestPractice(), standart parametreler ile true değer dönmesi,
		 - CreateReservation_RequestedRoomCount_Bigger_Than_NotSoldAllotment(), istenilen oda sayısının, mevcut oda sayısından fazla olan case'in false dönmesi,
		 - CreateReservation_BookingDateStart_Bigger_Than_BookingDateEnd(), rezervasyon başlangıç tarihinin bitiş tarihinden daha sonraki bir zaman diliminin olduğu case'in false dönmesi,
		 - CancelReservation_True(), rezervasyon iptalinden true değer dönmesi,
		 - CancelReservation_False(), rezervasyon iptalinden false değer dönmesi,
		 - CreateReservation_BookingDateStart_Bigger_Than_Now() geçmiş tarihe rezervasyon alındığında false dönmesi şeklinde kurgulanarak tasarlanmıştır.


