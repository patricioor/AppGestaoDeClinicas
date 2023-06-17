using GeCli.Back.Shared.ModelView.ErrorMessage;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace GeCli.Back.API.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("error")]
        public ErrorMessage Error()
        {            
            Response.StatusCode = 500;
            return new ErrorMessage(HttpContext?.TraceIdentifier);
        }
    }
}
