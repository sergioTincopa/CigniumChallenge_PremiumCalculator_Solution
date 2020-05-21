using System;
using System.Collections.Generic;
using System.Text;
using PremiumCalculator.Entities.Data;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http;
using PremiumCalculator.Entities;

namespace PremiumCalculator.Client
{
    public class CalculatorClient : PremCalClient, ICalculatorClient
    {
        public CalculatorClient(HttpClient httpClient) : base(httpClient)
        {
        }

        /// <summary>
        /// Method that obtains premium value depending on Request values
        /// </summary>
        /// Creation Date: 21/05/2020
        /// Creator: Sergio Tincopa Nolaso
        /// <param name="Request">Parameters used for the calculation</param>
        /// <returns>Object type ConfigurationData</returns>
        public async Task<ConfigurationData> GetPremiumValue(object objRequest)
        {
            var vUrl = "Calculator/GetPremiumValue";
            var vProcess = await Post<ConfigurationData>(vUrl, objRequest);
            return vProcess;

        }

        /// <summary>
        /// Method that list states
        /// </summary>
        /// Creation Date: 21/05/2020
        /// Creator: Sergio Tincopa Nolaso
        /// <param></param>
        /// <returns>List of objects type State</returns>
        public async Task<List<State>> GetStates()
        {
            var vUrl = "master/GetStates";
            var vProcess = await Get<List<State>>(vUrl);
            return vProcess;

        }

        /// <summary>
        /// Method that list frequencies
        /// </summary>
        /// Creation Date: 21/05/2020
        /// Creator: Sergio Tincopa Nolaso
        /// <param></param>
        /// <returns>List of objects type Frequence</returns>
        public async Task<List<Frequence>> GetFrequencies()
        {
            var vUrl = "master/GetFrequencies";
            var vProcess = await Get<List<Frequence>>(vUrl);
            return vProcess;

        }
    }
}
