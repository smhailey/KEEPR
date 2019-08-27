using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using keepr.Models;
using keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class KeepsController : ControllerBase
  {
    private readonly KeepsService _service;

    // GET api/values
    [HttpGet]
    public ActionResult<Keep> Get()
    {
      return Ok(_service.GetAllPublicKeeps());
    }

    [HttpGet("{id}")]
    public ActionResult<Keep> GetOneKeepById(int id)
    {
      return Ok(_service.GetOneKeepById(id));
    }
    // GET api/values/5
    [HttpGet("{userId}")]
    public ActionResult<IEnumerable<Keep>> GetAllKeepsByUserId(string userId)
    {
      userId = HttpContext.User.FindFirstValue("Id");
      return Ok(_service.GetAllKeepsByUserId(userId));
    }

    // POST api/values
    [HttpPost]
    public ActionResult<Keep> CreateKeep([FromBody]Keep newKeep)
    {
      //  keep.userId = HttpContext.User.FindFirstValue("Id");
      return Ok(_service.CreateKeep(newKeep));
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    // public void Put(int id, [FromBody] string value)
    // {
    // }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public ActionResult<bool> DeleteKeepById(int id)
    {
      return Ok(_service.DeleteKeepById(id));
    }

    public KeepsController(KeepsService service)
    {
      _service = service;
    }
  }
}
