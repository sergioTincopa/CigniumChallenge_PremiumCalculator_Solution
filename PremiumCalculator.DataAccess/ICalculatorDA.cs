using System;
using System.Collections.Generic;
using System.Text;
using PremiumCalculator.Entities.Data;

namespace PremiumCalculator.DataAccess
{
    public interface ICalculatorDA : IDisposable
    {
        List<ConfigurationData> LoadConfigurationData();
    }
}
