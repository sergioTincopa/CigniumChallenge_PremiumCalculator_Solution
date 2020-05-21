using PremiumCalculator.Entities.Data;
using System.Threading.Tasks;
using PremiumCalculator.Entities;
using System.Collections.Generic;

namespace PremiumCalculator.Client
{
    public interface ICalculatorClient
    {
        Task<ConfigurationData> GetPremiumValue(object objRequest);
        Task<List<State>> GetStates();
        Task<List<Frequence>> GetFrequencies();
    }
}