using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using NetEaseIM.Model;
using Newtonsoft.Json;

namespace NetEaseIM {
    public interface INetEaseIMManage {
        Task<NetEaseIMAccountResult> IMCreateAccount(string userNumber, string functionNumber);

        Task<NetEaseIMAccountResult> IMFindAccount(string userNumber, string functionNumber);

        Task<NetEaseIMResult> SendMessager<T>(NetEaseIMMessage<T> model, string functionNumber);

        Task<IMMHResult> HistoryMessager(NetEaseIMMessageHistory model, string functionNumber);

        Task<NetEaseIMAccountVideoTokenResult> IMFindAccountVideoToken(long videoUid, string functionNumber);
    }
}
