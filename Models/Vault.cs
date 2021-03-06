using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
  public class Vault
  {
    // NOTE I do not need [REQUIRED] here as MySQL will generate Id's due to the "AUTO_INCREMENT" command.
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    public string UserId { get; set; }
  }
}