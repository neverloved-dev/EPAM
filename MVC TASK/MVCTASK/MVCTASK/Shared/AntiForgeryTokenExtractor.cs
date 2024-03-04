using Azure;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCTASK.Shared
{
    public static class AntiForgeryTokenExtractor
    {
        public static string AntiForgeryFieldName { get; } = "AntiForgeryTokenField";
        public static string AntiForgeryCookieName { get; } = "AntiForgeryTokenCookie";

        public static string ExtractAntiForgeryCookieValue(HttpResponseMessage httpResponse)
        {
            var antiForgeryCookie = httpResponse.Headers.GetValues("Set-Cookie")
                .FirstOrDefault(x=>x.Contains(AntiForgeryCookieName));
            if (antiForgeryCookie is null)
            {
                throw new ArgumentException($"Cookie '{AntiForgeryCookieName}' not found in HTTP response", nameof(httpResponse));
            }
            var antiForgeryCookieValue = SetCookieHeaderValue.Parse(antiForgeryCookie).Value.ToString();
            return antiForgeryCookieValue;
        }
    }
}
