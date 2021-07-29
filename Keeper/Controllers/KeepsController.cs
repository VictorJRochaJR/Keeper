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


        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<Keep>> Update(int id, [FromBody] Keep k)
        {
            try {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                k.Id = id;
                Keep newKeep = _ks.Update(k, userInfo.Id);
                newKeep.Creator = userInfo;
                return Ok(newKeep);
            }
            catch (System.Exception e)
        {
        return BadRequest(e.Message);
    }
        }


        [HttpGet("{id}/increaseviews")]
        public async Task<ActionResult<Keep>> UpdateViews(int id)
        {
            try {
                 Keep newKeep = _ks.IncreaseView(id);
                return Ok();
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
                _ks.Delete(id, userInfo.Id);
                return Ok("Succesfully Removed");
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
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
                var k = _ks.Create(keep);
                keep.Creator = userInfo;
                 return Ok(k);

            }
            catch (System.Exception e)
            {
                
                return BadRequest(e.Message);
            }
        }
    }
}