using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    /// <summary>
    /// Class for Custom Exception Handling
    /// </summary>
    public class CabInvoiceException : Exception
    {
        /// <summary>
        /// Enum for Exception type
        /// </summary>
        public enum ExceptionType
        {
            INVALID_RIDE_TYPE,
            INVALID_DISTANCE,
            INVALID_TIME,
            INVALID_USER_ID,
            NULL_RIDES
        }

        ExceptionType type;

        /// <summary>
        /// Parameter Constructor for Setting Exception type and Throwing Exception
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="message">The message.</param>
        public CabInvoiceException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
