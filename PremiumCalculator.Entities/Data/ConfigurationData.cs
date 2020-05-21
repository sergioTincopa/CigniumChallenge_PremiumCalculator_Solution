using System;
using System.Collections.Generic;
using System.Text;

namespace PremiumCalculator.Entities.Data
{
    public class ConfigurationData
    {
        public string State { get; set; }
        public int BirthMonth { get; set; }
        public int StartAge { get; set; }
        public int EndAge { get; set; }
        public decimal Premium { get; set; }

    }
}
