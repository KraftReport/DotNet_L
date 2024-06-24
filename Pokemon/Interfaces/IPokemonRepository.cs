using Pokemon.Dto;

namespace Pokemon.Interfaces
{
    public interface IPokemonRepository
    {
        ICollection<global::Pokemon.Models.Pokemon> GetPokemons();
        global::Pokemon.Models.Pokemon GetPokemon(int id);
        global::Pokemon.Models.Pokemon GetPokemon(string name);
        global::Pokemon.Models.Pokemon GetPokemonTrimToUpper(PokemonDto pokemonCreate); 
        decimal GetPokemonRating(int pokeId);
        bool PokemonExists(int pokeId);
        bool CreatePokemon(int ownerId, int categoryId, global::Pokemon.Models.Pokemon pokemon);
        bool UpdatePokemon(int ownerId, int categoryId, global::Pokemon.Models.Pokemon pokemon);
        bool DeletePokemon(global::Pokemon.Models.Pokemon pokemon);
        bool Save();
    }
}
