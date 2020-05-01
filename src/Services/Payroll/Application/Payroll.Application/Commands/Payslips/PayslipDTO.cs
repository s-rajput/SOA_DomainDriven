

using Payroll.DomainCore.AggregatesModel.TaxAggregate;

namespace Payroll.Application.Commands.Payments
{
    public class PaymentDTO
    {
        public string EmployeeName { get; set; }
        public string PaymentPeriod { get; set; }
        public int GrossIncome { get; set; }
        public int IncomeTax { get; set; }
        public int NetIncome { get; set; }
        public int Super { get; set; }

        public static PaymentDTO FromPaymentData(PaymentData data)
        {
            return new PaymentDTO()
            {
                EmployeeName = data.EmployeeName,
                PaymentPeriod = data.PayPeriod,
                GrossIncome = data.GrossIncome,
                IncomeTax = data.TaxAmount,
                NetIncome = data.NetIncome,
                Super = data.SuperAmount  
            };
        }
    }
}
