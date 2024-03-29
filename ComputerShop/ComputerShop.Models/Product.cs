﻿namespace ComputerShop.Models;

public class Product
{
    public int ID { get; set; }

    [MaxLength(255)]
    public string Name { get; set; } = null!;

    [MaxLength(255)]
    public string Description { get; set; } = null!;
    public ProductType Type { get; set; }
    public Manufacturer Manufacturer { get; set; }
    public decimal Price { get; set; }
    public int Count { get; set; }
    public string? PathToFile { get; set; }

    public List<Characteristic> Characteristics { get; set; } = new();
}
