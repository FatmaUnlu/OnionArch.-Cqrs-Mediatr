using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.Wrappers
{
    public class BaseResponse
    {
        public Guid Id { get; set; }
        public string Success { get; set; }
        public string Message { get; set; }
    }
}
