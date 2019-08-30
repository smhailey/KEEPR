using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;
    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    // USE THIS LINE FOR GET KEEPS BY VAULTID
    // SELECT * FROM vaultkeeps vk
    // INNER JOIN keeps k ON k.id = vk.keepId
    // WHERE (vaultId = @vaultId AND vk.userId = @userId)
    public IEnumerable<Keep> GetKeepsByVaultId(int vaultId, string userId)
    {
      return _db.Query<Keep>(@"
      SELECT * FROM vaultkeeps vk
      INNER JOIN keeps k ON k.id = vk.keepId
      WHERE (vaultId = @vaultId AND vk.userId = @userId)
      ", new { vaultId, userId });
    }

    public VaultKeep CreateVaultKeep(VaultKeep newVaultKeep)
    {
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO vaultkeeps (userId, keepId, vaultId) VALUES (@UserId, @KeepId, @VaultId); 
      SELECT LAST_INSERT_ID()", newVaultKeep);
      newVaultKeep.Id = id;
      return newVaultKeep;
    }

    public VaultKeep DeleteVaultKeep(VaultKeep oldVaultKeep)
    {
      var id = _db.Execute("DELETE FROM vaultkeeps WHERE vaultId = @VaultId AND keepId = @KeepId AND userId = @UserId", oldVaultKeep);
      oldVaultKeep.Id = id;
      return oldVaultKeep;
    }
  }
}