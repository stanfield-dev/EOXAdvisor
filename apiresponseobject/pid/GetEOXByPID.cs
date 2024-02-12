using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace EOXAdvisor.APIResponseObjects.PID
{
    public class PaginationResponseRecord
    {
        [JsonPropertyName("PageIndex")]
        public int PageIndex { get; set; }

        [JsonPropertyName("LastIndex")]
        public int LastIndex { get; set; }

        [JsonPropertyName("TotalRecords")]
        public int TotalRecords { get; set; }

        [JsonPropertyName("PageRecords")]
        public int PageRecords { get; set; }
    }

    public class EOXExternalAnnouncementDate
    {
        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("dateFormat")]
        public string DateFormat { get; set; }
    }

    public class EndOfSaleDate
    {
        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("dateFormat")]
        public string DateFormat { get; set; }
    }

    public class EndOfSWMaintenanceReleases
    {
        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("dateFormat")]
        public string DateFormat { get; set; }
    }

    public class EndOfSecurityVulSupportDate
    {
        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("dateFormat")]
        public string DateFormat { get; set; }
    }

    public class EndOfRoutineFailureAnalysisDate
    {
        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("dateFormat")]
        public string DateFormat { get; set; }
    }

    public class EndOfServiceContractRenewal
    {
        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("dateFormat")]
        public string DateFormat { get; set; }
    }

    public class LastDateOfSupport
    {
        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("dateFormat")]
        public string DateFormat { get; set; }
    }

    public class EndOfSvcAttachDate
    {
        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("dateFormat")]
        public string DateFormat { get; set; }
    }

    public class UpdatedTimeStamp
    {
        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("dateFormat")]
        public string DateFormat { get; set; }
    }

    public class EOXMigrationDetails
    {
        [JsonPropertyName("ActiveFlag")]
        public string ActiveFlag { get; set; }

        [JsonPropertyName("MigrationInformation")]
        public string MigrationInformation { get; set; }

        [JsonPropertyName("MigrationOption")]
        public string MigrationOption { get; set; }

        [JsonPropertyName("MigrationProductId")]
        public string MigrationProductId { get; set; }

        [JsonPropertyName("MigrationProductName")]
        public string MigrationProductName { get; set; }

        [JsonPropertyName("MigrationStrategy")]
        public string MigrationStrategy { get; set; }

        [JsonPropertyName("MigrationProductInfoURL")]
        public string MigrationProductInfoURL { get; set; }
    }

    public class EOXRecord
    {
        [JsonPropertyName("EOLProductID")]
        public string EOLProductID { get; set; }

        [JsonPropertyName("ProductIDDescription")]
        public string ProductIDDescription { get; set; }

        [JsonPropertyName("ProductBulletinNumber")]
        public string ProductBulletinNumber { get; set; }

        [JsonPropertyName("LinkToProductBulletinURL")]
        public string LinkToProductBulletinURL { get; set; }

        [JsonPropertyName("EOXExternalAnnouncementDate")]
        public EOXExternalAnnouncementDate EOXExternalAnnouncementDate { get; set; }

        [JsonPropertyName("EndOfSaleDate")]
        public EndOfSaleDate EndOfSaleDate { get; set; }

        [JsonPropertyName("EndOfSWMaintenanceReleases")]
        public EndOfSWMaintenanceReleases EndOfSWMaintenanceReleases { get; set; }

        [JsonPropertyName("EndOfSecurityVulSupportDate")]
        public EndOfSecurityVulSupportDate EndOfSecurityVulSupportDate { get; set; }

        [JsonPropertyName("EndOfRoutineFailureAnalysisDate")]
        public EndOfRoutineFailureAnalysisDate EndOfRoutineFailureAnalysisDate { get; set; }

        [JsonPropertyName("EndOfServiceContractRenewal")]
        public EndOfServiceContractRenewal EndOfServiceContractRenewal { get; set; }

        [JsonPropertyName("LastDateOfSupport")]
        public LastDateOfSupport LastDateOfSupport { get; set; }

        [JsonPropertyName("EndOfSvcAttachDate")]
        public EndOfSvcAttachDate EndOfSvcAttachDate { get; set; }

        [JsonPropertyName("UpdatedTimeStamp")]
        public UpdatedTimeStamp UpdatedTimeStamp { get; set; }

        [JsonPropertyName("EOXMigrationDetails")]
        public EOXMigrationDetails EOXMigrationDetails { get; set; }

        [JsonPropertyName("EOXInputType")]
        public string EOXInputType { get; set; }

        [JsonPropertyName("EOXInputValue")]
        public string EOXInputValue { get; set; }
    }

    public class EOXByRecord
    {
        [JsonPropertyName("PaginationResponseRecord")]
        public PaginationResponseRecord PaginationResponseRecord { get; set; }

        [JsonPropertyName("EOXRecord")]
        public List<EOXRecord> EOXRecord { get; set; }
    }


}