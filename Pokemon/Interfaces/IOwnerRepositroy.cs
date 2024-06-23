using Pokemon.Models;

namespace Pokemon.Interfaces
{
    public interface IOwnerRepositroy
    {
        ICollection<Owner> GetOwners();
        Owner GetOwner(int ownerId);
        ICollection<Owner> GetOwnersFromAPokemon(int pokemonId);
        ICollection<global::Pokemon.Models.Pokemon> GetPokemonsFormAOwner(int ownerId);
        bool OwnerExists(int ownerId);
        bool CreateOwner(Owner owner);
        bool UpdateOwner(Owner owner);
        bool DeleteOwner(Owner owner);
        bool save();
    }
}
