using Payroll.Domain.SeedWork;
using Payroll.DomainCore.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll.DomainCore.AggregatesModel.TaxAggregate
{
    public class PaymentData : Entity
    { 
        //ddd readonly properties
        public string PayPeriod { get; private set; }
        public string EmployeeName { get; private set; }
        public int NetIncome { get; private set; }
        public int TaxAmount { get; private set; }
        public int SuperAmount { get; private set; }          
        public int GrossIncome { get; private set; }

        //initial to lowest tier
        private int _TaxFixedAmount = 0;
        private double _Rate = 0;
        private double _TierAmount = 0;


        private TaxRule _taxRule;
        private int _anualSalary;

        //DDD-styled entity class you can only create/change data via specific constructors/methods
        public PaymentData(string employeeName, int anualSalary,double superRate, string payPeriod,TaxRule taxRule)
        {
            _anualSalary = anualSalary;
            _taxRule = taxRule;
            PayPeriod = payPeriod;
            EmployeeName = employeeName;

            //set up Tier
            SetUpTier();

            //gross income
            var Val = (double)anualSalary / 12;
            GrossIncome = RoundUpAmount(Val);

            //income tax
            TaxAmount = RoundUpAmount((double)(_TaxFixedAmount + (double)((anualSalary - _TierAmount) * (_Rate / 100))) / 12);

            //NetIncome
            NetIncome = GrossIncome - TaxAmount;

            //Super
            SuperAmount = RoundUpAmount((double)(GrossIncome * superRate) / 100); 

        }

        private int RoundUpAmount(Double Val)
        {
            return Convert.ToInt32(Math.Round(Val, 0, MidpointRounding.AwayFromZero));
        }

        private void SetUpTier()
        {
            if (_anualSalary <= _taxRule.TaxFreeTharshold) { _TaxFixedAmount = 0; }
            else if (_anualSalary <= _taxRule.Tier1Limit)
            { _TaxFixedAmount = _taxRule.Tier1MinFixedTaxAmount; _Rate = _taxRule.Tier1MarginalRate; }
            else if (_anualSalary <= _taxRule.Tier2Limit)
            {    _TierAmount = _taxRule.Tier1Limit;
                _TaxFixedAmount = _taxRule.Tier2MinFixedTaxAmount;
                _Rate = _taxRule.Tier2MarginalRate; }
            else if (_anualSalary <= _taxRule.Tier3Limit)
            {
                _TierAmount = _taxRule.Tier2Limit;
                _TaxFixedAmount = _taxRule.Tier3MinFixedTaxAmount;
                _Rate = _taxRule.Tier3MarginalRate; }
            else
            {
                _TaxFixedAmount = _taxRule.HighestMinFixedTaxAmount;
                _Rate = _taxRule.HighestMarginalRate;
                _TierAmount = _taxRule.Tier3Limit;
            }
        }
        

    }
}
