using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PremiumCalculator.Client;
using PremiumCalculator.Web.Models;
using PremiumCalculator.Entities;

namespace PremiumCalculator.Web.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly IConfiguration Configuration;
        private readonly ICalculatorClient CalculatorClient;        

        public CalculatorController(IConfiguration IConfiguration, ICalculatorClient ICalculatorClient)
        {
            Configuration = IConfiguration;
            CalculatorClient = ICalculatorClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Action that obtains premium value
        /// </summary>
        /// Creation Date: 21/05/2020
        /// Creator: Sergio Tincopa Nolaso
        /// <param name="model">Parameters used for the calculation</param>
        /// <returns>Object type ConfigurationData</returns>
        public async Task<IActionResult> CalculatePremiumValue(CalculatorModel model)
        {
            ResponseModel Response = new ResponseModel();

            try
            {
                Response.Result = await CalculatorClient.GetPremiumValue(model);
            }
            catch (Exception ex)
            {
                Response.ExceptionMessage = ex.Message;
            }

            return Json(Response);
        }

        /// <summary>
        /// Action that gets list of states
        /// </summary>
        /// Creation Date: 21/05/2020
        /// Creator: Sergio Tincopa Nolaso
        /// <param></param>
        /// <returns>List of objects type State</returns>
        [HttpGet]
        public async Task<IActionResult> GetStates()
        {
            ResponseModel Response = new ResponseModel();

            try
            {
                Response.Result = await CalculatorClient.GetStates();              
            }
            catch (Exception ex)
            {
                Response.ExceptionMessage = ex.Message;
            }

            return Ok(Response);
        }

        /// <summary>
        /// Action that gets list of frequencies
        /// </summary>
        /// Creation Date: 21/05/2020
        /// Creator: Sergio Tincopa Nolaso
        /// <param></param>
        /// <returns>List of objects type Frequence</returns>
        [HttpGet]
        public async Task<IActionResult> GetFrequencies()
        {
            ResponseModel Response = new ResponseModel();

            try
            {
                Response.Result = await CalculatorClient.GetFrequencies();
            }
            catch (Exception ex)
            {
                Response.ExceptionMessage = ex.Message;
            }

            return Ok(Response);
        }
    }
}
