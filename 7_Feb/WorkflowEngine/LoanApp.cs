using System;
using System.Collections.Generic;

public class LoanApplication
{
    public string Id { get; set; }
    public LoanState CurrentState { get; set; }
    public List<string> History { get; set; } = new();
}
