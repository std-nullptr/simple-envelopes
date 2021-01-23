using System.ComponentModel.DataAnnotations;

namespace SimpleEnvelopes
{
    public class FundingSchedule
    {
        [Key]
        public int? ID { get; set; }

        public Period PayPeriod { get; set; }

        public string Name { get; set; }

        public enum Period
        {
            Weekly,
            Biweekly,
            Semimonthly,
            Monthly,
            Quarterly,
            Semiannual,
            Annual,
            Custom
        }
    }
}