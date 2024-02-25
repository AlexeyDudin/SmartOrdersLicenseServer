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
        [HttpGet("check/{key}/{pcHash}")]
        public IActionResult IsAvailable(string key, string pcHash)
        {
            return GetResponse(licenseServiseApi.IsAvailable(key, pcHash));
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
            return GetResponse(licenseServiseApi.AddKeysPool(count));
        }

        [AllowAnonymous]
        [HttpGet("add/temp/{expiredDate}")]
        public IActionResult AddKey(string expiredDate)
        {
            DateTime date = DateTime.Parse(expiredDate);
            return GetResponse(licenseServiseApi.AddKey(date));
        }

        [AllowAnonymous]
        [HttpGet("add/temp/{count}/{expiredDate}")]
        public IActionResult AddKeys(int count, string expiredDate)
        {
            DateTime date = DateTime.Parse(expiredDate);
            return GetResponse(licenseServiseApi.AddKeysPool(count, date));
        }

        [AllowAnonymous]
        [HttpGet("clean/{key}")]
        public IActionResult CleanPcHash(string key)
        {
            return GetResponse(licenseServiseApi.CleanPCHash(key));
        }

        [AllowAnonymous]
        [HttpGet("set/full/{key}")]
        public IActionResult SetFullLicense(string key)
        {
            return GetResponse(licenseServiseApi.SetFullLicense(key));
        }

        [AllowAnonymous]
        [HttpGet("set/{key}/{pchash}")]
        public IActionResult SetPcHash(string key, string pchash)
        {
            return GetResponse(licenseServiseApi.SetPcHash(key, pchash));
        }
    }
}
