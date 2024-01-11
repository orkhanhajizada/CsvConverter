using CsvConverter.Interfaces;

namespace CsvConverter.Models;

public class Employee : IProperties
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;

    public  void FillProperties(string[] data)
    {
        FirstName = data[1].Trim();
        LastName = data[2].Trim();
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }
}