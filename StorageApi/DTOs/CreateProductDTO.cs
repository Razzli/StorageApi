using System;
using System.ComponentModel.DataAnnotations;

public class CreateProductDTO
{
    public CreateProductDTO(string name, int price, string category, string shelf, int count, string description)
    {
        Name = name;
        Price = price;
        Category = category;
        Shelf = shelf;
        Count = count;
        Description = description;
    }

    [Required(ErrorMessage = "Produktnamn är ett krav!")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Namn måste vara mellan 3 och 50 tecken!")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Pris är ett krav!")]
    [Range(0, int.MaxValue, ErrorMessage = "Pris kan inte vara negativt!")]
    public int Price { get; set; }
    [Required(ErrorMessage = "Kategori är ett krav!")]
    public string Category { get; set; }
    [Required(ErrorMessage = "Hylla är ett krav!")]
    public string Shelf { get; set; }
    [Required(ErrorMessage = "Antal är ett krav!")]
    [Range(0, int.MaxValue, ErrorMessage = "Antal kan inte vara negativt!")]
    public int Count { get; set; }
    [MaxLength(255, ErrorMessage = "Beskrivning måste vara mindre än 256 tecken!")]
    public string Description { get; set; }

}
