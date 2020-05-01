using Payroll.Domain.SeedWork;
using System.Collections.Generic;

namespace Payroll.DomainCore.SeedWork
{
    public interface IRepository<T> where T : IAggregateRoot
    {        

        List<T> GetAllItems();
    }
}
