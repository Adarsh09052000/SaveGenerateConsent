using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medinous.WebApi.Core.Dtos;
using Medinous.WebApi.Core.Interface;
using Medinous.WebApi.Businesslogic;

namespace Medinous.WebApi.Infrastructure.Repository
{
    public class GenerateConsentRepository:IGenerateConsentRepository 
    {
        public GenerateConsent _GenerateConsent;

        public string GetConsentEntryInitialData( string LocationCode)
        {
            _GenerateConsent = new GenerateConsent();
            string str = _GenerateConsent.GetConsentEntryInitialData(LocationCode);
            return str;
        }
        public string GetConsentAdditionalFields(string TemplateNo)
        {
            _GenerateConsent = new GenerateConsent();
            string str = _GenerateConsent.GetConsentAdditionalFields(TemplateNo);
            return str;
        }

        public string GetGenerateConsentDetails(string LocationCode, string PatientID, decimal IPNo, decimal OPNo)
        {
            _GenerateConsent = new GenerateConsent();
            string str = _GenerateConsent.GetGenerateConsentDetails(LocationCode, PatientID, IPNo, OPNo);
            return str;
        }
        public async Task<HttpCustomResponseMessage> SaveGenerateConsent(PopulateGenerateConsent generateConsent)
        {
            _GenerateConsent = new GenerateConsent();
            return await _GenerateConsent.SaveGenerateConsent(generateConsent);
        }
        public async Task<HttpCustomResponseMessage> DeleteConsentEntry(DeleteConsentEntry generateConsent)
        {
            _GenerateConsent = new GenerateConsent();
            return await _GenerateConsent.DeleteConsentEntry(generateConsent);
        }
        public string GetPlaceHolderData(string ConsentNo)
        {
            _GenerateConsent = new GenerateConsent();
            string str = _GenerateConsent.GetPlaceHolderData(ConsentNo);
            return str;
        }
        public string GetGenerateConsentHistory(GenerateConsentParams generateConsentParams)
        {
            _GenerateConsent = new GenerateConsent();
            string str = _GenerateConsent.GetGenerateConsentHistory(generateConsentParams);
            return str;
        }
    }
}
