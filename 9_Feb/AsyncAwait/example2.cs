using System;
using System.Threading.Tasks;

class Example
{
    public async Task Example2()
    {
        Console.WriteLine("Start");


        var saveTask = SaveAsync();

        Console.WriteLine("Doing other work...");

        await saveTask;

        Console.WriteLine("Finished");
    }

    public async Task SaveAsync()
    {
        await Task.Delay(5000);
        Console.WriteLine("Saved!");
    }
}

// SaveAsync is declared async so it can perform non-blocking work
// Calling SaveAsync() starts the task immediately.
// It does NOT necessarily run on another thread,
// but it allows Example2 method to continue execution without blocking.


// await saveTask pauses Example2 method execution logically
// until SaveAsync completes, but it does NOT block the thread.
// After completion, execution resumes from the next line.