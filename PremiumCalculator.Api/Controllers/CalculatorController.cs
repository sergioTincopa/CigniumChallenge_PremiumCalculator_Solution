using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PremiumCalculator.Entities.Data;
using PremiumCalculator.Business;
using PremiumCalculator.Api.Models;

namespace PremiumCalculator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly IConfiguration Configuration;

        public CalculatorController(IConfiguration IConfiguration)
        {
            Configuration = IConfiguration;
        }

        /// <summary>
        /// Method that obtains premium value depending on Request values
        /// </summary>
        /// Creation Date: 21/05/2020
        /// Creator: Sergio Tincopa Nolaso
        /// <param name="model">Parameters used for the calculation</param>
        /// <returns>Object with premium info</returns>
        [HttpPost]
        [Route("GetPremiumValue")]
        public IActionResult GetPremiumValue(CalculatorModel model)
        {
            List<ConfigurationData> lstData = new List<ConfigurationData>();

            try
            {

                using (ICalculatorBL CalculatorBL = new CalculatorBL())
                {
                    //Load configuration data to do calculation
                    lstData = CalculatorBL.LoadConfigurationData();

                    //Evaluate parameters (BirthDate, state and age) with data
                    var vResult = lstData.FirstOrDefault(t => {

                        if (model.State == Enums.StateName.cStateNY || model.State == Enums.StateName.cStateAL)
                        {
                            if (t.State == model.State && t.BirthMonth == model.BirthDate.Month && (t.StartAge <= model.Age && t.EndAge >= model.Age))                            
                                return true;
                            else if (t.State == model.State && t.BirthMonth == Enums.ValidationType.cAllMonths && t.StartAge <= model.Age && t.EndAge >= model.Age) 
                                return true;
                            else                           
                                return false;                            
                        }
                        else if (model.State == Enums.StateName.cStateAK)
                        {
                            if (t.State == model.State && t.BirthMonth == model.BirthDate.Month && (t.StartAge <= model.Age && t.EndAge >= model.Age))
                                return true;
                            else if (t.State == model.State && t.BirthMonth == model.BirthDate.Month && t.StartAge <= model.Age)
                                return true;
                            else if (t.State == model.State && t.BirthMonth == Enums.ValidationType.cAllMonths && t.StartAge <= model.Age && t.EndAge >= model.Age)
                                return true;
                            else
                                return false;
                        }
                        else if (t.State == Enums.ValidationType.cAllStates && t.BirthMonth == Enums.ValidationType.cAllMonths && t.StartAge <= model.Age && t.EndAge >= model.Age)                        
                            return true;
                        else                        
                            return false;
                              
                    });


                    return Ok(vResult);
                
                }                
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

    }
}
