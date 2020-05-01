using Payroll.DomainCore.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll.DomainCore.AggregatesModel.TaxAggregate
{
    public interface ITaxRepository: IRepository<Tax>
    {
        Tax GetTaxData(int year);
    }
}
