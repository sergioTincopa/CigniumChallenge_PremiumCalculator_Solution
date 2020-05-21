using PremiumCalculator.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PremiumCalculator.Business
{
    public interface IMasterBL : IDisposable
    {
        List<Frequence> LoadFrequencies();
        List<State> LoadStates();
    }
}
