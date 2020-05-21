using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumCalculator.Api
{
    public class Enums
    {
        public struct StateName
        {
            public const string cStateNY = "NY";
            public const string cStateAL = "AL";
            public const string cStateAK = "AK";
        }

        public struct ValidationType
        {
            public const string cAllStates = "*";
            public const int cAllMonths = 0;
        }
    }
}
