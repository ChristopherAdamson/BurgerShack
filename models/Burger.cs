using System.ComponentModel.DataAnnotations;

namespace BurgerShack.Models
{
  public class Burger
  {
    public int Id { get; set; }
    [Required]
    [MaxLength(80)]
    public string Title { get; set; }
    [Required]
    [MaxLength(300)]

    public string Ingredients { get; set; }
    [Required]

    public decimal Price { get; set; }

  }
}