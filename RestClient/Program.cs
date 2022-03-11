using RestClient;
using System.Text.Json;

async Task<Stream?> GetData(string url)
{
    HttpClient client = new();
    try
    {
        return await client.GetStreamAsync(url);
    }
    catch (Exception)
    {
        client.Dispose();
        return Stream.Null;
    }
}

async Task WriteResult(Stream people)
{
    var person = await JsonSerializer.DeserializeAsync<People>(people);
    var planet = GetData($"{person.homeworld}");
    var home = await JsonSerializer.DeserializeAsync<People>(await planet);

    Console.WriteLine($"\nName: {person.name}\n" +
                    $"Height: {person.height} cm\n" +
                    $"Homeworld: {home.name}\n" +
                    $"Climate: {home.climate}\n");
}

string input = "";

while (input != "x")
{
    Console.WriteLine("Enter a number and hit Enter (or x to exit)");
    input = Console.ReadLine();
    if (input == "x") { break; }
    if(input == "") { continue; }

    var people = await GetData("https://swapi.dev/api/people/" + input);
    if (people != Stream.Null)
    {
        await WriteResult(people);
    }
    else
    {
        Console.WriteLine("\n{0} doesn't exist, try again!\n", input);
    }
}
