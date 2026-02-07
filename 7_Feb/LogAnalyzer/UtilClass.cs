using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

public class ErrorSummary
{
    public string ErrorCode { get; set; }
    public int Count { get; set; }
}

public class LogAnalyze
{
    public List<ErrorSummary> GetTopErrors(string filePath, int topN)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException(filePath);

        if (topN <= 0)
            throw new ArgumentException("topN must be positive");

        var errorCounts = new Dictionary<string, int>();
        var regex = new Regex(@"ERR\d+", RegexOptions.Compiled);

        foreach (var line in File.ReadLines(filePath))
        {
            foreach (Match match in regex.Matches(line))
            {
                var code = match.Value;

                if (errorCounts.ContainsKey(code))
                    errorCounts[code]++;
                else
                    errorCounts[code] = 1;
            }
        }

        var topErrors = errorCounts.OrderByDescending(x => x.Value).Take(topN);
        var result = new List<ErrorSummary>();

        foreach (var item in topErrors)
        {
            result.Add(new ErrorSummary
            {
                ErrorCode = item.Key,
                Count = item.Value
            });
        }

        return result;
    }
}
