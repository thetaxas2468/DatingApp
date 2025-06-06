using System.ComponentModel.DataAnnotations.Schema;

namespace DatingAppBackend.Models
{

  [Table("Photos")]
  public class Photo
  {
    public int Id { get; set; }
    public required string Url { get; set; }
    public string? PublicId { get; set; }
    public bool IsMain { get; set; }

    public int AppUserId { get; set; }
    public AppUser AppUser { get; set; } = null!; // Non-nullable reference type, initialized later
  }
}
