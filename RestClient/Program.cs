using RestClient;
using System.Text.Json;

HttpClient client = new();

var stream = client.GetStreamAsync("https://localhost:7270/api/UsdToDkk?value=5");
var result = await JsonSerializer.DeserializeAsync<Amount>(await stream);

Console.WriteLine($"{result.value} {result.currency}");