using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace NetEaseIM.Extensions {
    public static class HttpClientExtensions {
        public static void SetUserAgent(this HttpClient client, string userAgent) {
            client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(new ProductHeaderValue(userAgent)));
        }
    }
}
