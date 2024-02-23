using Domain.Models;
using SmartOrdersLicenseServer.DTOs;

namespace SmartOrdersLicenseServer.Converters
{
    public static class LicenseDTOConverter
    {
        public static License ToLicense(this LicenseDTO licenseDTO) 
        {
            if (licenseDTO == null)
                throw new ArgumentNullException(nameof(licenseDTO));
            return new License() 
            {
                Key = licenseDTO.Key,
                PCHash = licenseDTO.PcHash,
                ExpirationDate = licenseDTO.ExpirationDate,
            };
        }

        public static LicenseDTO ToLicenseDTO(this License license) 
        {
            if (license == null)
                throw new ArgumentNullException(nameof(license));
            return new LicenseDTO()
            {
                Key = license.Key,
                PcHash = license.PCHash,
                ExpirationDate = license.ExpirationDate
            };
        }

        public static List<LicenseDTO> ToLicenseDTOList(this List<License> licenses)
        {
            if (licenses == null)
                throw new ArgumentNullException(nameof(licenses));
            List<LicenseDTO> result = new List<LicenseDTO>();
            foreach(License license in licenses) 
            {
                result.Add(license.ToLicenseDTO());
            }
            return result;
        }

        public static List<License> ToLicenseList(this List<LicenseDTO> licenseDTOs)
        {
            if (licenseDTOs == null)
                throw new ArgumentNullException(nameof(licenseDTOs));
            List<License> result = new List<License>();
            foreach (LicenseDTO license in licenseDTOs)
            {
                result.Add(license.ToLicense());
            }
            return result;
        }
    }
}
