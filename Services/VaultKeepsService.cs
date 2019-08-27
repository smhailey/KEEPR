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



  }
}