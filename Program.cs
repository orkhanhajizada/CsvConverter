namespace CsvConverter;

internal static class Program
{
    private static void Main()
    {
        // Get CSV file path from user
        Console.WriteLine("Please enter CSV file path");
        var csvFilePath = Console.ReadLine() ?? throw new InvalidOperationException();

        // Dictionary to store objects
        Dictionary<string, dynamic> objectLists = new Dictionary<string, dynamic>();

        // Read CSV file and create objects
        ReadCsvAndCreateObjects(csvFilePath, objectLists);

        // Print objects
        PrintObjects(objectLists);
    }

    private static void ReadCsvAndCreateObjects(string filePath, Dictionary<string, dynamic> objectLists)
    {
        try
        {
            var file = File.ReadAllLines(filePath);
            
            if(file == null)
                throw new FileNotFoundException("File nt found");
            
            if (file.Length == 0)
                throw new InvalidOperationException("File is empty");
            
            // Read all lines from CSV file
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                // Split line by comma
                string[] data = line.Split(',');

                // Get object name
                string objectName = data[0].Trim();

                // Create object
                dynamic obj = CreateObject(objectName);

                // Fill object properties
                obj.FillProperties(data);

                // Add object to list
                AddObjectToList(objectLists, objectName, obj);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Hata: {ex.Message}");
        }
    }

    private static dynamic CreateObject(string createObject)
    {
        // Create object from string
        var fullTypeName = $"CsvConverter.Models.{createObject}";
        Type objectType = Type.GetType(fullTypeName) ?? throw new InvalidOperationException();
        dynamic obj = Activator.CreateInstance(objectType) ?? throw new InvalidOperationException();
        return obj;
    }

    private static void AddObjectToList(Dictionary<string, dynamic> objectLists, string objectName, dynamic obj)
    {
        // Add object to list
        if (!objectLists.TryGetValue(objectName, out dynamic? value))
        {
            value = new List<dynamic>();
            objectLists[objectName] = value;
        }

        value.Add(obj);
    }

    private static void PrintObjects(Dictionary<string, dynamic> objectLists)
    {
        // Print objects
        foreach (var obje in objectLists)
        {
            Console.WriteLine($"{obje.Key} List:");

            foreach (var obj in obje.Value)
            {
                Console.WriteLine(obj.ToString());
            }

            Console.WriteLine();
        }
    }
}