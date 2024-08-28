using System;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace LicensingERP.StateManagement
{
    public class SessionAttribute : Attribute
    {
        public int SessionTimeOut { get; set; }
        public bool SessionCookieless { get; set; }
    }

    [Session(SessionTimeOut = 60, SessionCookieless = false)]
    public class SessionManagement : ISessionManagement
    {
        public static ISession SetSession<T>(ISession session, T SessionObject, string SessionKey = null) where T : new()
        {            
            try
            {
                session.SetString(GetSessionKey<T>(SessionKey), JsonConvert.SerializeObject(SessionObject));
                return session;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static T GetSession<T>(ISession session, string SessionKey = null) where T : new()
        {
            try
            {
                if (SessionAvailable<T>(session, SessionKey))
                {
                    var data = session.GetString(GetSessionKey<T>(SessionKey));
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

        public static ISession RemoveSession<T>(ISession session, string SessionKey = null) where T : new()
        {
            try
            {                
                if (SessionAvailable<T>(session, SessionKey))
                {
                    session.Remove(GetSessionKey<T>(SessionKey));
                }
                return session;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool SessionAvailable<T>(ISession session, string SessionKey = null) where T : new()
        {
            try
            {
                if (session.GetString(SessionKey) == null)
                    return false;
                else
                    return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool SessionAvailable(ISession session)
        {
            try
            {
                if (!session.IsAvailable)
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

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            GC.Collect();
        }
    }
}