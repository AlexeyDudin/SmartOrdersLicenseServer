namespace SmartOrdersLicenseServer.DTOs
{
    public class LicenseDTO
    {
        public string Key { get; set; }
        public string PcHash { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}
