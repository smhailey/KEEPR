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
    public Vault CreateVault(Vault newVault)
    {
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO vaults (name, description) VALUES (@Name, @Description); 
      SELECT LAST_INSERT_ID()", newVault);
      newVault.Id = id;
      return newVault;
    }
  }
}
// GetVault(string userId, int vaultId)