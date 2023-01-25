namespace ZenitramAPI.Models
{
    public class AzureOptions
    {
        public string StorageConnectionString { get; set; }
        public string KeyVault { get; set; }
        public string ApplicationId { get; set; }
        public string TenantId { get; set; }
        public string BlobConnectionString { get; set; }
        public string StorageBlobConnectionString { get; set; }
        public string BlobStorageContainer { get; set; }
        public string BlobsFolderName { get; set; }
        public string AutomationAccount { get; set; }
        public string AutomationResourceGroup { get; set; }
        public string AutomationTenant { get; set; }
        public string AutomationAppSecret { get; set; }
        public string AzureSubscriptionId { get; set; }
        public string AppCertificateThumbprint { get; set; }
        public string AppSettingFile { get; set; }
        public string MessageApiKey { get; set; }
        public string TenantActivePlayCountMax { get; set; }
    }
}
