using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        protected readonly DataContext _context;

        public BaseApiController(DataContext context)
        {
            _context = context;
        }

        [Route("/")]
        [Route("Index")]
        [Route("Home")]
        public IActionResult Index()
        {
            return Content("Welcome to the API, this is the root.");
        }



    }
}
