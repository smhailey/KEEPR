using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;
    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }
    internal IEnumerable<Keep> GetAllPublicKeeps()
    {
      return _db.Query<Keep>(@"
      SELECT * FROM keeps
      ").ToList();
    }
    public Keep GetOneKeepById(int Id)
    {
      return _db.QueryFirstOrDefault<Keep>(@"
      SELECT * FROM keeps WHERE id = @Id
      ", new { Id });
    }

    // REVIEW Do I need to incorporate the following code into GetAllKeepsByUserId:
    // GetVault(string userId, int vaultId)
    public IEnumerable<Keep> GetAllKeepsByUserId(string UserId)
    {
      return _db.Query<Keep>(@"
      SELECT * FROM keeps WHERE id = @UserId
      ", new { UserId });
    }

    public Keep CreateKeep(Keep newKeep)
    {
      // FIXME Add userId to below?
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO keeps (userId, name, description) VALUES (@UseId, @Name, @Description); 
      SELECT LAST_INSERT_ID()", newKeep);
      newKeep.Id = id;
      return newKeep;
    }
    public bool DeleteKeepById(int Id)
    {
      int success = _db.Execute(@"
      DELETE FROM keeps WHERE id = @Id
      ", new { Id });
      return success > 0;
    }











    // FIXME Do I need the method below?

    // public IEnumerable<Keep> GetAllPublicKeepsById(int Id)
    // {
    //   return _db.Query<Keep>(@"
    //   SELECT * FROM keeps
    //   ").ToList();
    // }


    public string AddKeepToVault(int vaultId, int keepId)
    {
      int success = _db.Execute(@"
            INSERT INTO vaultkeeps (vaultId, keepId) 
                VALUES (@vaultId, @keepId)",
          new
          {
            vaultId,
            keepId
          });
      return success > 0 ? "Success" : "Something has gone terribly wrong";
    }
  }
}