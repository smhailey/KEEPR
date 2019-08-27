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

    public VaultKeep GetOneVaultById(int Id)
    {
      return _db.QueryFirstOrDefault<VaultKeep>(@"
      SELECT * FROM vaultkeeps WHERE id = @Id
      ", new { Id });
    }



  }
}