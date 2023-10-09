using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medinous.WebApi.Core.Dtos;

namespace Medinous.WebApi.Core.Interface
{
    public interface IGenerateConsentRepository
    {
        string GetGenerateConsentDetails(string LocationCode, string PatientID, decimal IPNo, decimal OPNo);
        string GetConsentEntryInitialData(string LocationCode);
        string GetConsentAdditionalFields(string TemplateNo);
        Task<HttpCustomResponseMessage> DeleteConsentEntry(DeleteConsentEntry generateConsent);
        Task<HttpCustomResponseMessage> SaveGenerateConsent(PopulateGenerateConsent generateConsent);
        string GetPlaceHolderData(string ConsentNo);
        string GetGenerateConsentHistory(GenerateConsentParams generateConsentParams);

    }
}
