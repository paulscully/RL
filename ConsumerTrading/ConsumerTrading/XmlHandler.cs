using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using ConsumerTrading.Data;

namespace ConsumerTrading
{
    public static class XmlHandler
    {
        /// <summary>
        /// Reads policy from list, calculate maturity value for each one and write to XML
        /// </summary>
        /// <param name="policyList">A list of policies</param>
        public static void WriteXml(List<Policy> policyList)
        {
            try
            {
                // Create new xml file            
                XmlTextWriter textWriter = new XmlTextWriter(GetFileName(), null);

                // Opens the document             
                textWriter.WriteStartDocument();

                // Start writing the XML
                textWriter.WriteStartElement("Policies");

                foreach (Policy policy in policyList)
                {
                    // Get the maturity value
                    var maturityValue = MaturityCalculator.CalculateMaturityValue(policy);
               
                    textWriter.WriteStartElement("Policy");
                    textWriter.WriteAttributeString("number", policy.PolicyNumber);
              
                    textWriter.WriteElementString("MaturityValue", maturityValue);
                    textWriter.WriteEndElement();
                }

                textWriter.WriteEndElement();
                textWriter.WriteEndDocument();

                // Close writer
                textWriter.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error writing to XML file: " + ex.Message);
                Console.ReadKey();
                
                // log error to file
            }

        }


        /// <summary>
        /// Create filename for xml file based on date
        /// </summary>
        /// <returns></returns>
        public static string GetFileName()
        {
            string path = MainSettings.Default.FilePath;

            StringBuilder sb = new StringBuilder();
            sb.Append("MaturityCalculations");
            sb.Append("_");
            sb.Append(DateTime.Now.Day);
            sb.Append("-");
            sb.Append(DateTime.Now.Month);
            sb.Append("-");
            sb.Append(DateTime.Now.Year);
            sb.Append("-");
            sb.Append(DateTime.Now.Hour);
            sb.Append(".xml");
            return path + sb;
        }


    }
}
