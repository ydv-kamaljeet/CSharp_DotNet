using System;
using System.Collections.Generic;
using System.IO;

public class ProductImporter
{
    public ImportResult ImportProducts(string csvPath)
    {
        var result = new ImportResult();

        if (!File.Exists(csvPath))
            throw new FileNotFoundException(csvPath);

        int rowNumber = 0;

        foreach (var line in File.ReadLines(csvPath))
        {
            rowNumber++;

            // Skip header if present
            if (rowNumber == 1 && line.StartsWith("Name"))
                continue;

            try
            {
                var parts = line.Split(',');

                if (parts.Length != 3)
                    throw new Exception("Invalid column count");

                var product = new Product
                {
                    Name = parts[0],
                    Price = decimal.Parse(parts[1]),
                    Quantity = int.Parse(parts[2])
                };

                InsertProduct(product);

                result.InsertedCount++;
            }
            catch (Exception ex)
            {
                result.Errors.Add(new ImportError
                {
                    RowNumber = rowNumber,
                    Reason = ex.Message
                });
            }
        }

        return result;
    }

    private void InsertProduct(Product product)
    {
        // actual DB logic
    }
}
