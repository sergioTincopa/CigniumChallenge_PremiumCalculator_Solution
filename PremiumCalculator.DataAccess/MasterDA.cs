using PremiumCalculator.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PremiumCalculator.DataAccess
{
    public class MasterDA : IMasterDA
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Method that list states
        /// </summary>
        /// Creation Date: 21/05/2020
        /// Creator: Sergio Tincopa Nolaso
        /// <param></param>
        /// <returns>States list</returns>
        public List<State> LoadStates()
        {
            List<State> lstStates = new List<State>();

            lstStates.Add(new State { Code = "AL", Name = "Alabama" });
            lstStates.Add(new State { Code = "AK", Name = "Alaska" });
            lstStates.Add(new State { Code = "AZ", Name = "Arizona" });
            lstStates.Add(new State { Code = "AR", Name = "Arkansas" });
            lstStates.Add(new State { Code = "CA", Name = "California" });
            lstStates.Add(new State { Code = "CO", Name = "Colorado" });
            lstStates.Add(new State { Code = "CT", Name = "Connecticut" });
            lstStates.Add(new State { Code = "DE", Name = "Delaware" });
            lstStates.Add(new State { Code = "DC", Name = "District Of Columbia" });
            lstStates.Add(new State { Code = "FL", Name = "Florida" });
            lstStates.Add(new State { Code = "GA", Name = "Georgia" });
            lstStates.Add(new State { Code = "HI", Name = "Hawaii" });
            lstStates.Add(new State { Code = "ID", Name = "Idaho" });
            lstStates.Add(new State { Code = "IL", Name = "Illinois" });
            lstStates.Add(new State { Code = "IN", Name = "Indiana" });
            lstStates.Add(new State { Code = "IA", Name = "Iowa" });
            lstStates.Add(new State { Code = "KS", Name = "Kansas" });
            lstStates.Add(new State { Code = "KY", Name = "Kentucky" });
            lstStates.Add(new State { Code = "LA", Name = "Louisiana" });
            lstStates.Add(new State { Code = "ME", Name = "Maine" });
            lstStates.Add(new State { Code = "MD", Name = "Maryland" });
            lstStates.Add(new State { Code = "MA", Name = "Massachusetts" });
            lstStates.Add(new State { Code = "MI", Name = "Michigan" });
            lstStates.Add(new State { Code = "MN", Name = "Minnesota" });
            lstStates.Add(new State { Code = "MS", Name = "Mississippi" });
            lstStates.Add(new State { Code = "MO", Name = "Missouri" });
            lstStates.Add(new State { Code = "MT", Name = "Montana" });
            lstStates.Add(new State { Code = "NE", Name = "Nebraska" });
            lstStates.Add(new State { Code = "NV", Name = "Nevada" });
            lstStates.Add(new State { Code = "NH", Name = "New Hampshire" });
            lstStates.Add(new State { Code = "NJ", Name = "New Jersey" });
            lstStates.Add(new State { Code = "NM", Name = "New Mexico" });
            lstStates.Add(new State { Code = "NY", Name = "New York" });
            lstStates.Add(new State { Code = "NC", Name = "North Carolina" });
            lstStates.Add(new State { Code = "ND", Name = "North Dakota" });
            lstStates.Add(new State { Code = "OH", Name = "Ohio" });
            lstStates.Add(new State { Code = "OK", Name = "Oklahoma" });
            lstStates.Add(new State { Code = "OR", Name = "Oregon" });
            lstStates.Add(new State { Code = "PA", Name = "Pennsylvania" });
            lstStates.Add(new State { Code = "RI", Name = "Rhode Island" });
            lstStates.Add(new State { Code = "SC", Name = "South Carolina" });
            lstStates.Add(new State { Code = "SD", Name = "South Dakota" });
            lstStates.Add(new State { Code = "TN", Name = "Tennessee" });
            lstStates.Add(new State { Code = "TX", Name = "Texas" });
            lstStates.Add(new State { Code = "UT", Name = "Utah" });
            lstStates.Add(new State { Code = "VT", Name = "Vermont" });
            lstStates.Add(new State { Code = "VA", Name = "Virginia" });
            lstStates.Add(new State { Code = "WA", Name = "Washington" });
            lstStates.Add(new State { Code = "WV", Name = "West Virginia" });
            lstStates.Add(new State { Code = "WI", Name = "Wisconsin" });
            lstStates.Add(new State { Code = "WY", Name = "Wyoming" });

            return lstStates;
        }

        /// <summary>
        /// Method that list frequencies
        /// </summary>
        /// Creation Date: 21/05/2020
        /// Creator: Sergio Tincopa Nolaso
        /// <param></param>
        /// <returns>Frequencies list</returns>
        public List<Frequence> LoadFrequencies()
        {
            List<Frequence> lstFrequencies = new List<Frequence>();

            lstFrequencies.Add(new Frequence { Code = 1, Name = "Monthly", Months = 1 });
            lstFrequencies.Add(new Frequence { Code = 2, Name = "Quarterly", Months = 3 });
            lstFrequencies.Add(new Frequence { Code = 3, Name = "Semi-Annually", Months = 6 });
            lstFrequencies.Add(new Frequence { Code = 4, Name = "Annualy", Months = 12 });

            return lstFrequencies;
        }
    }
}
