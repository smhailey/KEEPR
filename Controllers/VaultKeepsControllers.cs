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

    // GET api/5
    [HttpGet("{id}")]
    public ActionResult<VaultKeep> GetOneVaultKeepById(int id)
    {
      return Ok(_service.GetOneVaultKeepById(id));
    }

  }
}