using System.Collections.Generic;

public class ImportResult
{
    public int InsertedCount { get; set; }
    public List<ImportError> Errors { get; set; } = new();
}
