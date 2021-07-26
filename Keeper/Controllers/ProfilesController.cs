using System.Collections.Generic;
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
        private readonly KeepsService _ks;
        public ProfilesController(ProfilesService ps, KeepsService ks)
        {
            _ps = ps;
            _ks = ks;
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

    [HttpGet("{id}/keeps")]
    public ActionResult<List<Keep>> GetAllKeepsById(string id)
    {
        try
        {
          List<Keep>  keep = _ks.KeepByProfileId(id);
            return Ok(keep);
        }
        catch (System.Exception e)
        {
            
    return BadRequest(e.Message);
        }
        
    }

    }
}