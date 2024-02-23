using Microsoft.AspNetCore.Mvc;
using SmartOrdersLicenseServer.DTOs;

namespace SmartOrdersLicenseServer.Controllers
{
    public class BaseController : Controller
    {
        protected IActionResult GetResponse(Result response)
        {
            return response.Code switch
            {
                ResponseStatus.Ok => Ok(response),
                ResponseStatus.Error => BadRequest(response),
                _ => BadRequest(response)
            };
        }
    }
}
