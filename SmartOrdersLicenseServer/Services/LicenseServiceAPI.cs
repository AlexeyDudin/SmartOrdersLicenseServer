using Application;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SmartOrdersLicenseServer.Converters;
using SmartOrdersLicenseServer.DTOs;

namespace SmartOrdersLicenseServer.Services
{
    public class LicenseServiceAPI : ILicenseServiseAPI
    {
        private readonly ILicenseService licenseService;
        public LicenseServiceAPI(ILicenseService licenseService)
        {
            this.licenseService = licenseService;
        }
        public Result AddKey(DateTime? expiredDate = null)
        {
            try
            {
                return new Result(licenseService.AddKey(expiredDate).ToLicenseDTO(), ResponseStatus.Ok);
            }
            catch (Exception ex)
            {
                return new Result(ex.Message, ResponseStatus.Error);
            }
        }

        public Result AddKeysPool(int count, DateTime? expiredDate = null)
        {
            try
            {
                return new Result(licenseService.AddKeysPool(count, expiredDate).ToLicenseDTOList(), ResponseStatus.Ok);
            }
            catch (Exception ex)
            {
                return new Result(ex.Message, ResponseStatus.Error);
            }
        }

        public Result CleanPCHash(string key)
        {
            try
            {
                return new Result(licenseService.CleanPCHash(key).ToLicenseDTO(), ResponseStatus.Ok);
            }
            catch (Exception ex)
            {
                return new Result(ex.Message, ResponseStatus.Error);
            }
        }

        public Result GetAll()
        {
            try
            {
                return new Result(licenseService.GetAll().ToLicenseDTOList(), ResponseStatus.Ok);
            }
            catch (Exception ex)
            {
                return new Result(ex.Message, ResponseStatus.Error);
            }
        }

        public Result IsAvailable(string key, string PCHash)
        {
            try
            {
                return new Result(licenseService.IsAvailable(key, PCHash).ToLicenseDTO(), ResponseStatus.Ok);
            }
            catch (Exception ex)
            {
                return new Result(ex.Message, ResponseStatus.Error);
            }
        }

        public Result SetFullLicense(LicenseDTO license)
        {
            try
            {
                return new Result(licenseService.ActivateFullLicense(license.Key).ToLicenseDTO(), ResponseStatus.Ok);
            }
            catch (Exception ex)
            {
                return new Result(ex.Message, ResponseStatus.Error);
            }
        }

        public Result SetPcHash(string key, string pcHash)
        {
            try
            {
                return new Result(licenseService.SetPcHash(key ,pcHash).ToLicenseDTO(), ResponseStatus.Ok);
            }
            catch (Exception ex)
            {
                return new Result(ex.Message, ResponseStatus.Error);
            }
        }
    }
}
