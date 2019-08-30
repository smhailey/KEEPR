using System;
using System.Security.Claims;
using keepr.Models;
using keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsService _service;

    // GET api/vaultkeeps/5
    [HttpGet("{id}")]
    public ActionResult<VaultKeep> GetKeepsByVaultId(int id)
    {
      return Ok(_service.GetKeepsByVaultId(id));
    }

    // POST api/vaultkeeps
    [HttpPost]
    public ActionResult<VaultKeep> CreateVaultKeep([FromBody]VaultKeep newVaultKeep)
    {
      newVaultKeep.UserId = HttpContext.User.FindFirstValue("Id");
      return Ok(_service.CreateVaultKeep(newVaultKeep));
    }

    // NOTE This put method is actually a delete method
    // PUT api/vaultkeeps/
    [HttpPut]
    public ActionResult<VaultKeep> Put([FromBody] VaultKeep oldVaultKeep)
    {
      try
      {
        oldVaultKeep.UserId = HttpContext.User.FindFirstValue("Id");
        _service.DeleteVaultKeep(oldVaultKeep);
        return Ok("Delete successful");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    public VaultKeepsController(VaultKeepsService service)
    {
      _service = service;
    }
  }
}