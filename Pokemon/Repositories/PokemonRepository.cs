using Pokemon.Data;
using Pokemon.Interfaces;

namespace Pokemon.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {

        private readonly DataContext _context;

        public PokemonRepository(DataContext context)
        {
            _context = context;
        }
        bool IPokemonRepository.CreatePokemon(int ownerId, int categoryId, Models.Pokemon pokemon)
        {
            throw new NotImplementedException();
        }

        bool IPokemonRepository.DeletePokemon(Models.Pokemon pokemon)
        {
            throw new NotImplementedException();
        }

        Models.Pokemon IPokemonRepository.GetPokemon(int id)
        {
            throw new NotImplementedException();
        }

        Models.Pokemon IPokemonRepository.GetPokemon(string name)
        {
            throw new NotImplementedException();
        }

        decimal IPokemonRepository.GetPokemonRating(int pokeId)
        {
            throw new NotImplementedException();
        }

        ICollection<Models.Pokemon> IPokemonRepository.GetPokemons()
        {
            return _context.Pokemons.OrderBy(p => p.Id).ToList();
        }

        bool IPokemonRepository.PokemonExists(int pokeId)
        {
            throw new NotImplementedException();
        }

        bool IPokemonRepository.Save()
        {
            throw new NotImplementedException();
        }

        bool IPokemonRepository.UpdatePokemon(int ownerId, int categoryId, Models.Pokemon pokemon)
        {
            throw new NotImplementedException();
        }
    }
}
