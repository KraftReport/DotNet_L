using Pokemon.Data;
using Pokemon.Interfaces;
using Pokemon.Models;

namespace Pokemon.Repositories
{
    public class OwnerRepository : IOwnerRepositroy
    {
        private readonly DataContext _context;

        public OwnerRepository(DataContext context) 
        {
            _context = context;
        }

        public bool CreateOwner(Owner owner)
        {
            _context.Add(owner);
            return save();
        }

        public bool DeleteOwner(Owner owner)
        {
            _context.Remove(owner);
            return save();
        }

        public Owner GetOwner(int id)
        {
            return _context.Owners.Where(o => o.Id == id).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnersFromAPokemon(int PokeId)
        {
            return _context.PokemonOwners.Where(po => po.PokemonId == PokeId).Select(o => o.owner).ToList();
        }

        public ICollection<Owner> GetOwners()
        {
            return _context.Owners.ToList();
        }

        public ICollection<global::Pokemon.Models.Pokemon> GetPokemonsFormAOwner(int Id)
        {
            return _context.PokemonOwners.Where(po => po.OwnerId == Id).Select(o => o.pokemon).ToList();
        }

        public bool OwnerExists(int Id)
        {
            return _context.Owners.Any(o => o.Id == Id);
        }

        public bool UpdateOwner(Owner owner)
        {
            _context.Update(owner);
            return save();
        }

        public bool save()
        {
            var save = _context.SaveChanges();
            return save > 0 ? true : false;
        }

         
    }
}
