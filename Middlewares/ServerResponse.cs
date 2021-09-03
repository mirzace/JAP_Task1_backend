using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Middlewares
{
    public class ServerResponse<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; } = true;
        public int StatusCode { get; set; } = 500;
        public string Message { get; set; } = null;
    }
}
