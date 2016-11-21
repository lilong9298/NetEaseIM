using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetEaseIM.Model {
    public class NetEaseIMAccountResult : NetEaseIMResult {
        public NetEaseIMAccount Info { get; set; }
    }

    public class NetEaseIMAccountVideoTokenResult : NetEaseIMResult {
        public string Token { get; set; }
    }

    public class NetEaseIMAccount {
        public string Accid { get; set; }
        public string Token { get; set; }
    }
}
