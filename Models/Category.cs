using CsvConverter.Interfaces;

namespace CsvConverter.Models;

public class Category : IProperties
{
    public string Name { get; set; } = null!;
    
    public override string ToString()
    {
        return $"{Name}";
    }

    public void FillProperties(string[] data)
    {
        Name = data[1].Trim();
    }
}