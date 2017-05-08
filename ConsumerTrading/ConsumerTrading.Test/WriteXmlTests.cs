using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using ConsumerTrading.Data;

namespace ConsumerTrading.Test
{
    [TestClass()]
    public class WriteXmlTests
    {
        [TestMethod()]
        public void WriteXmlToFileTest()
        {          
            // Create List of data with 3 policies
            Policy policy1 = new Policy
                { PolicyNumber = "A100001", StartDate = "01/06/1986", Premiums = 10000, Membership = 'Y', DiscretionaryBonus = 1000, UpliftPercentage = 40 };

            List<Policy> policyList = new List<Policy> {policy1};

            Policy policy2 = new Policy
                { PolicyNumber = "B100002", StartDate = "01/01/1970", Premiums = 18000, Membership = 'N', DiscretionaryBonus = 3000, UpliftPercentage = 43 };
            policyList.Add(policy2);

            Policy policy3 = new Policy
                { PolicyNumber = "C100001", StartDate = "01/01/1992", Premiums = 13000, Membership = 'N', DiscretionaryBonus = 1000, UpliftPercentage = 42 };
            policyList.Add(policy3);

            // Delete any existing file
            File.Delete(XmlHandler.GetFileName());

            XmlHandler.WriteXml(policyList);

            var file = XmlHandler.GetFileName();
            XmlHandler.WriteXml(policyList);

            Assert.AreNotEqual(file.Length, 0);
        }
    }
}