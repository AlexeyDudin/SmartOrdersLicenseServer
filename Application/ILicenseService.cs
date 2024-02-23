using Domain.Models;

namespace Application
{
    public interface ILicenseService
    {
        License IsAvailable(string key, string hash);
        License AddKey(DateTime? expirationDate = null);
        List<License> AddKeysPool(int count, DateTime? expirationDate = null);
        License CleanPCHash(string key);
        License ActivateFullLicense(string key);
        List<License> GetAll();
        License SetPcHash(string key, string pcHash);
    }
}
