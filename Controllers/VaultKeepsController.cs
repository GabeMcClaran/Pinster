using System.Security.Claims;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
    [ApiController]
    [Route("api/[contrller]")]

    public class VaultKeepsController : ControllerBase
    {
        private readonly VaultKeepsService _vks;
        public VaultKeepsController(VaultKeepsService vks)
        {
            _vks = vks;
        }

        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<VaultKeep> GetById([FromRoute] int id)
        {
            try
            {
                string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Ok(_vks.GetById(id, userId));
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult<VaultKeep> Create([FromBody] VaultKeepsService newData)
        {
            try
            {
                _vks.Create(newData);
                return Ok("Success");
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult<string> Delete([FromBody] VaultKeep vk)
        {
            try
            {
                return Ok(_vks.Delete(vk));
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }

    }

}