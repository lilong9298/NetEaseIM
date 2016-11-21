using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetEaseIM.Internal;
using NetEaseIM.Model;
using Xunit;

namespace NetEaseIM.Test {
    public class NetEaseIMManageTest {

        [Fact]
        public async Task Create() {
            var imm = new NetEaseIMManage( new NetEaseIMDataProvider());
            var strs = new List<string>() { "13488888888",
"13444444444",
"13422222222",
"13411111111",
"88288844",
"18658115875",
"13645810322",
"13333333333",
"15145110701",
"13429104075",
"18767225923",
"13235811795",
"13233895670",
"13223909521",
"15145110700" };
            foreach (var item in strs) {
                var result = await imm.IMCreateAccount(item, "");

                Assert.True(result != null);
            };


        }

        [Fact]
        public async Task SendMessage() {
            var imm = new NetEaseIMManage(new NetEaseIMDataProvider());
            var model = new NetEaseIMMessage<object>() {
                FromAccId = "13783783183-d",
                Ope = Ope.point,
                ToAccId = "18679236954-c",
                Kind = MessageKind.txt,
                Body = new { msg = "1234567" },
                Option = new Option() {
                    roam = false,
                    push = false,
                    needPushNick = false
                },
                Ext = new IMExt { OrderNumber="0121-Test"}

            };

            var result = await imm.SendMessager<object>(model, "SendMessage");

            Assert.True(result != null);
        }

        [Fact]
        public async Task HistoryMessage() {
            var imm = new NetEaseIMManage(new NetEaseIMDataProvider());
            var model = new NetEaseIMMessageHistory() {
                FromAccId = "18679236954",
                ToAccId = "15168365183",
                Begin = DateTime.Now.Date,
                End = DateTime.Now,
                Limit = 99,
                Reverse = 1
            };

            var result = await imm.HistoryMessager(model, "HistoryMessage");

            Assert.True(result != null);
        }

    }
}
