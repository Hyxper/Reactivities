using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        protected IMediator Mediator => HttpContext.RequestServices.GetService<IMediator>()!; //we could check for null here, but we know it will never be null as we have registered the Mediator in the Program.cs file

        [Route("/")]
        [Route("Index")]
        [Route("Home")]
        public IActionResult Index()
        {
            return Content("Welcome to the API, this is the root.");
        }



    }
}
