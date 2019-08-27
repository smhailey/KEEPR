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

    // GET api/values
    [HttpGet]
    public ActionResult<Vault> Get()
    {
      return null;
      // STUB 
      // return Ok(_service.GetAllPublicVaults());
    }
    public VaultsController(VaultsService service)
    {
      _service = service;
    }
  }
}