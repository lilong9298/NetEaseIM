using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetEaseIM;
using NetEaseIM.Model;

namespace NetEaseIM.Test {
    public class NetEaseIMDataProvider : INetEaseIMDataProvider {
        public string Appkey() {
            return "079fd3e1169622d88f8c57222eb03769";
        }

        public string Appsecret() {
            return "837167694ba2";
        }

        public NetEaseFunction GetFunctionModel(string number) {
            switch (number) {
                case "SendMessage":
                    return new NetEaseFunction() { Url = "https://api.netease.im/", Name = "nimserver/msg/sendMsg.action" };
                case "HistoryMessage":
                    return new NetEaseFunction() { Url = "https://api.netease.im/", Name = "nimserver/history/querySessionMsg.action" };

                default:
                    return new NetEaseFunction() { Url = "https://api.netease.im/", Name = "nimserver/user/create.action" };
            }
        }
        public async Task SaveRequest(object model, Guid callid) {
            Console.Write(Newtonsoft.Json.JsonConvert.SerializeObject(model));
        }

        public async Task SaveResponse(object model, Guid callid) {
            Console.Write(Newtonsoft.Json.JsonConvert.SerializeObject(model));
        }

        public async Task SaveSendHistory<T>(NetEaseIMMessage<T> model, Guid callid) {
            Console.Write(Newtonsoft.Json.JsonConvert.SerializeObject(model));
        }
    }
}
