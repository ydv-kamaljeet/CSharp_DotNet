using System.Net.Http;

public class API
{
    public async Task FetchJsonAsync()
    {

        HttpClient _http = new HttpClient();
        try
        {
            string url = "https://jsonplaceholder.typicode.com/todos/2";
            string json = await _http.GetStringAsync(url);

            if (string.IsNullOrEmpty(json))
            {
                Console.WriteLine("No Resu;t");
            }

            Console.WriteLine(json + Environment.NewLine);
            Console.WriteLine("Status: Success");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message + Environment.NewLine);
            Console.WriteLine("Status: Failed");
        }
        finally
        {
            Console.WriteLine("Done");
        }
    }
}