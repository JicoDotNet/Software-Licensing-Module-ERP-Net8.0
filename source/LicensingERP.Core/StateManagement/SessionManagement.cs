using System;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace LicensingERP.StateManagement
{
    //[Session(SessionTimeOut = 60, SessionCookieless = false)]
    //public class SessionManagement : HttpSessionStateBase, ISessionManagement
    //{
    //    public static HttpContextBase SetSession<T>(HttpContextBase Context, T SessionObject, string SessionKey = null) where T : new()
    //    {
    //        try
    //        {
    //            Context.Session.Add(GetSessionKey<T>(SessionKey), SessionObject);
    //            return Context;
    //        }
    //        catch (Exception ExceptionObj)
    //        {
    //            throw ExceptionObj;
    //        }
    //    }

    //    public static T GetSession<T>(HttpContextBase Context, string SessionKey = null) where T : new()
    //    {
    //        try
    //        {
    //            if (SessionAvailable<T>(Context, SessionKey))
    //            {
    //                return (T)Context.Session[GetSessionKey<T>(SessionKey)];
    //            }
    //            return default(T);
    //        }
    //        catch (Exception ExceptionObj)
    //        {
    //            throw ExceptionObj;
    //        }
    //    }

    //    public static HttpContextBase RemoveSession<T>(HttpContextBase Context, string SessionKey = null) where T : new()
    //    {
    //        try
    //        {
    //            if (SessionAvailable<T>(Context, SessionKey))
    //            {
    //                Context.Session.Remove(GetSessionKey<T>(SessionKey));
    //            }
    //            return Context;
    //        }
    //        catch (Exception ExceptionObj)
    //        {
    //            throw ExceptionObj;
    //        }
    //    }

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <typeparam name="T"></typeparam>
    //    /// <param name="Context">HttpContext Object</param>
    //    /// <param name="SessionKey">the optional session key</param>
    //    /// <returns>true if perticular session is available</returns>
    //    public static bool SessionAvailable<T>(HttpContextBase Context, string SessionKey = null) where T : new()
    //    {
    //        try
    //        {
    //            if (Context.Session[GetSessionKey<T>(SessionKey)] == null)
    //                return false;
    //            else
    //                return true;
    //        }
    //        catch (Exception ExceptionObj)
    //        {
    //            throw ExceptionObj;
    //        }
    //    }

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="Context">HttpContext Object</param>
    //    /// <returns>true if any kind of session available</returns>
    //    public static bool SessionAvailable(HttpContextBase Context)
    //    {
    //        try
    //        {
    //            if (Context.Session == null)
    //                return false;
    //            else
    //                return true;
    //        }
    //        catch (Exception ExceptionObj)
    //        {
    //            throw ExceptionObj;
    //        }
    //    }

    //    private static string GetSessionKey<T>(string SessionKey) where T : new()
    //    {
    //        if (string.IsNullOrEmpty(SessionKey))
    //            return new T().GetType().Name + "Session";
    //        else
    //            return SessionKey;
    //    }

    //    public void Dispose()
    //    {
    //        GC.SuppressFinalize(this);
    //        GC.Collect();
    //    }
    //}

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
            catch (Exception ExceptionObj)
            {
                throw ExceptionObj;
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
                        return default(T);
                    }
                    return JsonConvert.DeserializeObject<T>(data);
                }
                return default(T);
            }
            catch (Exception ExceptionObj)
            {
                throw ExceptionObj;
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
            catch (Exception ExceptionObj)
            {
                throw ExceptionObj;
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
            catch (Exception ExceptionObj)
            {
                throw ExceptionObj;
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
            catch (Exception ExceptionObj)
            {
                throw ExceptionObj;
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