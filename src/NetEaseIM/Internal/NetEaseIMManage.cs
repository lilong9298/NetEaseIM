using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NetEaseIM.Model;

namespace NetEaseIM.Internal {
    public class NetEaseIMManage : INetEaseIMManage {
        private readonly INetEaseIMDataProvider _dataProvider;
        private readonly Guid _callId;
        public NetEaseIMManage(INetEaseIMDataProvider dataProvider) {
            _dataProvider = dataProvider;
            _callId = Guid.NewGuid();
        }
        /// <summary>
        /// create IM Account
        /// </summary>
        /// <param name="userNumber"></param>
        /// <param name="functionNumber"></param>
        /// <returns></returns>
        public async Task<NetEaseIMAccountResult> IMCreateAccount(string userNumber, string functionNumber) {
            var _iMServerSetting = new NetEaseIMServerSetting(_dataProvider.Appkey(), _dataProvider.Appsecret());
            var functionmodel = _dataProvider.GetFunctionModel(functionNumber);
            var interopServices = new NetEaseIMInteropServices(functionmodel.Url);
            var list = new List<KeyValuePair<string, string>>();
            list.Add(new KeyValuePair<string, string>("accid", userNumber));
            list.Add(new KeyValuePair<string, string>("token", userNumber));
            await _dataProvider.SaveRequest(userNumber, _callId);
            var result = await interopServices.IMPostAsync<HttpContent, NetEaseIMAccountResult>(_iMServerSetting, functionmodel.Name, new FormUrlEncodedContent(list));
            await _dataProvider.SaveResponse(result, _callId);
            return result;
        }


        public async Task<NetEaseIMAccountResult> IMFindAccount(string userNumber, string functionNumber) {
            var _iMServerSetting = new NetEaseIMServerSetting(_dataProvider.Appkey(), _dataProvider.Appsecret());
            var functionmodel = _dataProvider.GetFunctionModel(functionNumber);
            var interopServices = new NetEaseIMInteropServices(functionmodel.Url);
            var list = new List<KeyValuePair<string, string>>();
            list.Add(new KeyValuePair<string, string>("accid", userNumber));
            await _dataProvider.SaveRequest(userNumber, _callId);
            var result = await interopServices.IMPostAsync<HttpContent, NetEaseIMAccountResult>(_iMServerSetting, functionmodel.Name, new FormUrlEncodedContent(list));
            await _dataProvider.SaveResponse(result, _callId);
            return result;
        }

        public async Task<NetEaseIMAccountVideoTokenResult> IMFindAccountVideoToken(long videoUid, string functionNumber) {
            var _iMServerSetting = new NetEaseIMServerSetting(_dataProvider.Appkey(), _dataProvider.Appsecret());
            var functionmodel = _dataProvider.GetFunctionModel(functionNumber);
            var interopServices = new NetEaseIMInteropServices(functionmodel.Url);
            var list = new List<KeyValuePair<string, string>>();
            list.Add(new KeyValuePair<string, string>("uid", videoUid.ToString()));
            await _dataProvider.SaveRequest(videoUid, _callId);
            var result = await interopServices.IMPostAsync<HttpContent, NetEaseIMAccountVideoTokenResult>(_iMServerSetting, functionmodel.Name, new FormUrlEncodedContent(list));
            await _dataProvider.SaveResponse(result, _callId);
            return result;
        }

        public async Task<NetEaseIMResult> SendMessager<T>(NetEaseIMMessage<T> model, string functionNumber) {
            var _iMServerSetting = new NetEaseIMServerSetting(_dataProvider.Appkey(), _dataProvider.Appsecret());
            var functionmodel = _dataProvider.GetFunctionModel(functionNumber);
            var interopServices = new NetEaseIMInteropServices(functionmodel.Url);
            var list = new List<KeyValuePair<string, string>>();
            list.Add(new KeyValuePair<string, string>("from", model.FromAccId));
            list.Add(new KeyValuePair<string, string>("ope", ((int)model.Ope).ToString()));
            list.Add(new KeyValuePair<string, string>("to", model.ToAccId));
            list.Add(new KeyValuePair<string, string>("type", ((int)model.Kind).ToString()));
            list.Add(new KeyValuePair<string, string>("body", JsonConvert.SerializeObject(model.Body)));
            list.Add(new KeyValuePair<string, string>("option", JsonConvert.SerializeObject(model.Option)));
            list.Add(new KeyValuePair<string, string>("pushcontent", model.Pushcontent));
            list.Add(new KeyValuePair<string, string>("payload", model.Payload));
            list.Add(new KeyValuePair<string, string>("ext", JsonConvert.SerializeObject(model.Ext)));
            await _dataProvider.SaveSendHistory(model, _callId);
            await _dataProvider.SaveRequest(model, _callId);
            var result = await interopServices.IMPostAsync<HttpContent, NetEaseIMResult>(_iMServerSetting, functionmodel.Name, new FormUrlEncodedContent(list));
            await _dataProvider.SaveResponse(result, _callId);
            return result;
        }

        public async Task<IMMHResult> HistoryMessager(NetEaseIMMessageHistory model, string functionNumber) {
            var _iMServerSetting = new NetEaseIMServerSetting(_dataProvider.Appkey(), _dataProvider.Appsecret());
            var functionmodel = _dataProvider.GetFunctionModel(functionNumber);
            var interopServices = new NetEaseIMInteropServices(functionmodel.Url);
            var list = new List<KeyValuePair<string, string>>();
            list.Add(new KeyValuePair<string, string>("from", model.FromAccId));
            list.Add(new KeyValuePair<string, string>("to", model.ToAccId));
            list.Add(new KeyValuePair<string, string>("begintime", model.BeginTime.ToString()));
            list.Add(new KeyValuePair<string, string>("endtime", model.EndTime.ToString()));
            list.Add(new KeyValuePair<string, string>("limit", model.Limit.ToString()));
            list.Add(new KeyValuePair<string, string>("reverse", model.Reverse.ToString()));
            await _dataProvider.SaveRequest(model, _callId);
            var result = await interopServices.IMPostAsync<HttpContent, IMMHResult>(_iMServerSetting, functionmodel.Name, new FormUrlEncodedContent(list));
            await _dataProvider.SaveResponse(result, _callId);
            return result;
        }
    }
}
