using System;
using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace keepr.Services
{
  public class KeepsService
  {
    private readonly KeepsRepository _repo;
    public KeepsService(KeepsRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Keep> GetAllPublicKeeps()
    {
      return _repo.GetAllPublicKeeps();
    }
    public Keep GetOneKeepById(int Id)
    {
      return _repo.GetOneKeepById(Id);
    }
    [Authorize]
    public IEnumerable<Keep> GetAllKeepsByUserId(string UserId)
    {
      return _repo.GetAllKeepsByUserId(UserId);
    }
    public Keep CreateKeep(Keep newKeep)
    {
      return _repo.CreateKeep(newKeep);
    }
    public bool DeleteKeepById(int Id)
    {
      return _repo.DeleteKeepById(Id);
    }
  }
}