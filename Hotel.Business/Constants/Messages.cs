namespace Hotel.Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün başarıyla eklendi";
        public static string ProductModified = "Ürün başarıyla güncellendi";
        public static string ProductDeleted = "Ürün başarıyla silindi";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı girildi";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Kullanıcı zaten sistemde mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla oluşturuldu";
        public static string AccessTokenCreated = "AccessToken başarıyla oluşturuldu";
        public static string AuthorizationDenied = "Yetkiniz yok!";
        public static string ProductNameAlreadyExists = "Bu ürün zaten var!";
        public static string MaxAllotmentsRangeOfOut = "Toplam oda sayısından fazla değer girdiğiniz";
        public static string NotSoldAllotmentsRangeOfOut = "Toplam rezerve edilebilir oda sayısından fazla değer girdiğiniz";
        public static string WhenCreateReservationByPastDate = "Geçmiş tarihe rezervasyon yapamazsınız.";
        public static string IsStartDateBiggerThanEndDate = "Başlangıç tarihi bitiş tarihinden büyük olmamalı";
        public static string ReservationAdded = "Reservasyon alındı";
        public static string ReservationCannotAdded = "Reservasyon alınamadı";
        public static string ReservationCancelled = "Reservasyon iptal edildi";
        public static string ReservationNotFound = "Reservasyon bulunamadı";
        public static string HotelRoomUpdated = "Hotel Odası güncellendi";
        public static string CacheClear = "Önbellek temizlendi";
    }
}
