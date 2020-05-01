using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll.DomainCore.Exceptions
{ 
    /// <summary>
    /// Exception type for domain exceptions
    /// </summary>
    public class PayrollDomainExceptions : Exception
    {
        public PayrollDomainExceptions()
        { }

        public PayrollDomainExceptions(string message)
            : base(message)
        { }

        public PayrollDomainExceptions(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
