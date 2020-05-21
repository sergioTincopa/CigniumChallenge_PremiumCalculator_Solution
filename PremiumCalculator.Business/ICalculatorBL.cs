using System;
using System.Collections.Generic;
using System.Text;
using PremiumCalculator.Entities.Data;

namespace PremiumCalculator.Business
{
    public interface ICalculatorBL : IDisposable
    {
        List<ConfigurationData> LoadConfigurationData();
    }
}
