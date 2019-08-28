using keepr.Models;
using keepr.Repositories;

namespace keepr.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _repo;

    public VaultKeepsService(VaultKeepsRepository repo)
    {
      _repo = repo;
    }

    public VaultKeep GetOneVaultKeepById(int Id)
    {
      return _repo.GetOneVaultKeepById(Id);
    }

    public VaultKeep CreateVaultKeep(VaultKeep newVaultKeep)
    {
      return _repo.CreateVaultKeep(newVaultKeep);
    }

    public VaultKeep DeleteVaultKeep(VaultKeep oldVaultKeep)
    {
      return _repo.DeleteVaultKeep(oldVaultKeep);
    }
  }
}