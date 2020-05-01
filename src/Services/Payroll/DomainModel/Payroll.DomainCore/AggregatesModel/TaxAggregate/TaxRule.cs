using Payroll.Domain.SeedWork;
using Payroll.DomainCore.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll.DomainCore.AggregatesModel.TaxAggregate
{
   public class TaxRule : Entity
    {
        public int Year { get; private set; } 

        public int TaxFreeTharshold { get; private set; }

        public int Tier1Limit { get; private set; }
        public double Tier1MarginalRate { get; private set; }
        public int Tier1MinFixedTaxAmount { get; private set; }

        public int Tier2Limit { get; private set; }
        public double Tier2MarginalRate { get; private set; }
        public int Tier2MinFixedTaxAmount { get; private set; }

        public int Tier3Limit { get; private set; }
        public double Tier3MarginalRate { get; private set; }
        public int Tier3MinFixedTaxAmount { get; private set; }


        public int HighestMinFixedTaxAmount { get; private set; }
        public double HighestMarginalRate { get; private set; }



        private TaxRule() { }

        public TaxRule(int year,int taxFreeTharshold, int tier1Limit, double tier1MarginalRate, int tier1MinFixedTaxAmount,
            int tier2Limit, double tier2MarginalRate, int tier2MinFixedTaxAmount, int tier3Limit, double tier3MarginalRate, int tier3MinFixedTaxAmount,
           int  highestMinFixedTaxAmount,double highestMarginalRate)
        {

            Year = year > 1999 ? year : throw new ArgumentOutOfRangeException(nameof(year));
            Year = taxFreeTharshold >= 0 ? taxFreeTharshold : throw new ArgumentOutOfRangeException(nameof(taxFreeTharshold));

            Tier1Limit = tier1Limit;
            Tier1MarginalRate = tier1MarginalRate;
            Tier1MinFixedTaxAmount = tier1MinFixedTaxAmount;
            Tier2Limit = tier2Limit;
            Tier2MarginalRate = tier2MarginalRate;
            Tier2MinFixedTaxAmount = tier2MinFixedTaxAmount;
            Tier3Limit = tier3Limit;
            Tier3MarginalRate = tier3MarginalRate;
            Tier3MinFixedTaxAmount = tier3MinFixedTaxAmount;
            HighestMinFixedTaxAmount = highestMinFixedTaxAmount;
            HighestMarginalRate = highestMarginalRate;

        }

        //protected override IEnumerable<object> GetAtomicValues()
        //{
        //    // Using a yield return statement to return each element one at a time
        //    yield return TaxFreeTharshold;
        //    yield return Tier1Limit;
        //    yield return Tier1MarginalRate;
        //    yield return Tier1MinFixedTaxAmount;
        //    yield return Tier2Limit;
        //    yield return Tier2MarginalRate;
        //    yield return Tier2MinFixedTaxAmount;
        //    yield return Tier3Limit;
        //    yield return Tier3MarginalRate;
        //    yield return Tier3MinFixedTaxAmount;
        //    yield return HighestMinFixedTaxAmount;
        //    yield return HighestMarginalRate;
        //}

    }
}
