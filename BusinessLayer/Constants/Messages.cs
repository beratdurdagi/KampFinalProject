using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Constants
{
    public static class Messages
    {
        public static string InternalError = "Internal Server Error";
        public static string ProductAdded = "Product Added";
        public static string ProductUpdated = "Product Updated Successfully";
        public static string ProductNameInvalid = "Invaled Product Name";
        public static string ProductListed = "Product Listed";
        public static string ProductsListed = "Products Listed";
        public static string ProductCountofCategoryError = "There can only be 10 products in categories";
        public static string ProductNameAlreadyTaken = "Product Name Allready Taken";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";
        public static string AuthorizationDenied = "Yetkiniz yok";

    }
}
