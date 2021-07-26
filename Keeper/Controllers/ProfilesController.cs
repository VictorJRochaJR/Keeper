using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
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
        private readonly VaultsService _vs;
        public ProfilesController(ProfilesService ps, KeepsService ks, VaultsService vs)
        {
            _ps = ps;
            _ks = ks;
            _vs = vs;
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
    public async Task<ActionResult<List<Keep>>> GetAllKeepsById(string id)
    {
                Account userInfo =  await HttpContext.GetUserInfoAsync<Account>();

        try
        {
          List<Keep>  keep = _ks.KeepByProfileId(id, userInfo);
            return Ok(keep);
        }
        catch (System.Exception e)
        {
            
    return BadRequest(e.Message);
        }
        
    }

    [HttpGet("{id}/vaults")]
    public async Task<ActionResult<List<Keep>>> GetAllVaultsById(string id)
    {
        try
        {
        Account userInfo =  await HttpContext.GetUserInfoAsync<Account>();

            List<Vault> vault = _vs.GetVaultsById(id, userInfo);
            return Ok(vault);

        }
        catch (System.Exception e)
        {
            
           return BadRequest(e.Message);
        }
    }

    }
}