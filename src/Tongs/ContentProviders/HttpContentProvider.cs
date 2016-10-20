using System;
using System.Net.Http;

namespace Tongs.ContentProviders
{
    class HttpContentProvider : IContentProvider
    {
        private readonly HttpClient client;

        public HttpContentProvider()
        {
            client = new HttpClient();
        }

        public bool IsAcceptableLocation(string location)
        {
            var uri = new Uri(location);
            return uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps;
        }

        public string GetContent(string location)
        {
            var response = client.GetAsync(location).Result;
            response.EnsureSuccessStatusCode();
            return response.Content.ReadAsStringAsync().Result;
        }
    }
}
