using CsvConverter.Interfaces;

namespace CsvConverter.Models;


public class Order : IProperties
{
    public int OrderId { get; set; }
    public string CustomerName { get; set; } = null!;

    public void FillProperties(string[] data)
    {
        OrderId = int.Parse(data[1].Trim());
        CustomerName = data[2].Trim();
    }

    public override string ToString()
    {
        return $"{OrderId} - {CustomerName}";
    }
}