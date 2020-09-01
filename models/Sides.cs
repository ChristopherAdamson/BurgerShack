using System.ComponentModel.DataAnnotations;

namespace BurgerShack.Models
{
  public class Side
  {
    public int Id { get; set; }
    [Required]
    [MaxLength(80)]
    public string Title { get; set; }
    [Required]
    public decimal Price { get; set; }

  }
  public class ComboViewModel : Side
  {
    public string burgerName { get; set; }
    public string sideName { get; set; }
  }
}