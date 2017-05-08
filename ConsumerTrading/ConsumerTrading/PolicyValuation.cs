using System;

namespace ConsumerTrading
{
    /// <summary>
    /// Notes:
    /// Ensure that the CSV file is placed in the folder C:\TradingDemo\ and then run the
    /// console application 'PolicyValuation.exe' from the bin\Release folder. 
    /// The resulting XML file will be placed in the same folder as the CSV file. 
    /// Six simple MSUnit tests were also created to test the basics of the functionailty.
    /// These are in isolation as the XML test doesn't rely on a correct value from the
    /// Maturity to be calculated, it just tests that the XML file has been created.
    /// One of the tests relies on the CSV file being placed in the correct folder.
    /// </summary>
    public class PolicyValuation
    {
        public static int Main(string[] args)
        {
            // Read CSV File
            var policyList = CsvHandler.ReadCsv("MaturityData.csv");

            // Check for an error 
            if (policyList == null)
            {
                Console.WriteLine("An error occurred reading from the CSV file. Read log for more details\n");

                return 1;
            }

            XmlHandler.WriteXml(policyList);

            return 0;
        }
    }
}
