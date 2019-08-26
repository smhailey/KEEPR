using System;
using System.Collections.Generic;
using System.Linq;
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
    public ActionResult<Keep> Get(int id)
    {
      // var id = HttpContext.User.FindFirstValue("Id");
      return Ok(_service.GetOneKeepById(id));
    }
    // GET api/values/5
    // FIXME Do I need the method below?
    // [HttpGet("{id}")]
    // public ActionResult<IEnumerable<Keep>> Get(int id)
    // {
    //   return Ok(_service.GetAllPublicKeepsById(id));
    // }

    // POST api/values
    [HttpPost]
    public ActionResult<Keep> Create([FromBody]Keep newKeep)
    {
      return Ok(_service.CreateKeep(newKeep));
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public ActionResult<bool> Delete(int id)
    {
      return Ok(_service.DeleteKeepById(id));
    }

    public KeepsController(KeepsService service)
    {
      _service = service;
    }
  }
}
