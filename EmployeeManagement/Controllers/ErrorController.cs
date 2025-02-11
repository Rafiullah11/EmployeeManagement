using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> loger;

        public ErrorController(ILogger<ErrorController> loger)
        {
            this.loger = loger;
        }
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

            switch (statusCode)
            {
                case 404:
                        ViewBag.ErrorMessage = "Sorry,  the resource you requested is not found";
                    loger.LogWarning($"404 Error occured. path = {statusCodeResult.OriginalPath}" + $"and QueryString = {statusCodeResult.OriginalQueryString}");
                    break;
            }
            return View("NotFound");
        }
        [Route("Error")]
        [AllowAnonymous]
        public IActionResult Error()
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            loger.LogError($"The path {exceptionDetails.Path} threw an exception {exceptionDetails.Error}"); 

            return View("Error");
        }
    }
}
