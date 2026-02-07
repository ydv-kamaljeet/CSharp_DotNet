class Program
{
    static void Main()
    {
        var engine = new LoanWorkflowEngine();

        engine.AddApplication("APP1");

        engine.ChangeState("APP1", LoanState.Submitted);
        engine.ChangeState("APP1", LoanState.InReview);
        engine.ChangeState("APP1", LoanState.Approved);
        engine.ChangeState("APP1", LoanState.Disbursed);

        Console.WriteLine("Workflow completed.");
    }
}
