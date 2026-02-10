using System.Net.Http;
using System.Threading.Tasks;

public class ApiClient
{
    private readonly HttpClient _http = new HttpClient();

    public async Task<string> GetHomePageHtmlAsync()
    {
        // Real asynchronous I/O
        string url = "https://google.com";
        return await _http.GetStringAsync(url);
    }


    public async Task<string> FetchJsonAsync(){
        string url = "https://jsonplaceholder.typicode.com/todos/1";
        return await _http.GetStringAsync(url); // ✅ real async I/O
    }    
}


/////////////////////////////////////////////////////////




