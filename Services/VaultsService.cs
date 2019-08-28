using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace keepr.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _repo;

    public VaultsService(VaultsRepository repo)
    {
      _repo = repo;
    }

    public Vault GetOneVaultById(int Id)
    {
      return _repo.GetOneVaultById(Id);
    }

    [Authorize]
    public IEnumerable<Vault> GetAllVaultsByUserId(string UserId)
    {
      return _repo.GetAllVaultsByUserId(UserId);
    }

    public Vault CreateVault(Vault newVault)
    {
      return _repo.CreateVault(newVault);
    }

    public bool DeleteVaultById(int Id)
    {
      return _repo.DeleteVaultById(Id);
    }
  }
}