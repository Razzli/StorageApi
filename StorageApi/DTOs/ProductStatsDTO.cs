using System;

public class ProductStatsDTO
{
    public ProductStatsDTO(int totalProducts, int storageWorth)
    {
        TotalProducts = totalProducts;
        StorageWorth = storageWorth;
    }

    public int TotalProducts { get; set; }
	public int StorageWorth {  get; set; }
	public int AveragePrice => StorageWorth / TotalProducts;
}
