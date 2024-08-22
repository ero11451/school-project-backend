
using BackendApp.Models;
using BackendApp.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendApp.Data;

namespace BackendApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Location : ControllerBase
    {
        private readonly AppDbContext _context;
        public Location(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<LocationModel>>> GetLocations()
        {
            var locations = await _context.LocationModel.ToListAsync();
            return Ok(locations);
        }

        [HttpPost]
        public async Task<ActionResult> CreateLocation(LocationRequest body)
        {
            var locationNew = new LocationModel
            {
                location = body.location
            };
            _context.LocationModel.Add(locationNew);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetLocations), locationNew);
        }
    }

    public class LocationRequest
    {
        public string location { get; set; }
    }
}
