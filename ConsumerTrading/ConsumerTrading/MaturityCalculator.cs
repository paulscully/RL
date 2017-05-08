using System;
using ConsumerTrading.Data;

namespace ConsumerTrading
{
    public static class MaturityCalculator
    {
        private static bool Bonus { get; set; }
        private static int PercentFee { get; set; }

        /// <summary>
        /// Calculates the maturity Value for a given policy 
        /// </summary>
        /// <param name="policy">A single object containing policy data</param>
        /// <returns>The maturity value</returns>
        public static string CalculateMaturityValue(Policy policy)
        {
            char policyType = policy.PolicyNumber[0];
            CheckPolicy(policyType, Convert.ToDateTime(policy.StartDate), policy.Membership); 
                
            // Applies bonus if conditions apply
            var bonus = Bonus ? policy.DiscretionaryBonus : 0;

            var uplift = CalculateUplift(policy.UpliftPercentage);

            var maturityValue = (policy.Premiums - CalculateManagementFee(policy.Premiums) + bonus) * uplift;

            return $"{maturityValue:0.00}";
        }

        /// <summary>
        /// Calculates the uplift multiplier
        /// </summary>
        /// <param name="upliftPercentage">The uplift percentage</param>
        /// <returns>Returns a float as the uplift multiplier</returns>
        private static decimal CalculateUplift(decimal upliftPercentage)
        {
            var result = (1 + upliftPercentage/100);
            return result;
        }

        /// <summary>
        /// Calculates the management fee
        /// </summary>
        /// <param name="premium">The premium</param>
        /// <returns>The fee for managing the policy</returns>
        private static decimal CalculateManagementFee(int premium)
        {
            var result = (premium*PercentFee)/100;
            return result;
        }

        /// <summary>
        /// Checks the policy to assign the fee and determine if the bonus criteria are met
        /// </summary>
        /// <param name="policyType">Type of Policy A-C</param>
        /// <param name="policyDate">Date policy was started</param>
        /// <param name="membershipRights">Whether the policy has membership rights</param>
        private static void CheckPolicy(char policyType, DateTime policyDate, char membershipRights)
        {
            membershipRights = char.ToUpper(membershipRights);
            DateTime cutOffDate = Convert.ToDateTime("01/01/1990");
            Bonus = false;

            switch (policyType)
            {
                case 'A':
                    PercentFee = 3;
                    if (policyDate < cutOffDate)
                        Bonus = true;
                    break;
                case 'B':
                    PercentFee = 5;
                    if (membershipRights == 'Y')
                        Bonus = true;
                    break;
                case 'C':
                    PercentFee = 7;
                    if (policyDate >= cutOffDate && membershipRights == 'Y')
                        Bonus = true;
                    break;
            }
        }
    }
}
