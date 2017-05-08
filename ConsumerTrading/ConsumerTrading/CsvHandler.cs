using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ConsumerTrading.Data;

namespace ConsumerTrading
{
    public static class CsvHandler
    {

        public static List<Policy> ReadCsv(string filename)
        {
            List<Policy> policyList = null;

            var file = MainSettings.Default.FilePath + "" + filename;

            try
            {
                if (File.Exists(file))
                { 
                    policyList = File.ReadAllLines(file).Skip(1).Select(s => s.Split(new [] {','}))
                    .Select(c => new Policy 
                    {
                        PolicyNumber = c[0],
                        StartDate = c[1],
                        Premiums = Convert.ToInt32(c[2]),
                        Membership = Convert.ToChar(c[3]),
                        DiscretionaryBonus = Convert.ToInt32(c[4]),
                        UpliftPercentage = Convert.ToDecimal(c[5])
                    }).ToList();
                }
                else
                {
                    // Write trace/error to log file
                   
                }
            }
            catch (Exception)
            {
                // Write trace/error to log file
            }

            return policyList;
        }

    }
}
