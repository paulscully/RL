using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ConsumerTrading.Test
{
    [TestClass()]
    public class CsvHandlerTests
    {
        [TestMethod()]
        public void ReadCsvTestNotFound()
        {
            var policyList = CsvHandler.ReadCsv("UnknownData.csv");

            Assert.IsNull(policyList);
        }

        [TestMethod()]
        public void ReadCsvTestSuccess()
        {
            // Arrange
            // Note: For this test ensure that the Maturity.csv file is in the folder C:\TradingDemo\

            var policyList = CsvHandler.ReadCsv("MaturityData.csv");

            Assert.IsNotNull(policyList);
        }
    }
}