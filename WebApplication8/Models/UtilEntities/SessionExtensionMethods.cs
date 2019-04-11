using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models.UtilEntities
{
    public static class SessionExtensionMethods
    {
        public static void SetObject(this ISession session,
                           string key, object value)
        {
            string stringValue = JsonConvert.
                                 SerializeObject(value);
            session.SetString(key, stringValue);
        }

        public static T GetObject<T>(this ISession session,
                                     string key)
        {
            string stringValue = session.GetString(key);
            T value;
            if (stringValue != null)
            {
                value = JsonConvert.DeserializeObject<T>
                                  (stringValue);
                return value;
            }

            return default(T);
        }
    }
}
