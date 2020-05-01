 
using MediatR;
using System;
using System.Runtime.Serialization;

namespace Payroll.Application.Commands.Payments
{
    public class  GeneratePaymentCmd : IRequest<PaymentDTO>
    {
        
        /// <summary>
        ///FirstName of the employee  
        /// </summary>  
       [DataMember]
        public string FirstName { get; set; }

        /// <summary>
        ///LastName of the employee  
        /// </summary>  
        [DataMember]
        public string LastName { get; set; }

        /// <summary>
        ///Annual salary of the employee  
        /// </summary>  
        [DataMember]
        public int AnnualSalary { get; set; }

        /// <summary>
        ///Annual salary of the employee  
        /// </summary>  
        [DataMember]
        public string PaymentPeriod { get; set; }

        /// <summary>
        ///Payment from date  
        /// </summary>  
        [DataMember]
        private string PaymentFrom { get; set; }

        /// <summary>
        ///Payment to date
        /// </summary>  
        [DataMember]
        private string PaymentTo { get; set; }

        /// <summary>
        ///Super rate of the employee  
        /// </summary>  
        [DataMember]
        public string SuperRate { get; set; }


        public  GeneratePaymentCmd(string firstName, string lastName, int annualSalary, string paymentPeriod,string superRate)  
        {
            FirstName = firstName;
            LastName = lastName;
            PaymentPeriod = paymentPeriod;
            AnnualSalary = annualSalary;
            SuperRate = superRate;

        }


    }
}

