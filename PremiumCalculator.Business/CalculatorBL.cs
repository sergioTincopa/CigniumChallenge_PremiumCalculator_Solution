using System;
using System.Collections.Generic;
using System.Text;
using PremiumCalculator.Entities.Data;
using PremiumCalculator.DataAccess;

namespace PremiumCalculator.Business
{
    public class CalculatorBL : ICalculatorBL
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public List<ConfigurationData> LoadConfigurationData()
        {
            using (ICalculatorDA CalculatorDA = new CalculatorDA())
            {
                return CalculatorDA.LoadConfigurationData();
            }
        }
    }
}
