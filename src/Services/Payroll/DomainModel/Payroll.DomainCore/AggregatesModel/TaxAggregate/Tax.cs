using Payroll.Domain.SeedWork; 
using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll.DomainCore.AggregatesModel.TaxAggregate
{
    public class Tax : Entity, IAggregateRoot
    {  
        public TaxRule TRule { get; private set; }
        public PaymentRule PRule { get; private set; }
        public int Year { get; private set; }
         
        public Tax(int year, TaxRule tRule, PaymentRule pRule)  
        {

            Year = year > 2000 ? year : throw new ArgumentOutOfRangeException(nameof(year));
            tRule = tRule != null ? tRule : throw new ArgumentOutOfRangeException(nameof(tRule));

            Year = year;
            TRule = tRule;
            PRule = pRule;
        }

    }
}
