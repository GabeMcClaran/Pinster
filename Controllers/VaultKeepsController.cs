using System;
using System.Collections.Generic;
using System.Security.Claims;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class VaultKeepsController : ControllerBase
    {
        private readonly VaultKeepsService _vks;
        public VaultKeepsController(VaultKeepsService vks)
        {
            _vks = vks;
        }
        // get all keeps by VaultKeep
        [HttpGet("{id}/keeps")]
        // [Authorize]
        public ActionResult<IEnumerable<Keep>> GetKeepsByVault(int id)
        {
            try
            {
                string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Ok(_vks.GetKeepsByVault(id, userId));
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        //Creates VaultKeep
        [HttpPost]
        [Authorize]
        public ActionResult<VaultKeep> Create([FromBody] VaultKeep newData)
        {
            try
            {
                string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                newData.UserId = userId;
                var payload = _vks.Create(newData);

                return Ok(payload);
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{vaultId}/keeps/{keepId}")]
        [Authorize]
        public ActionResult<string> Delete(int vaultId, int keepId)
        {
            try
            {
                string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Ok(_vks.Delete(vaultId, keepId, userId));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }

}