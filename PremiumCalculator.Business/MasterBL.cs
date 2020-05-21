using PremiumCalculator.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using PremiumCalculator.DataAccess;

namespace PremiumCalculator.Business
{
    public class MasterBL : IMasterBL
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public List<Frequence> LoadFrequencies()
        {
            using (IMasterDA MasterDA = new MasterDA())
            {
                return MasterDA.LoadFrequencies();
            }
        }

        public List<State> LoadStates()
        {
            using (IMasterDA MasterDA = new MasterDA())
            {
                return MasterDA.LoadStates();
            }
        }
    }
}
