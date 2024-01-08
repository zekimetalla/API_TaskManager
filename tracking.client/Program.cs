using System.Net.Http.Headers;
using System.Net.Http.Json;
using tracking.client;

HttpClient client = new ();
client.BaseAddress = new Uri("https://localhost:7220");
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

HttpResponseMessage response = await client.GetAsync("api/task");
response.EnsureSuccessStatusCode();

if (response.IsSuccessStatusCode)
{
    var tasks = await response.Content.ReadFromJsonAsync<IEnumerable<TaskDTO>>();
    if (tasks.Any())
    {
        foreach (var task in tasks)
        {
            Console.WriteLine(task.Title);
        }
    }
    else
    {
        Console.WriteLine("No data to display");
    }

}
else
{
    Console.WriteLine("Can't fetch data...");
}

Console.ReadLine();