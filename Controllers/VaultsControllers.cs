using System.Collections.Generic;
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
  public class VaultsController : ControllerBase
  {
    private readonly VaultsService _service;

    // GET api/5
    [HttpGet("{id}")]
    public ActionResult<Vault> GetOneVaultById(int id)
    {
      return Ok(_service.GetOneVaultById(id));
    }

    // GET api/vaults/297cf71d-2b5c-4ecc-b345-82ae7b4a2202
    [HttpGet]
    public ActionResult<IEnumerable<Vault>> GetAllVaultsByUserId(string userId)
    {
      userId = HttpContext.User.FindFirstValue("Id");
      return Ok(_service.GetAllVaultsByUserId(userId));
    }

    // POST api/vaults
    [HttpPost]
    public ActionResult<Vault> CreateVault([FromBody]Vault newVault)
    {
      newVault.UserId = HttpContext.User.FindFirstValue("Id");
      return Ok(_service.CreateVault(newVault));
    }

    // DELETE api/vaults/5
    [HttpDelete("{id}")]
    public ActionResult<bool> DeleteVaultById(int id)
    {
      return Ok(_service.DeleteVaultById(id));
    }

    public VaultsController(VaultsService service)
    {
      _service = service;
    }
  }
}