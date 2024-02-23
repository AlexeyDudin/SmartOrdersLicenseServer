using Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartOrdersLicenseServer.DTOs;
using SmartOrdersLicenseServer.Services;

namespace SmartOrdersLicenseServer.Controllers
{
    [Route("api/license")]
    public class LicenseController : BaseController
    {
        private readonly ILicenseServiseAPI licenseServiseApi;
        public LicenseController(ILicenseServiseAPI licenseServise)
        {
            licenseServiseApi = licenseServise;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll()
        {
            return GetResponse(licenseServiseApi.GetAll());
        }

        [AllowAnonymous]
        [HttpGet, Route("check")]
        public IActionResult IsAvailable([FromRoute] LicenseDTO license)
        {
            return GetResponse(licenseServiseApi.IsAvailable(license.Key, license.PcHash));
        }

        [AllowAnonymous]
        [HttpGet, Route("add")]
        public IActionResult AddKey()
        {
            return GetResponse(licenseServiseApi.AddKey());
        }

        [AllowAnonymous]
        [HttpGet("add/{count}")]
        public IActionResult AddKeys(int count)
        {
            return GetResponse(licenseServiseApi.AddKey());
        }

        [AllowAnonymous]
        [HttpGet("add/temp/{expiredDate}")]
        public IActionResult AddKey(DateTime expiredDate)
        {
            return GetResponse(licenseServiseApi.AddKey(expiredDate));
        }

        [AllowAnonymous]
        [HttpGet("add/temp/{count}/{expiredDate}")]
        public IActionResult AddKeys(int count, DateTime expiredDate)
        {
            return GetResponse(licenseServiseApi.AddKeysPool(count, expiredDate));
        }

        [AllowAnonymous]
        [HttpGet("clean/{key}")]
        public IActionResult CleanPcHash(string key)
        {
            return GetResponse(licenseServiseApi.CleanPCHash(key));
        }

        [AllowAnonymous]
        [HttpGet("set/full")]
        public IActionResult SetFullLicense([FromRoute] LicenseDTO license)
        {
            return GetResponse(licenseServiseApi.SetFullLicense(license));
        }

        [AllowAnonymous]
        [HttpGet("set/{key}/{pchash}")]
        public IActionResult SetPcHash(string key, string pchash)
        {
            return GetResponse(licenseServiseApi.SetPcHash(key, pchash));
        }
    }
}
