using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersApi.Models
{
    public class ErrorResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public List<Error> Errors { get; set; }
        
    }

    public class Error
    {
        public string Description { get; set; }
    }
}
