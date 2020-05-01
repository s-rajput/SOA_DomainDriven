using System;
using System.Collections.Generic;
using System.Text;
using MediatR; 
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Payroll.DomainCore.Events;

namespace Payroll.Application.DomainEventHandlers.Audit
{ 
     public class PaymentGeneratedAuditEventHander : INotificationHandler<PaymentGeneratedAuditDomainEvent>
    { 
        private readonly ILoggerFactory _logger; 

        public PaymentGeneratedAuditEventHander( 
            ILoggerFactory logger  
             )
        { 
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
           
        }

        public async Task Handle(PaymentGeneratedAuditDomainEvent PaymentGeneratedDomainEvent, CancellationToken cancellationToken)
        {
            _logger.CreateLogger(nameof(PaymentGeneratedAuditDomainEvent))
             .LogTrace($"Payment of employee has been successfully generated with ");


            //DO THIS


            //DO THAT
            

        }
    }
}

