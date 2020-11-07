using System;
using System.Collections.Generic;
using System.Text;

namespace HRS
{
    class HRSCustomException : Exception
    {
        public enum ExceptionType
        {
            WRONG_DATE_FORMAT,
            WRONG_DATES,
            WRONG_CUSTOMER_TYPE,
        }

        private readonly ExceptionType type;
        public HRSCustomException(ExceptionType type, String message):base(message)
        {
            this.type = type;
        }

    }
}
