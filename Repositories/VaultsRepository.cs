using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class VaultsRepository
  {
    private readonly IDbConnection _db;
    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }

    public Vault GetOneVaultById(int Id)
    {
      return _db.QueryFirstOrDefault<Vault>(@"
      SELECT * FROM vaults WHERE id = @Id
      ", new { Id });
    }

    // GetVault(string userId, int vaultId)

    public IEnumerable<Vault> GetAllVaultsByUserId(string UserId)
    {
      return _db.Query<Vault>(@"
      SELECT * FROM vaults WHERE userId = @UserId
      ", new { UserId });
    }

    public Vault CreateVault(Vault newVault)
    {
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO vaults (userId, name, description) VALUES (@UserId, @Name, @Description); 
      SELECT LAST_INSERT_ID()", newVault);
      newVault.Id = id;
      return newVault;
    }

    public bool DeleteVaultById(int Id)
    {
      int success = _db.Execute(@"
      DELETE FROM vaults WHERE id = @Id
      ", new { Id });
      return success > 0;
    }
  }
}