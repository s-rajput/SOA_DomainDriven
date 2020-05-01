using Payroll.DomainCore.AggregatesModel.TaxAggregate;
using Payroll.DomainCore.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Payroll.Infrastructure.Data
{
    public class TaxRepository : ITaxRepository 
    { 
        readonly List<Tax> TaxStubRepo;

        public TaxRepository()
        { 
            //for testing avoided database call by holding inmemory data
            TaxStubRepo = new List<Tax>();
            TaxStubRepo.Add(new Tax(2017, MockTaxRule2017(), null));
            TaxStubRepo.Add(new Tax(2018, MockTaxRule2018(), null));
            TaxStubRepo.Add(new Tax(2019, MockTaxRule2019(), null));
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
        public List<Tax> GetAllItems()
        {
            return TaxStubRepo ;
        }

        public Tax GetTaxData(int year)
        {
            return TaxStubRepo.Where(x => x.Year.Equals(year))?.FirstOrDefault();
        }
    }
}
