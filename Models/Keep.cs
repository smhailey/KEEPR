using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
  public class Keep
  {
    // NOTE I do not need [REQUIRED] here as MySQL will generate Id's due to the "AUTO_INCREMENT" command.
    public int Id { get; set; }
    public string UserId { get; set; }

    [Required]
    [MinLength(1)]
    public string Name { get; set; }

    [Required]
    [MinLength(1)]
    public string Description { get; set; }
  }
}