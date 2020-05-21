using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http;

namespace PremiumCalculator.Client
{
    public class PremCalClient
    {
        private readonly HttpClient httpClient; 

        public PremCalClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        /// <summary>
        /// Method that runs get to web service
        /// </summary>
        /// Creation Date: 21/05/2020
        /// Creator: Sergio Tincopa Nolaso
        /// <param name="Url">Api Action Url</param>
        /// <returns>Object type TEntity</returns>
        public async Task<TEntity> Get<TEntity>(string strUrl)
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(strUrl);
                var vJsonResponse = response.Content.ReadAsStringAsync().Result;

                TEntity entity = default;
                if (response.IsSuccessStatusCode)
                    entity = JsonConvert.DeserializeObject<TEntity>(vJsonResponse);

                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method that runs post to web service
        /// </summary>
        /// Creation Date: 21/05/2020
        /// Creator: Sergio Tincopa Nolaso
        /// <param name="Url">Api Action Url</param>
        /// <param name="Request">Object</param>
        /// <returns>Object type TEntity</returns>
        public async Task<TEntity> Post<TEntity>(string strUrl, object objRequest) where TEntity : class
        {
            try
            {

                var vJson = JsonConvert.SerializeObject(objRequest);
                var vContent = new StringContent(vJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(strUrl, vContent);
                var vJsonResponse = response.Content.ReadAsStringAsync().Result;

                TEntity entity = default;
                if (response.IsSuccessStatusCode)
                {
                    entity = JsonConvert.DeserializeObject<TEntity>(vJsonResponse);
                }

                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
