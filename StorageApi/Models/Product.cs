using System;

public class Product
{
	private int _id;
	private string _name;
	private int _price;
	private string _category;
	private string _shelf;
	private int _count;
	private string _description;

    public Product()
	{

	}

    public int Id { get => _id; set => _id = value; }
    public string Name { get => _name; set => _name = value; }
    public int Price { get => _price; set => _price = value; }
    public string Category { get => _category; set => _category = value; }
    public string Shelf { get => _shelf; set => _shelf = value; }
    public int Count { get => _count; set => _count = value; }
    public string Description { get => _description; set => _description = value; }
}
