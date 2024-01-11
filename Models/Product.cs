using CsvConverter.Interfaces;

namespace CsvConverter.Models;


public class Product : IProperties
{
    public string ProductName { get; set; } = null!;
    public string Description { get; set; } = null!;

    public void FillProperties(string[] data)
    {
        ProductName = data[1].Trim();
        Description = data[2].Trim();
    }

    public override string ToString()
    {
        return $"{ProductName} - {Description}";
    }
}