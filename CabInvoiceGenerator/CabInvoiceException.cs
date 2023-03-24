using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class CabInvoiceException : Exception
    {
        public enum ExceptionType
        {
            INVALID_DISTANCE,
                INVALID_TIME,
                NULL_RIDE,
                INVALID_USER_ID

        }

        ExceptionType type;

        public CabInvoiceException(ExceptionType type,string message ) : base(message)
        {
            this.type = type;
        }
    }
}
