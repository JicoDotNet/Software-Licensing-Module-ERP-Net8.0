using System;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace LicensingERP.StateManagement
{
    public static class SessionManagement
    {
        public static void SetSession<T>(this HttpContext context, T SessionObject, string SessionKey = null) where T : new()
        {
            try
            {
                context.Session.SetString(GetSessionKey<T>(SessionKey), JsonConvert.SerializeObject(SessionObject));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static T GetSession<T>(this HttpContext context, string SessionKey = null) where T : new()
        {
            try
            {
                if (SessionAvailable<T>(context, SessionKey))
                {
                    var data = context.Session.GetString(GetSessionKey<T>(SessionKey));
                    if (data == null)
                    {
                        return default;
                    }
                    return JsonConvert.DeserializeObject<T>(data);
                }
                return default;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void RemoveSession<T>(this HttpContext context, string SessionKey = null) where T : new()
        {
            try
            {
                if (SessionAvailable<T>(context, SessionKey))
                {
                    context.Session.Remove(GetSessionKey<T>(SessionKey));
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool SessionAvailable<T>(this HttpContext context, string SessionKey) where T : new()
        {
            try
            {
                if (context.Session.GetString(SessionKey) == null)
                    return false;
                else
                    return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool SessionAvailable(this HttpContext context)
        {
            try
            {
                if (!context.Session.IsAvailable)
                    return false;
                else
                    return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static string GetSessionKey<T>(string SessionKey) where T : new()
        {
            if (string.IsNullOrEmpty(SessionKey))
                return new T().GetType().Name + "Session";
            else
                return SessionKey;
        }
    }
}