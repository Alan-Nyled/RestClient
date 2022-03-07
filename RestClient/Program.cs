using RestClient;
using System.Text.Json;

var people = Caller.GetData("https://swapi.dev/api/people/3");
var person = await JsonSerializer.DeserializeAsync<People>(await people);
var planet = Caller.GetData($"{person.homeworld}");
var home = await JsonSerializer.DeserializeAsync<People>(await planet);

Console.WriteLine($"Name: {person.name}\n" +
                $"Height: {person.height} cm\n" +
                $"Homeworld: {home.name}\n" +
                $"Climate: {home.climate}");