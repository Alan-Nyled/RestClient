using RestClient;
using System.Text.Json;

HttpClient client = new();

var stream = client.GetStreamAsync("https://swapi.dev/api/people/1");
var result = await JsonSerializer.DeserializeAsync<People>(await stream);

Console.WriteLine($"Name: {result.name}, Height: {result.height} cm");