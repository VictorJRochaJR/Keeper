using Keeper.Models;
using Keeper.Services;
using Microsoft.AspNetCore.Mvc;

namespace Keeper.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfilesController : ControllerBase
    {
        private readonly ProfilesService _ps;
        public ProfilesController(ProfilesService ps)
        {
            _ps = ps;
        }
        [HttpGet("{id}")]
        public ActionResult<Profile> Get(string id)
        {
        try
        {
            Profile profile = _ps.GetProfileById(id);
            return Ok(profile);
        }
        catch (System.Exception e)
        {
            
return BadRequest(e.Message);      
  }
        }
    }
}