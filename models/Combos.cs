using System.ComponentModel.DataAnnotations;

namespace BurgerShack.Models
{
  public class Combo
  {
    public int Id { get; set; }
    [Required]
    public int burgerId { get; set; }
    [Required]
    public int sideId { get; set; }

  }
}