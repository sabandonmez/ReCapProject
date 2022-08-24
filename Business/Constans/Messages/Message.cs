using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constans.Messages
{
    public static class Message
    {
        
        
        public static string MaintenanceTime = "Sistem Bakımda";
        
        public static string ItemAdded = "Item Added";
        public static string ItemDeleted = "Item Deleted";
        public static string ItemUpdated = "Item Updated";
        public static string ItemListed = "Item Listed.";

        public static string ItemNotAdded = "Item Not Added";
        public static string ItemNotDeleted = "Item Not Deleted";
        public static string ItemNotUpdated = "Item Not Updated";
        public static string ItemNotListed = "Item Not Listed.";

        public static string LimitExceeded = "Limit Exceeeded: Max 5 pictures";
        public static string AuthorizationDenied = "Yetkiniz Yok";

        public static string UserRegistered = "Kayıt oldu.";
        public static string UserNotFound = "Kullanıcı Bulunamadı";
        public static string PasswordError = "Parola Hatası";
        public static string SuccessfulLogin = "Başarılı giriş.";
        public static string UserAlreadyExists = "Kullanıcı Mevcut";
        public static string AccessTokenCreated = "Token Oluşturuldu";
    }
}
