using FluentValidation; 
using Payroll.Application.Commands.Payments;
using System;
using System.Collections.Generic;
using System.Linq; 

namespace Payroll.API.Application.Validations
{
    public class GeneratePaymentCommandValidator : AbstractValidator<GeneratePaymentCmd>
    {
        public GeneratePaymentCommandValidator()
        {

            RuleFor(command => command.FirstName).NotEmpty().MaximumLength(500);

            RuleFor(command => command.LastName).NotEmpty().MaximumLength(500);

            RuleFor(command => command.FirstName).NotEmpty().MinimumLength(2);

            RuleFor(command => command.LastName).NotEmpty().MinimumLength(2);

            RuleFor(command => command.AnnualSalary).NotEmpty().GreaterThan(0);  //Salary Must be positive
 
        }

        private bool BeValidExpirationDate(DateTime dateTime)
        {
            return dateTime >= DateTime.UtcNow;
        }


    }
}
