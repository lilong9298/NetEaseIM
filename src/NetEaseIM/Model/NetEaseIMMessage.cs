using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetEaseIM.Model {
    public class NetEaseIMMessage<T> {
        /// <summary>
        /// 发送者
        /// </summary>
        public string FromAccId { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        public Ope Ope { get; set; }

        public string ToAccId { get; set; }
        /// <summary>
        /// 消息内容类型
        /// </summary>
        public MessageKind Kind { get; set; }

        /// <summary>
        /// 消息对象
        /// </summary>
        public T Body { get; set; }

        /// <summary>
        /// 发消息时特殊指定的行为选项,Json格式，可用于指定消息的漫游，存云端历史，发送方多端同步，推送，消息抄送
        /// </summary>
        public Option Option { get; set; }

        /// <summary>
        /// 推送内容
        /// </summary>
        public string Pushcontent { get; set; } = "";

        /// <summary>
        /// 推送对应的payload
        /// </summary>
        public string Payload { get; set; } = "";

        /// <summary>
        /// 开发者扩展字段
        /// </summary>
        public IMExt Ext { get; set; }

    }

    public class IMExt {
        public string OrderNumber { get; set; }

        //public string Kind { get; set; }

        //public string Remark { get; set; }
    }




    public class Option {
        /// <summary>
        /// 是否需要漫游
        /// </summary>
        public bool roam { get; set; } = true;

        /// <summary>
        /// 是否存云端历史
        /// </summary>
        public bool history { get; set; } = true;

        /// <summary>
        /// 是否需要发送方多端同步
        /// </summary>
        public bool sendersync { get; set; } = true;

        /// <summary>
        /// 是否需要APNS推送或安卓系统通知栏推送
        /// </summary>
        public bool push { get; set; } = true;

        /// <summary>
        /// 是否需要抄送第三方
        /// </summary>
        public bool route { get; set; } = true;

        /// <summary>
        /// 是否需要计入到未读计数中
        /// </summary>
        public bool badge { get; set; } = true;

        /// <summary>
        /// 推送文案是否需要带上昵称
        /// </summary>
        public bool needPushNick { get; set; } = true;
    }

    /// <summary>
    ///  消息内容类型
    /// </summary>
    public enum MessageKind {
        /// <summary>
        /// 文本
        /// </summary>
        txt = 0,
        /// <summary>
        /// 图片
        /// </summary>
        imgage = 1,
        /// <summary>
        /// 语音
        /// </summary>
        audio = 2,
        /// <summary>
        /// 视频
        /// </summary>
        video = 3,
        /// <summary>
        /// 地理位置信息
        /// </summary>
        address = 4,
        /// <summary>
        /// 通知消息
        /// </summary>
        notification = 5,
        /// <summary>
        /// 文件
        /// </summary>
        file = 6,
        /// <summary>
        /// 音视频通话
        /// </summary>
        avchat = 7,
        /// <summary>
        /// 提醒消息
        /// </summary>
        tip = 10,
        /// <summary>
        /// 自定义
        /// </summary>
        custom = 100

    }

    /// <summary>
    /// 消息类型
    /// </summary>
    public enum Ope {
        /// <summary>
        /// 点对点个人消息
        /// </summary>
        point = 0,
        /// <summary>
        /// 群消息
        /// </summary>
        group = 1
    }
}

