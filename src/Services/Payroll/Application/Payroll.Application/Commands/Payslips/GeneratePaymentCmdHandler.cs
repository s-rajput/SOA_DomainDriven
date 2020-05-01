
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks; 
using Payroll.DomainCore.AggregatesModel.TaxAggregate;

namespace Payroll.Application.Commands.Payments
{

    
    public class GeneratePaymentCmdHandler : IRequestHandler<GeneratePaymentCmd, PaymentDTO>
    {
        private readonly ITaxRepository _TaxRepository;

        public GeneratePaymentCmdHandler(ITaxRepository TaxRepository)
        {
            _TaxRepository = TaxRepository;
        }

        /// <summary>
        /// Handler which processes the command when
        /// customer executes cancel order from app
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public Task<PaymentDTO> Handle( GeneratePaymentCmd command, CancellationToken cancellationToken)
        {
            var EmpID = command.FirstName + " " + command.LastName;

            var FinancialYear = 2019; //Hardcoded but can be estimated based on period dates
            var TaxRules = _TaxRepository.GetTaxData(FinancialYear);
             
            var Payment  = new PaymentData(EmpID, command.AnnualSalary,Convert.ToDouble(command.SuperRate), command.PaymentPeriod, TaxRules.TRule);
 
            return Task.FromResult(PaymentDTO.FromPaymentData(Payment)); 
        }

        
    }

   

}

