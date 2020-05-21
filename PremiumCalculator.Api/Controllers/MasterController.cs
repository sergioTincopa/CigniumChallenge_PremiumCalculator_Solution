using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PremiumCalculator.Entities;
using PremiumCalculator.Business;

namespace PremiumCalculator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterController : ControllerBase
    {
        private readonly IConfiguration Configuration;

        public MasterController(IConfiguration IConfiguration)
        {
            Configuration = IConfiguration;
        }

        [HttpGet]
        [Route("GetStates")]
        public IActionResult GetStates()
        {
            List<State> lstStates = new List<State>();

            try
            {
                using (IMasterBL MasterBL = new MasterBL())
                {
                    lstStates = MasterBL.LoadStates();
                }

                return Ok(lstStates);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        [Route("GetFrequencies")]
        public IActionResult GetFrequencies()
        {
            List<Frequence> lstFrequencies = new List<Frequence>();

            try
            {
                using (IMasterBL MasterBL = new MasterBL())
                {
                    lstFrequencies = MasterBL.LoadFrequencies();
                }

                return Ok(lstFrequencies);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        
    }
}
