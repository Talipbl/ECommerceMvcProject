using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {

        public static string MaintenanceTime = "Bakım zamanı";
        internal static string AuthorizationDenied = "Yetkiniz yok.";
        internal static string UserRegistered;
        internal static User UserNotFound;
        internal static User PasswordError;
        internal static string SuccessfulLogin;
        internal static string UserAlreadyExists;
        internal static string AccessTokenCreated;

        public static class Product
        {
            public static string Added = "Ürün eklendi";
            public static string NameInvalid = "Ürün ismi geçersiz";
            public static string Listed = "Ürün listelendi";
            public static string ProductsListed = "Ürünler listelendi";
            public static string Deleted = "Ürün silindi";
            public static string Updated = "Ürün güncellendi";
            public static string CountOfCategoryError = "Bir kategoride en fazla 10 ürün olabilir.";
        }

        public static class Category
        {
            public static string Added = "Kategori eklendi";
            public static string Listed = "Kategoriler listelendi";
            public static string Deleted = "Kategori silindi";
            public static string Updated = "Kategori güncellendi";
            internal static string LimitExceded = "Katori limit aşıldı";
        }
    }
}
