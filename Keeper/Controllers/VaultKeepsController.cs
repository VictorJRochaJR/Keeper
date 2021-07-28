using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Keeper.Models;
using Keeper.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keeper.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VaultKeepsController: ControllerBase
    {
        private readonly VaultKeepsService _vks;
        public VaultKeepsController(VaultKeepsService vks)
        {
            _vks = vks;
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<VaultKeep>> Create([FromBody] VaultKeep newvk)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                newvk.CreatorId = userInfo.Id;
                var v = _vks.Create(newvk);
                
                return Ok(newvk);

            }
            catch (System.Exception e)
            {
                
              return BadRequest(e.Message);
            }
            
        }

        [HttpGet("{id}")]
        public ActionResult<VaultKeep> Get(int id)
        {
            return Ok(_vks.Get(id));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                VaultKeep vaultKeep =  _vks.Get(id);
                if (vaultKeep.CreatorId == userInfo.Id)
                {
                _vks.Delete(id);
                return Ok("deleted");
                }
                else
                {
                    return BadRequest();
                }
              
            }
            catch (System.Exception e)
            {
             return BadRequest(e.Message);        
            }
        }
    }
}