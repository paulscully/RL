namespace ConsumerTrading.Data
{
    public class Policy
    {
        public string PolicyNumber { get; set; } 
        public string StartDate { get; set; }
        public int Premiums { get; set; }
        public char Membership { get; set; }
        public int DiscretionaryBonus { get; set; }  
        public decimal UpliftPercentage { get; set; }
    }
}
