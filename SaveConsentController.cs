using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Medinous.WebApi.Core.Interface;
using Medinous.WebApi.Core.Dtos;
using Microsoft.Extensions.Configuration;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using Medinous.WebApi.Infrastructure.Repository;

namespace Medinous.WebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class GenerateConsentController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly IGenerateConsentRepository GenerateConsentRepository;
        private readonly IConfiguration configuration;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_IGenerateConsentRepository"></param>
        /// <param name="_configuration"></param>
        public GenerateConsentController (IGenerateConsentRepository _IGenerateConsentRepository, IConfiguration _configuration)
        {
            GenerateConsentRepository = _IGenerateConsentRepository;
            configuration = _configuration;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="TemplateNo"></param>
        /// <param name="LocationCode"></param>
        /// <returns></returns>
        [HttpGet("GetConsentEntryInitialData")]
        public IActionResult GetConsentEntryInit(string LocationCode)
        {

            var newdata = GenerateConsentRepository.GetConsentEntryInitialData( LocationCode);
            if (newdata.Contains("HttpCode") == false)
            {
                var listData = Newtonsoft.Json.JsonConvert.DeserializeObject<PopulateGenerateConsentInitData>(newdata);
                return Ok(listData);
            }
            else
            {
                return Ok(newdata);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="TemplateNo"></param>
        /// <returns></returns>
        [HttpGet("GetConsentAdditionalFields")]
        public IActionResult GetConsentAdditionalFields(string TemplateNo)
        {

            var newdata = GenerateConsentRepository.GetConsentAdditionalFields(TemplateNo);
            return Ok(newdata);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="LocationCode"></param>
        /// <param name="PatientID"></param>
        /// <param name="IPNo"></param>
        /// <param name="OPNo"></param>
        /// <returns></returns>
        [HttpGet("GetGenerateConsentDetails")]
        public IActionResult GetGenerateConsentDetails(string LocationCode, string PatientID, decimal IPNo, decimal OPNo)
        {

            var newdata = GenerateConsentRepository.GetGenerateConsentDetails(LocationCode, PatientID, IPNo, OPNo);
            if (newdata.Contains("HttpCode") == false)
            {
                var listData = Newtonsoft.Json.JsonConvert.DeserializeObject<PopulateGenerateConsent>(newdata);
                return Ok(listData);
            }
            else
            {
                return Ok(newdata);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="generateConsent"></param>
        /// <returns></returns>
        [HttpPost("SaveGenerateConsent")]
        public async Task<IActionResult> SaveGenerateConsent([FromBody] PopulateGenerateConsent generateConsent)
        {
            var result = await GenerateConsentRepository.SaveGenerateConsent(generateConsent);
            return Ok(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ConsentNo"></param>
        /// <returns></returns>
        [HttpGet("GetPlaceHolderData")]
        public IActionResult GetPlaceHolderData(string ConsentNo)
        {

            var newdata = GenerateConsentRepository.GetPlaceHolderData(ConsentNo);
            if (newdata.Contains("HttpCode") == false)
            {
                var listData = Newtonsoft.Json.JsonConvert.DeserializeObject<PopulatePlaceHolderData>(newdata);
                return Ok(listData);
            }
            else
            {
                return Ok(newdata);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="generateConsent"></param>
        /// <returns></returns>
        [HttpPost("DeleteConsentEntry")]
        public async Task<IActionResult> DeleteConsentEntry([FromBody] DeleteConsentEntry generateConsent)
        {
            var result = await GenerateConsentRepository.DeleteConsentEntry(generateConsent);
            return Ok(result);
        }
        /// <summary>
        /// /
        /// </summary>
        /// <param name="generateConsentParams"></param>
        /// <returns></returns>
        [HttpGet("GetGenerateConsentHistory")]
        public IActionResult GetGenerateConsentHistory([FromQuery]GenerateConsentParams generateConsentParams)
        {

            var newdata = GenerateConsentRepository.GetGenerateConsentHistory(generateConsentParams);
            if (newdata.Contains("HttpCode") == false)
            {
                var listData = Newtonsoft.Json.JsonConvert.DeserializeObject<PopulateGenerateConsentHistory>(newdata);
                return Ok(listData);
            }
            else
            {
                return Ok(newdata);
            }
        }
    }
}
