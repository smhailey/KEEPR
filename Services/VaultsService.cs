using keepr.Models;
using keepr.Repositories;

namespace keepr.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _repo;

    public VaultsService(VaultsRepository repo)
    {
      _repo = repo;
    }

    public Vault CreateKeep(Vault newVault)
    {
      return _repo.CreateVault(newVault);
    }
  }
}