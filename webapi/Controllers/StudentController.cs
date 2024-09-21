using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IConfiguration _configuration;
        public StudentController(IConfiguration iconfig) {

            _configuration = iconfig;
        }



    }
}
