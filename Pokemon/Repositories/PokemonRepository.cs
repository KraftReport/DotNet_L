using Pokemon.Data;
using Pokemon.Dto;
using Pokemon.Interfaces;
using Pokemon.Models;

namespace Pokemon.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {

        private readonly DataContext _context;

        public PokemonRepository(DataContext context)
        {
            _context = context;
        }
        public bool  CreatePokemon(int ownerId, int categoryId, Models.Pokemon pokemon)
        {
            var pokemonOwnerEntity = _context.Owners.Where(a => a.Id == ownerId).FirstOrDefault();
            var category = _context.Categories.Where(a => a.Id == categoryId).FirstOrDefault();
            var pokemonOwner = new PokemonOwner()
            {
                owner = pokemonOwnerEntity,
                pokemon = pokemon
            };
            _context.Add(pokemonOwner);
            var pokemonCategory = new PokemonCategory()
            {
                Category = category,
                Pokemon = pokemon
            };
            _context.Add(pokemonCategory);
            _context.Add(pokemon);
            return Save();
        }

        bool IPokemonRepository.DeletePokemon(Models.Pokemon pokemon)
        {
            _context.Remove(pokemon);
            return Save();
        }

        Models.Pokemon IPokemonRepository.GetPokemon(int id)
        {
            return _context.Pokemons.Where(p => p.Id == id).FirstOrDefault();
        }

        Models.Pokemon IPokemonRepository.GetPokemon(string name)
        {
            return _context.Pokemons.Where(p => p.Name == name).FirstOrDefault();
        }

        decimal IPokemonRepository.GetPokemonRating(int pokeId)
        {
            var review = _context.Reviews.Where(p => p.Pokemon.Id == pokeId);

            if (review.Count() <= 0)
                return 0;

            return ((decimal)review.Sum(r => r.Rating) / review.Count());
        }

        public ICollection<Models.Pokemon> GetPokemons()
        {
            return _context.Pokemons.OrderBy(p => p.Id).ToList();
        }

        public global::Pokemon.Models.Pokemon GetPokemonTrimToUpper(PokemonDto pokemonDto)
        {
            return GetPokemons().Where(c => c.Name.Trim().ToUpper() == pokemonDto.Name.TrimEnd().ToUpper()).FirstOrDefault();
        }

        bool IPokemonRepository.PokemonExists(int pokeId)
        {
            return _context.Pokemons.Any(p => p.Id == pokeId);
        }

        public bool  Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        bool IPokemonRepository.UpdatePokemon(int ownerId, int categoryId, Models.Pokemon pokemon)
        {
            _context.Update(pokemon);
            return Save();
        }
    }
}
