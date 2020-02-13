using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Keepr.Controllers
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
        public ActionResult<IEnumerable<Keep>> Get()
        {
            try
            {
                return Ok(_ks.Get());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id}")]
        // [Authorize]
        public ActionResult<Keep> Get(int id)
        {
            try
            {
                return Ok(_ks.GetById(id));
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        [Authorize]
        public ActionResult<Keep> Post([FromBody] Keep newKeep)
        {
            try
            {
                var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                newKeep.UserId = userId;
                return Ok(_ks.Create(newKeep));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize]

        public ActionResult<Keep> Edit([FromBody] Keep keep)
        {
            try
            {
                string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

                keep.UserId = userId;
                return Ok(_ks.Edit(keep));
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]

        public ActionResult<String> Delete(int id)
        {
            try
            {
                return Ok(_ks.Delete(id));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


    }
}