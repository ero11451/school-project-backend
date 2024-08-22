
using BackendApp.Models;
using BackendApp.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BackendApp.Controllers
{
    [ApiController]
    [Route("api/index")]
    public class ApiDefualt: ControllerBase
    {
         [HttpGet]
         public async Task<IActionResult> GetIndex()
            {  
               return Ok("this is the test api");
            }

    }
}
