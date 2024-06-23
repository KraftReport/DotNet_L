using Pokemon.Models;

namespace Pokemon.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int id);
        ICollection<global::Pokemon.Models.Pokemon> getPokemonsByCategory(int categoryId);
        bool CategoryExists(int categoryId);
        bool CreateCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(Category category);
        bool save();

    }
}
