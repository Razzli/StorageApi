using Microsoft.Identity.Client.NativeInterop;
using System;
using System.Security.Cryptography;
using System.Xml.Linq;

public class ProductDTO
{
    public ProductDTO(int id, string name, int price, string category, string shelf, int count, string description)
    {
        Id = id;
        Name = name;
        Price = price;
        Category = category;
        Shelf = shelf;
        Count = count;
        Description = description;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public string Category { get; set; }
    public string Shelf { get; set; }
    public int Count { get; set; }
    public string Description { get; set; }
    public int InventoryValue => Price * Count;
}
