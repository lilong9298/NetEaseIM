using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetEaseIM.Extensions {
    public class DependencyException : Exception {
        private const string error = "调用外部系统出错";
        public DependencyException() : base(error) {

        }

        public DependencyException(string message) : base($"{error}: {message}") {

        }

        public DependencyException(string message, Exception innerException) : base($"{error}: {message}", innerException) {

        }
    }
}
