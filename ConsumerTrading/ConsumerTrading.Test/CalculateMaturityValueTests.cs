using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsumerTrading.Data;

namespace ConsumerTrading.Test
{
    [TestClass()]
    public class CalculateMaturityValueTests
    {
        [TestMethod()]
        public void MaturityValueTestOne()
        {
            Policy policy = new Policy 
                {PolicyNumber = "A100001", StartDate = "01/06/1986", Premiums = 10000, Membership = 'Y', DiscretionaryBonus = 1000, UpliftPercentage = 40 };

            var maturityValue = MaturityCalculator.CalculateMaturityValue(policy);

            Assert.AreEqual(maturityValue, "14980.00");
        }

        [TestMethod()]
        public void MaturityValueTestTwo()
        {
            Policy policy = new Policy
                { PolicyNumber = "B100002", StartDate = "01/01/1970", Premiums = 18000, Membership = 'N', DiscretionaryBonus = 3000, UpliftPercentage = 43 };

            var maturityValue = MaturityCalculator.CalculateMaturityValue(policy);

            Assert.AreEqual(maturityValue, "24453.00");
        }

        [TestMethod()]
        public void MaturityValueTestThree()
        {
            Policy policy = new Policy
                { PolicyNumber = "C100001", StartDate = "01/01/1992", Premiums = 13000, Membership = 'N', DiscretionaryBonus = 1000, UpliftPercentage = 42 };

            var maturityValue = MaturityCalculator.CalculateMaturityValue(policy);

            Assert.AreEqual(maturityValue, "17167.80");
        }
    }
}