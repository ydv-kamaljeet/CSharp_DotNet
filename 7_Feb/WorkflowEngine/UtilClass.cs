using System;
using System.Collections.Generic;

public class LoanWorkflowEngine
{
    private Dictionary<string, LoanApplication> apps = new();

    public void AddApplication(string id)
    {
        apps[id] = new LoanApplication
        {
            Id = id,
            CurrentState = LoanState.Draft
        };
    }

    public void ChangeState(string appId, LoanState newState)
    {
        if (!apps.ContainsKey(appId))
            throw new Exception("Application not found");

        var app = apps[appId];

        if (!IsValidTransition(app.CurrentState, newState))
            throw new Exception("Invalid state transition");

        app.History.Add(
            $"{DateTime.Now}: {app.CurrentState} -> {newState}");

        app.CurrentState = newState;
    }

    public bool IsValidTransition(LoanState current, LoanState next)
{
    if (current == LoanState.Draft && next == LoanState.Submitted)
        return true;

    if (current == LoanState.Submitted && next == LoanState.InReview)
        return true;

    if (current == LoanState.InReview &&
        (next == LoanState.Approved || next == LoanState.Rejected))
        return true;

    if (current == LoanState.Approved && next == LoanState.Disbursed)
        return true;

    return false;
}

}
