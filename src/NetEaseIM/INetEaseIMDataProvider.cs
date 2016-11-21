using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetEaseIM.Model;

namespace NetEaseIM {
    public interface INetEaseIMDataProvider {
        NetEaseFunction GetFunctionModel(string number);

        Task SaveSendHistory<T>(NetEaseIMMessage<T> model, Guid callid);

        Task SaveRequest(object model, Guid callid);

        Task SaveResponse(object model, Guid callid);

        string Appkey();

        string Appsecret();
    }
}
