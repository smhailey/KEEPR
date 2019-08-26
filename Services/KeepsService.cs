using System;
using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
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




    public Keep CreateKeep(Keep newKeep)
    {
      return _repo.CreateKeep(newKeep);
    }



    public bool DeleteKeepById(int Id)
    {
      return _repo.DeleteKeepById(Id);
    }
    public Keep GetOneKeepById(int Id)
    {
      return _repo.GetOneKeepById(Id);
    }
    public IEnumerable<Keep> GetAllPublicKeeps()
    {
      return _repo.GetAllPublicKeeps();
    }

    // FIXME Do I need the method below?
    // public IEnumerable<Keep> GetAllPublicKeepsById(int Id)
    // {
    //   return _repo.GetAllPublicKeepsById(Id);
    // }
  }

}