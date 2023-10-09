using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medinous.WebApi.Core.Dtos
{
    public class PopulateGenerateConsent
    {
        public List<GenerateConsentHeader> PopulateGenerateConsentHeader { get; set; }
        public List<GenerateConsentDetail> PopulateGenerateConsentDetail { get; set; }

    }
    public class DeleteConsentEntry
    {
        public string ConsentNo { get; set; }
        public string ModifiedUser { get; set; }

    }

    public class GenerateConsentHeader:CommonDto
    {
        public string ConsentNo { get; set; }
        public DateTime ConsentDate { get; set; }
        public string ConsentTime { get; set; }
        public string PatientId { get; set; }
        public decimal? IpNo { get; set; }
        public decimal? OpNo { get; set; }
        public decimal ProcedureScheduleNo { get; set; }
        public string RecordCode { get; set; }
        public string TemplateNo { get; set; }
        public string SignedBy { get; set; }
        public string SignedByName { get; set; }
        public string DoctorCode { get; set; }
        public string CostCenterCode { get; set; }
        public string Remarks { get; set; }
        public string MachineId { get; set; }
        public string DeletedFlag { get; set; }
        public string ConsentFormFilename { get; set; }
      
    }
    public class GenerateConsentDetail:CommonDto
    {
        public int DetailNo { get; set; }
        public string ConsentNo { get; set; }
        public string AdditionalFieldName { get; set; }
        public string AdditionalFieldValue { get; set; }

    }

    public class PopulateGenerateConsentInitData 
    {
        public List<TemplateClass> PopulateConsentTemplate { get; set; }   
        public List<SetupMasterList> PopulateConsentSetupMaster { get; set; }
    }

    public class PopulateAdditionalFields 
    {
        public List<AdditionalFields> PopulateAdditionalFieldsList { get; set; }
    }

    public class AdditionalFields 
    {
        public string AdditionalFieldName { get; set; }
        public string AdditionalFieldValue { get; set; }
        public string ControlTitle { get; set; }
        public string ControlType { get; set; }
        public string QueryString { get; set; }
        public string OrderNo { get; set; }

    }
    public class TemplateClass
    {
        public string TemplateCode { get; set; }
        public string ConsentType { get; set; }
        public string TemplateName { get; set; }

    }
    public class PopulatePlaceHolderData
    {
        public List<PlaceHolderData> PopulatePlaceHolderDataList { get; set; }
    }
    public class PlaceHolderData
    {
        public string PLACEHOLDER_CODE { get; set; }
        public string PlaceHolder { get; set; }
        public string PlaceHolder_Value { get; set; }

    }
    public class PopulateGenerateConsentHistory
    {
        public List<GenerateConsentHistory> PopulateGenerateConsentHistoryList { get; set; }
    }
    public class GenerateConsentHistory
    {
        public string ConsentNo { get; set; }
        public string PatientId { get; set; }
        public string PatientName { get; set; }
        public string ServiceName { get; set; }
        public string OPIP { get; set; }
        public string DoctorName { get; set; }
        public DateTime? ConsentDate { get; set; }
        public string TemplateName { get; set; }
        public string ConsentFormFileName { get; set; }
        public string ViewButton { get; set; }
    }
    public class GenerateConsentParams
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string PatientId { get; set; }
        public string DoctorCode { get; set; }
        public decimal? OPNO { get; set; }
        public decimal? IPNO { get; set; }
        public string ServiceCode { get; set; }
    }
}
