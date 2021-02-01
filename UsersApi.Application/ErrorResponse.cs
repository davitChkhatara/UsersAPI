using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersApi.Application
{
    public class ErrorResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public List<Error> Errors { get; set; }
        
    }

    public class Error
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
