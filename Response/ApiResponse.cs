using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCombustibles.Response
{
    public class ApiResponse<T>
    {
        public T Combustibles { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; }
    }
}
