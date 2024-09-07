using LicensingERP.Logic.Encryption;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;

namespace LicensingERP.StateManagement
{
    public static class CookieManagement
    {
        public static bool SetCookie<T>(this HttpContext context, T cookieObject, string cookieKey) where T : new()
        {
            if (context != null && cookieObject != null)
            {
                context.Response.Cookies.Append(cookieKey,
                    new CryptoEngine().Encrypt(JsonConvert.SerializeObject(cookieObject)),
                    new CookieOptions
                    {
                        Expires = GenericLogic.IstNow.AddDays(6),
                        HttpOnly = true,
                        Secure = true,
                        SameSite = SameSiteMode.Strict
                    });
                return true;
            }
            return false;
        }

        public static T GetCookie<T>(this HttpContext context, string cookieKey) where T : new()
        {
            if (context != null)
            {
                if (context.Request.Cookies.TryGetValue(cookieKey, out string cookieValue))
                {
                    return JsonConvert.DeserializeObject<T>(new CryptoEngine().Decrypt(cookieValue));
                }
            }
            return default;
        }

        public static bool CookieAvailable<T>(this HttpContext context, string cookieKey) where T : new()
        {
            if (context != null)
            {
                if (context.Request.Cookies[cookieKey] != null)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool DeleteCookie(this HttpContext context, string cookieKey)
        {
            if (context != null)
            {
                context.Response.Cookies.Delete(cookieKey);
                return true;
            }
            return false;
        }

        public static bool DeleteCookie(this HttpContext context)
        {
            if (context != null)
            {
                IRequestCookieCollection cookies = context.Request.Cookies;
                foreach (KeyValuePair<string, string> cookie in cookies)
                {
                    context.Response.Cookies.Delete(cookie.Key);
                }
                return true;
            }
            return false;
        }
    }
}
