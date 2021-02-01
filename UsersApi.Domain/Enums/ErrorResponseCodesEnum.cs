using System;
using System.Collections.Generic;
using System.Text;

namespace UsersApi.Domain.Enums
{
    public class ErrorResponseCodesEnum
    {
        private ErrorResponseCodesEnum(string value) { Value = value; }

        public string Value { get; set; }

        public static ErrorResponseCodesEnum VALIDATION_ERROR { get { return new ErrorResponseCodesEnum("VALIDATION_ERROR"); } }
        public static ErrorResponseCodesEnum UNKNOWN_ERROR { get { return new ErrorResponseCodesEnum("UNKNOWN_ERROR"); } }
        public static ErrorResponseCodesEnum ERROR { get { return new ErrorResponseCodesEnum("ERROR"); } }
    }
}
