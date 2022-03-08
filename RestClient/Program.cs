using RestClient;
using System.Text.Json;

async Task<Stream> GetData(string url)
{
    HttpClient client = new();
    return await client.GetStreamAsync(url);
}

Console.WriteLine("Enter a number and hit Enter:");
var id = Console.ReadLine();

var people = GetData("https://swapi.dev/api/people/" + id);
var person = await JsonSerializer.DeserializeAsync<People>(await people);
var planet = GetData($"{person.homeworld}");
var home = await JsonSerializer.DeserializeAsync<People>(await planet);

Console.WriteLine($"Name: {person.name}\n" +
                $"Height: {person.height} cm\n" +
                $"Homeworld: {home.name}\n" +
                $"Climate: {home.climate}");
Console.ReadKey();