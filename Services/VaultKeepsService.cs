using System.Collections.Generic;
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

    public IEnumerable<Keep> GetKeepsByVaultId(int Id, string userId)
    {
      return _repo.GetKeepsByVaultId(Id, userId);
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