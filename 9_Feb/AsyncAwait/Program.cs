using System;
using System.Threading.Tasks;

class Program
{
    // static async Task Main()
    // {
    //     var task = SaveAsync();                // Task (no return)
    //     int total = await GetTotalAsync(); // Task<int> (returns value)
    //     Console.WriteLine(total);
    //     await task; //make sure this task execution completion before exit of main function
    // }

    // static async Task SaveAsync()
    // {
    //     await Task.Delay(30000); // pretend we saved to DB
    //     Console.WriteLine("Saved!");
    // }

    // static async Task<int> GetTotalAsync()
    // {
    //     await Task.Delay(300); // pretend we calculated
    //     return 42;
    // }

    public static async Task Main()
    {
        var client = new ApiClient();

        Console.WriteLine("Starting API calls...");

        // Start both async calls concurrently
        Task<string> htmlTask = client.GetHomePageHtmlAsync();
        Task<string> jsonTask = client.FetchJsonAsync();

        // Wait for both to complete
        await Task.WhenAll(htmlTask, jsonTask); //wait for both task to complete without blocking the thread

        Console.WriteLine("\nGoogle HTML length: " + htmlTask.Result.Length);
        Console.WriteLine("JSON Response: " + jsonTask.Result);

        Console.WriteLine("\nAll tasks completed.");


        API api = new API();
        await api.FetchJsonAsync();
    }

}


// Main is an async entry method coordinating asynchronous tasks.
// Calling SaveAsync() starts that task immediately without blocking.
// Then GetTotalAsync() is awaited, allowing both tasks to run concurrently.
// Finally, await task ensures SaveAsync completes before Main exits,
// while still avoiding thread blocking.
//where we declare 2 tasks/Async methods which will run parallelly without blocking the Main method thread. await task; will make sure that saveASync task is completed before exiting the main funciton
