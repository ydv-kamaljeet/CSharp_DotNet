class Program
{
    static void Main()
    {
        var importer = new ProductImporter();

        var result = importer.ImportProducts("products_sample.csv");

        Console.WriteLine("Inserted: " + result.InsertedCount);

        foreach (var e in result.Errors)
        {
            Console.WriteLine($"Row {e.RowNumber}: {e.Reason}");
        }
    }
}
