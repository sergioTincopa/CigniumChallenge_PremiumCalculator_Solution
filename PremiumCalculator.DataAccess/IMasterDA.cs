using System;
using System.Collections.Generic;
using System.Text;
using PremiumCalculator.Entities;

namespace PremiumCalculator.DataAccess
{
    public interface IMasterDA : IDisposable
    {
        List<Frequence> LoadFrequencies();
        List<State> LoadStates();
    }
}
