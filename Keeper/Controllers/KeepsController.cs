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
    public class KeepsController : ControllerBase
    {
        private readonly KeepsService _ks;
        public KeepsController(KeepsService ks)
        {
            _ks = ks;
        }

        [HttpGet]
        public ActionResult<List<Keep>> GetAll()
        {
            try
            {
             List<Keep> Keeps = _ks.GetAll();
             return Ok(Keeps);  
            }
            catch (System.Exception e)
            {
                
              return BadRequest(e.Message);
            }
        }


        [HttpGet("{id}")]
        public ActionResult<Keep> GetOne(int id)
        {
            try
            {
                Keep keep = _ks.GetOne(id);
                return Ok(keep);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Keep>> Create([FromBody] Keep keep)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                keep.CreatorId = userInfo.Id;
                Keep newKeep = _ks.Create(keep);
                newKeep.CreatorId = userInfo.Id;
                return Ok(newKeep);

            }
            catch (System.Exception e)
            {
                
                return BadRequest(e.Message);
            }
        }
    }
}