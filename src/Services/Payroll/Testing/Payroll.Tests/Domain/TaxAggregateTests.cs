using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payroll.DomainCore.AggregatesModel.TaxAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll.Tests.Domain
{
    [TestClass]
    public class TaxAggregateTests
    {

        [TestMethod]
        public void TaxRule_entity_creation_success() 
        {
            //Act - Assert
            var TaxFreeThrashHold = 18200;
            var year = 2017;
            var Tier1Limit = 0;
            var Tier1MarginalRate = 0;
            var Tier1MinFixedTaxAmount = 0;
            var Tier2Limit = 0;
            var Tier2MarginalRate = 0;
            var Tier2MinFixedTaxAmount = 0;
            var Tier3Limit = 0;
            var Tier3MarginalRate = 0;
            var Tier3MinFixedTaxAmount = 0;

            var HighestMinFixedTaxAmount = 0;
            var HighestMarginalRate = 0;

            //Act 
            var taxRule = new TaxRule(year, TaxFreeThrashHold,
                Tier1Limit, Tier1MarginalRate, Tier1MinFixedTaxAmount,
                Tier2Limit, Tier2MarginalRate, Tier2MinFixedTaxAmount,
                Tier3Limit, Tier3MarginalRate, Tier3MinFixedTaxAmount,
                HighestMinFixedTaxAmount, HighestMarginalRate
                );

            //Assert
            Assert.IsNotNull(taxRule);
        }

        [TestMethod]
        public void Negative_values_rule_creation_fail()
        {
            //Act - Assert
            var TaxFreeThrashHold = -200;  //negative
            var year = -234;  //negative
            var Tier1Limit = 0;
            var Tier1MarginalRate = 0;
            var Tier1MinFixedTaxAmount = 0;
            var Tier2Limit = 0;
            var Tier2MarginalRate = 0;
            var Tier2MinFixedTaxAmount = 0;
            var Tier3Limit = 0;
            var Tier3MarginalRate = 0;
            var Tier3MinFixedTaxAmount = 0;

            var HighestMinFixedTaxAmount = 0;
            var HighestMarginalRate = 0;

            //Act - Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                   new TaxRule(year, TaxFreeThrashHold,
                Tier1Limit, Tier1MarginalRate, Tier1MinFixedTaxAmount,
                Tier2Limit, Tier2MarginalRate, Tier2MinFixedTaxAmount,
                Tier3Limit, Tier3MarginalRate, Tier3MinFixedTaxAmount,
                HighestMinFixedTaxAmount, HighestMarginalRate
                ));

        }


        [TestMethod]
        public void Tax_item_creation_success()
        {
            //Arrange     
            var TaxFreeThrashHold = 18200;
            var year = 2017;
            var Tier1Limit = 0;
            var Tier1MarginalRate = 0;
            var Tier1MinFixedTaxAmount = 0;
            var Tier2Limit = 0;
            var Tier2MarginalRate = 0;
            var Tier2MinFixedTaxAmount = 0;
            var Tier3Limit = 0;
            var Tier3MarginalRate = 0;
            var Tier3MinFixedTaxAmount = 0;

            var HighestMinFixedTaxAmount = 0;
            var HighestMarginalRate = 0;

            //Act  
            var taxRule = new TaxRule(year, TaxFreeThrashHold,
                Tier1Limit, Tier1MarginalRate, Tier1MinFixedTaxAmount,
                Tier2Limit, Tier2MarginalRate, Tier2MinFixedTaxAmount,
                Tier3Limit, Tier3MarginalRate, Tier3MinFixedTaxAmount,
                HighestMinFixedTaxAmount, HighestMarginalRate
                );
            var tax = new Tax(year, taxRule, null); 

            //Assert
            Assert.IsNotNull(tax);
        }

        [TestMethod]
        public void Tax_item_creation_fail()
        {
            //Arrange      
            var year = 2017;
            TaxRule rule = null; 

            //Act - Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                   new Tax(year, rule, null));
        }

    }
}
