using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetEaseIM.Model {
    public class NetEaseIMMessageHistory {
        /// <summary>
        /// 发送者
        /// </summary>
        public string FromAccId { get; set; }

        /// <summary>
        /// 接收者
        /// </summary>
        public string ToAccId { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime Begin { get; set; }

        public DateTime End { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public long BeginTime => (long)(Begin.ToUniversalTime().Subtract(new DateTime(1970, 1, 1))).TotalMilliseconds;



        public long EndTime => (long)(End.ToUniversalTime().Subtract(new DateTime(1970, 1, 1))).TotalMilliseconds;

        /// <summary>
        /// 上限条数（） 本次查询的消息条数上限(最多100条),小于等于0，或者大于100，会提示参数错误
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// 1按时间正序排列，2按时间降序排列。其它返回参数414错误.默认是按降序排列
        /// </summary>
        public int Reverse { get; set; }
    }

    public class IMMHResult : NetEaseIMResult {
        public IList<object> Msgs { get; set; }

        public int size { get; set; }
    }



}
