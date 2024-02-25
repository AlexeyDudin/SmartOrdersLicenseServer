
using Domain.Foundation;
using Domain.Models;

namespace Application
{
    public class LicenseService : ILicenseService
    {
        private readonly IUnitOfWork unitOfWork;
        public LicenseService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public License ActivateFullLicense(string key)
        {
            var license = unitOfWork.LicenseRepository.Where(l => l.Key == key).FirstOrDefault();
            if (license == null)
                throw new Exception($"Ключ {key} не найден в БД");
            license.ExpirationDate = null;
            unitOfWork.Commit();
            return license;
        }

        public License AddKey(DateTime? expirationDate = null)
        {
            var license = GenerateNewLicense(expirationDate);
            unitOfWork.LicenseRepository.Add(license);
            unitOfWork.Commit();
            return license;
        }

        public List<License> AddKeysPool(int count, DateTime? expirationDate = null)
        {
            var result = new List<License>();
            for (int i = 0; i < count; i++)
            {
                var license = GenerateNewLicense(expirationDate);
                result.Add(license);
                unitOfWork.LicenseRepository.Add(license);
            }
            unitOfWork.Commit();
            return result;
        }

        public License CleanPCHash(string key)
        {
            var license = unitOfWork.LicenseRepository.Where(l => l.Key == key).FirstOrDefault();
            if (license == null)
                throw new Exception($"Ключ {key} не найден в БД");
            license.PCHash = "";
            unitOfWork.Commit();
            return license;
        }

        public List<License> GetAll()
        {
            return unitOfWork.LicenseRepository.GetAll();
        }

        public License IsAvailable(string key, string hash)
        {
            License? license = unitOfWork.LicenseRepository.Where(l => l.Key == key && l.PCHash == hash).FirstOrDefault();
            if (license == null)
            {
                var tmpLicense = unitOfWork.LicenseRepository.Where(l => l.Key == key).FirstOrDefault();
                if (tmpLicense == null)
                    throw new Exception($"Ключ {key} не найден в БД");
                if (string.IsNullOrEmpty(tmpLicense.PCHash))
                    return tmpLicense;
                throw new Exception($"Ключ {key} уже занят другим компьютером");
            }
            
            return license;
        }

        public License SetPcHash(string key, string pcHash)
        {
            var licenseInDb = unitOfWork.LicenseRepository.Where(l => l.Key == key).FirstOrDefault();
            if (licenseInDb == null)
                throw new Exception($"Ключ {key} не найден в БД");
            licenseInDb.PCHash = pcHash;
            unitOfWork.Commit();
            return licenseInDb;
        }

        private License GenerateNewLicense(DateTime? expirationDate = null)
        {
            string result = Guid.NewGuid().ToString();
            return new License()
            {
                Key = result,
                PCHash = "",
                ExpirationDate = expirationDate
            };
        }
    }
}
