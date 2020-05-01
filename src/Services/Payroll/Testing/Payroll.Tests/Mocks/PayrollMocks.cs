using Payroll.DomainCore.AggregatesModel.TaxAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll.Tests.Mocks
{
    public class PayrollMocks
    {
        public Tax Tax2017;
        public Tax Tax2018;
        public Tax Tax2019;

        PaymentRule Notused;




        public PayrollMocks()
        {
            Tax2017 = new Tax(2017, MockTaxRule2017(),Notused);
            Tax2018 = new Tax(2018, MockTaxRule2017(), Notused);
            Tax2019 = new Tax(2019, MockTaxRule2017(), Notused);
        }

        

        private TaxRule MockTaxRule2017()
        {

            var Year = 2017;
            var TaxFreeTharshold = 18200;
            var Tier1Limit = 37000;
            var Tier1MarginalRate = 0;
            var Tier1MinFixedTaxAmount = 0;

            var Tier2Limit = 87000;
            var Tier2MarginalRate = 32.5;
            var Tier2MinFixedTaxAmount = 3572;

            var Tier3Limit = 180000;
            var Tier3MarginalRate = 37;
            var Tier3MinFixedTaxAmount = 19822;


            var HighestMinFixedTaxAmount = 54232;
            var HighestMarginalRate = 45;

            return new TaxRule(Year, TaxFreeTharshold,
                                Tier1Limit, Tier1MarginalRate, Tier1MinFixedTaxAmount,
                                Tier2Limit, Tier2MarginalRate, Tier2MinFixedTaxAmount,
                                Tier3Limit, Tier3MarginalRate, Tier3MinFixedTaxAmount,
                                HighestMinFixedTaxAmount, HighestMarginalRate
                                );

        }

        private TaxRule MockTaxRule2018()
        {

            var Year = 2018;
            var TaxFreeTharshold = 18200;
            var Tier1Limit = 37000;
            var Tier1MarginalRate = 0;
            var Tier1MinFixedTaxAmount = 0;

            var Tier2Limit = 87000;
            var Tier2MarginalRate = 32.5;
            var Tier2MinFixedTaxAmount = 3572;

            var Tier3Limit = 180000;
            var Tier3MarginalRate = 37;
            var Tier3MinFixedTaxAmount = 19822;


            var HighestMinFixedTaxAmount = 54232;
            var HighestMarginalRate = 45;

            return new TaxRule(Year, TaxFreeTharshold,
                                Tier1Limit, Tier1MarginalRate, Tier1MinFixedTaxAmount,
                                Tier2Limit, Tier2MarginalRate, Tier2MinFixedTaxAmount,
                                Tier3Limit, Tier3MarginalRate, Tier3MinFixedTaxAmount,
                                HighestMinFixedTaxAmount, HighestMarginalRate
                                );

        }

        private TaxRule MockTaxRule2019()
        {

            var Year = 2019;
            var TaxFreeTharshold = 18200;
            var Tier1Limit = 37000;
            var Tier1MarginalRate = 0;
            var Tier1MinFixedTaxAmount = 0;

            var Tier2Limit = 87000;
            var Tier2MarginalRate = 32.5;
            var Tier2MinFixedTaxAmount = 3572;

            var Tier3Limit = 180000;
            var Tier3MarginalRate = 37;
            var Tier3MinFixedTaxAmount = 19822;


            var HighestMinFixedTaxAmount = 54232;
            var HighestMarginalRate = 45;

            return new TaxRule(Year, TaxFreeTharshold,
                                Tier1Limit, Tier1MarginalRate, Tier1MinFixedTaxAmount,
                                Tier2Limit, Tier2MarginalRate, Tier2MinFixedTaxAmount,
                                Tier3Limit, Tier3MarginalRate, Tier3MinFixedTaxAmount,
                                HighestMinFixedTaxAmount, HighestMarginalRate
                                );

        }

       
    }
}
