using System;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace mohammadi.Infrastructure
{
    /// <summary>
    /// کلید های کوکی
    /// </summary>
    public enum CookieKey
    {
        cartCookie,
        lastSeen,

    }
    public static class CookieHelper
    {


        public static void Set<T>(this HttpResponse response, CookieKey key, T value, int? expireTime) where T : class
        {
            CookieOptions option = new CookieOptions();
            var keyStr = CookieKey.GetName(typeof(CookieKey), key);
            string valueStr = value == null ? string.Empty : JsonSerializer.Serialize<T>(value);
            if (expireTime.HasValue)
                option.Expires = DateTime.Now.AddMinutes(expireTime.Value);
            else
                option.Expires = DateTime.Now.AddYears(1);

            response.Cookies.Append(keyStr, valueStr, option);

        }
        public static T Get<T>(this HttpRequest request, CookieKey key) where T : class
        {
            var keyStr = CookieKey.GetName(typeof(CookieKey), key);
            string cookieValue = request.Cookies[keyStr];
            return cookieValue == null ? default(T) : JsonSerializer.Deserialize<T>(cookieValue);

        }

    }
}