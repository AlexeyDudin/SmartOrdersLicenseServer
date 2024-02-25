using SmartOrdersLicenseServer.DTOs;

namespace SmartOrdersLicenseServer.Services
{
    public interface ILicenseServiseAPI
    {
        Result IsAvailable(string key, string PCHash);
        Result AddKey(DateTime? expiredDate = null);
        Result AddKeysPool(int count, DateTime? expiredDate = null);
        Result SetPcHash(string key, string pcHash);
        Result CleanPCHash(string key);
        Result SetFullLicense(string key);
        Result GetAll();
    }
}
