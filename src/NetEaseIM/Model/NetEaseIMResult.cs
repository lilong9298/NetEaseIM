using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetEaseIM.Model {
    public class NetEaseIMResult {
        private static readonly List<string> StatesCode = new List<string> { "200" };
        private static readonly List<string> SuccessCode = new List<string> { "200" };
        private static readonly List<string> FailCode = new List<string> { "201","301","302","315","403"
                                    ,"404","405","406","408","413","414","415","416"
                                    ,"417","418","419","422","431","500","503","514"
                                    ,"509","998","999","801","802","803","804","805"
                                    ,"806","807","808","809","810","9102","9103","11001"
                                    ,"13001","13002","13003","13004","10431","10432","10433","10434"
                                    ,"10435","10436","10437","10438","10441"
                                 };
        public bool IsSucceedCode {
            get { return SuccessCode.Contains(Code); }
        }

        public bool IsFailed {
            get {
                return !string.IsNullOrEmpty(Desc) || (FailCode.Contains(Code));
            }
        }

        public bool IsDataReceived {
            get { return StatesCode.Contains(Code); }
        }

        /// <summary>
        /// Gets a value indicating whether the request is error.
        /// </summary>
        /// <value><c>true</c> if the request is error; otherwise, <c>false</c>.</value>
        public bool IsRequestError {
            get {
                return (!string.IsNullOrEmpty(Desc));
            }
        }

        public string Code { get; set; }
        public string Desc { get; set; }
        public string Message {
            get {
                if (!string.IsNullOrEmpty(Desc)) {
                    return Desc;
                }

                switch (Code) {
                    case "201": return "客户端版本不对，需升级sdk";
                    case "301": return "被封禁";
                    case "302": return "用户名或密码错误";
                    case "315": return "IP限制";
                    case "403": return "非法操作或没有权限";
                    case "404": return "对象不存在";
                    case "405": return "参数长度过长";
                    case "406": return "对象只读";
                    case "408": return "客户端请求超时";
                    case "413": return "验证失败(短信服务)";
                    case "414": return "参数错误";
                    case "415": return "客户端网络问题";
                    case "416": return "频率控制";
                    case "417": return "重复操作";
                    case "418": return "通道不可用(短信服务)";
                    case "419": return "数量超过上限";
                    case "422": return "账号被禁用";
                    case "431": return "HTTP重复请求";
                    case "500": return "服务器内部错误";
                    case "503": return "服务器繁忙";
                    case "514": return "服务不可用";
                    case "509": return "无效协议";
                    case "998": return "解包错误";
                    case "999": return "打包错误";
                    case "801": return "群人数达到上限";
                    case "802": return "没有权限";
                    case "803": return "群不存在";
                    case "804": return "用户不在群";
                    case "805": return "群类型不匹配";
                    case "806": return "创建群数量达到限制";
                    case "807": return "群成员状态错误";
                    case "808": return "申请成功";
                    case "809": return "已经在群内";
                    case "810": return "邀请成功";
                    case "9102": return "通道失效";
                    case "9103": return "已经在他端对这个呼叫响应过了";
                    case "11001": return "通话不可达，对方离线状态";
                    case "13001": return "IM主连接状态异常";
                    case "13002": return "聊天室状态异常";
                    case "13003": return "账号在黑名单中,不允许进入聊天室";
                    case "13004": return "在禁言列表中,不允许发言";
                    case "10431": return "输入email不是邮箱";
                    case "10432": return "输入mobile不是手机号码";
                    case "10433": return "注册输入的两次密码不相同";
                    case "10434": return "企业不存在";
                    case "10435": return "登陆密码或帐号不对";
                    case "10436": return "app不存在";
                    case "10437": return "email已注册";
                    case "10438": return "手机号已注册";
                    case "10441": return "app名字已经存在";
                    default:
                        return "";
                }


            }
        }

        public static implicit operator NetEaseIMResult(string code) {
            return new NetEaseIMResult { Code = code };
        }

        public static implicit operator string(NetEaseIMResult iMResult) {
            return iMResult.Code;
        }
    }
}


