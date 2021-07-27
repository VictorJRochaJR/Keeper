using System.Collections.Generic;
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
    public class VaultsController : ControllerBase
    {
        private readonly VaultsService _vs;
        private readonly KeepsService _ks;

        public VaultsController(VaultsService vs, KeepsService ks)
        {
            _vs = vs;
            _ks = ks;
        }


        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Vault>> Create([FromBody]Vault vault)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                vault.CreatorId = userInfo.Id;
                var v = _vs.Create(vault);
                vault.Creator = userInfo;
                return Ok(v);
            }
            catch (System.Exception e)
            {
                
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Vault> GetOne(int id)
        {
            try
            {
                Vault vault = _vs.GetOne(id);
                return Ok(vault);
            }
            catch (System.Exception e)
            {
                
             return BadRequest(e.Message);
            }
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<Vault>> Update(int id, [FromBody] Vault v)
    {
        try
        {
            Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
            v.Id = id;
            Vault newVault = _vs.Update(v, userInfo.Id);
            newVault.Creator = userInfo;
            return Ok(newVault);    
        }
        catch (System.Exception e)
        {
            return BadRequest(e.Message);
    }

    }

   [Authorize]
   [HttpDelete("{id}")]
   public async Task<ActionResult<string>> Remove(int id)
   {
       try
       {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        _vs.Delete(id, userInfo.Id);
        return Ok("Successfully  Removed");
       }
       catch (System.Exception e)
       {
           return BadRequest(e.Message);
       }
   }


   [HttpGet("{id}/keeps")]
   public async Task<ActionResult<IEnumerable<VaultKeepViewModel>>> GetKeepsByVaultId(int id)
   {
       try
       {
         Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
            
           return Ok(_ks.GetKeepsByVaultId(id, userInfo));
       }
       catch (System.Exception e)
       {
           
          return BadRequest(e.Message);
       }
   }
}
}