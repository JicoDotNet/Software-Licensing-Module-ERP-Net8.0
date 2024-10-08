﻿using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;

namespace LicensingERP.StateManagement
{
    public static class TempDataManagement
    {
        public static void Put<T>(this ITempDataDictionary tempData, string key, T value) where T : class
        {
            if (value != null)
            {
                if (Get<T>(tempData, key) == null)
                    tempData.Add(key, JsonConvert.SerializeObject(value));
            }               
        }

        public static T Get<T>(this ITempDataDictionary tempData, string key) where T : class
        {
            tempData.TryGetValue(key, out object obj);
            return obj == null ? null : JsonConvert.DeserializeObject<T>((string)obj);
        }
    }
}
