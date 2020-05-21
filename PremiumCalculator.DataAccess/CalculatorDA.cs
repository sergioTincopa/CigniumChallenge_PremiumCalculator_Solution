using PremiumCalculator.Entities.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace PremiumCalculator.DataAccess
{
    public class CalculatorDA : ICalculatorDA
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Method that list configuration data
        /// </summary>
        /// Creation Date: 21/05/2020
        /// Creator: Sergio Tincopa Nolaso
        /// <param></param>
        /// <returns>Configuration data list</returns>
        public List<ConfigurationData> LoadConfigurationData()
        {
            List<ConfigurationData> lstData = new List<ConfigurationData>();

            lstData.Add(new ConfigurationData { State = "NY", BirthMonth = 8, StartAge = 18, EndAge = 45, Premium = Convert.ToDecimal("150.0") });
            lstData.Add(new ConfigurationData { State = "NY", BirthMonth = 1, StartAge = 46, EndAge = 65, Premium = Convert.ToDecimal("200.5") });
            lstData.Add(new ConfigurationData { State = "NY", BirthMonth = 0, StartAge = 18, EndAge = 65, Premium = Convert.ToDecimal("120.99") });
            lstData.Add(new ConfigurationData { State = "AL", BirthMonth = 11, StartAge = 18, EndAge = 65, Premium = Convert.ToDecimal("85.5") });
            lstData.Add(new ConfigurationData { State = "AL", BirthMonth = 0, StartAge = 18, EndAge = 65, Premium = Convert.ToDecimal("100.0") });
            lstData.Add(new ConfigurationData { State = "AK", BirthMonth = 12, StartAge = 65, EndAge = -1, Premium = Convert.ToDecimal("175.2") });
            lstData.Add(new ConfigurationData { State = "AK", BirthMonth = 12, StartAge = 18, EndAge = 64, Premium = Convert.ToDecimal("125.16") });
            lstData.Add(new ConfigurationData { State = "AK", BirthMonth = 0, StartAge = 18, EndAge = 65, Premium = Convert.ToDecimal("100.8") });
            lstData.Add(new ConfigurationData { State = "*", BirthMonth = 0, StartAge = 18, EndAge = 65, Premium = Convert.ToDecimal("90.0") });            

            return lstData;
        }
    }
}
