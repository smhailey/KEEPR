using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
  public class VaultKeep
  {
    // NOTE I do not need [REQUIRED] here as MySQL will generate Id's due to the "AUTO_INCREMENT" command.
    public int Id { get; set; }

    public int KeepId { get; set; }

    public int VaultId { get; set; }

    public string UserId { get; set; }
  }
}