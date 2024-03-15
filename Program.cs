// See https://aka.ms/new-console-template for more information


using System.Text.Json;

var data = new StreamReader("Data/PokemonList.json").BaseStream;
var pokemons =
    await JsonSerializer.DeserializeAsync<PokemonApi>(
        data,
        new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
    ) ?? throw new Exception("Failed to deserialize Pokemon list");

foreach (var pokemon in pokemons.Results)
{
    Console.WriteLine(pokemon);
}

// Console.WriteLine(pokemons.Results);
Console.ReadLine();

record PokemonApi(int Count, string Next, string Previous, Pokemon[] Results);

record Pokemon(string Name, string Url);
