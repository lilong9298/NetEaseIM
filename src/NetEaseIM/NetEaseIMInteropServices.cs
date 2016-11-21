using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using NetEaseIM.Extensions;
using NetEaseIM.Model;

namespace NetEaseIM {
    public class NetEaseIMInteropServices {
        private readonly string _url;

        public NetEaseIMInteropServices(string url) {
            _url = url;
        }

        public async Task<TResult> IMPostAsync<T, TResult>(NetEaseIMServerSetting _iMServerSetting, string functionName, FormUrlEncodedContent value) {
            using (var httpClient = new HttpClient()) {
                httpClient.BaseAddress = new Uri(_url);
                httpClient.DefaultRequestHeaders.Add("Nonce", _iMServerSetting.Nonce);
                httpClient.DefaultRequestHeaders.Add("CurTime", _iMServerSetting.Curtime);
                httpClient.DefaultRequestHeaders.Add("CheckSum", _iMServerSetting.CheckSum);
                httpClient.DefaultRequestHeaders.Add("AppKey", _iMServerSetting.AppKey);
                httpClient.DefaultRequestHeaders.Add("ContentType", "application/x-www-form-urlencoded;charset=utf-8");
                var response = await httpClient.PostAsync(functionName, value);
                if (response.IsSuccessStatusCode) {
                    return await response.Content.ReadAsAsync<TResult>();
                }
                else {
                    await HandleError(response);
                }

                return default(TResult);
            }
        }

        internal async Task HandleError(HttpResponseMessage response) {
            switch (response.StatusCode) {
                case System.Net.HttpStatusCode.NotFound:
                case System.Net.HttpStatusCode.Forbidden:
                    HandleError(); break;
                case System.Net.HttpStatusCode.BadRequest:
                    var error2 = await response.Content.ReadAsAsync<BadRequest>();
                    throw new Exception(error2.ErrorMessage);
                default:
                    var error = await response.Content.ReadAsStringAsync();
                    HandleError(error); break;
            }

        }

        internal static void HandleError() {
            throw new DependencyException();
        }

        internal static void HandleError(string errorMessage) {
            throw new DependencyException(errorMessage);
        }
    }

    public class BadRequest {
        public string ErrorMessage { get; set; }
    }
}
