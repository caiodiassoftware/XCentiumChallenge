using System;

namespace XCentiumChallenge.Extensions
{
    public static class StringExtensions
    {
        public static bool IsBase64String(this string s)
        {
            return s.Contains("data:image/") && s.Contains("base64");
        }

        public static bool ValidUrl(this string source)
        {
            try
            {
                Uri uriResult;
                return Uri.TryCreate(source, UriKind.Absolute, out uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            }
            catch
            {
                return false;
            }
        }
    }
}