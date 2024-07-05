using Pokemon.Data;
using Pokemon.Interfaces;
using Pokemon.Models;

namespace Pokemon.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public bool save()
        {
            var save = _context.SaveChanges();
            return save > 0 ? true : false;
        }

        public bool CategoryExists(int Id)
        {
            return _context.Categories.Any(c => c.Id == Id);
        }

        public bool CreateCategory(Category category)
        {
            _context.Add(category);
            return save();
        }

        public bool DeleteCategory(Category category)
        {
            _context.Remove(category);
            return save();
        }

        public Category GetCategory(int Id)
        {
            return _context.Categories.Where(c => c.Id == Id).FirstOrDefault();
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public ICollection<global::Pokemon.Models.Pokemon> getPokemonsByCategory(int Id)
        {
            return _context.PokemonCategories.Where(c => c.CategoryId == Id).Select(p => p.Pokemon).ToList();
        }

        public bool UpdateCategory(Category category)
        {
            _context.Update(category);
            return save();
        }

        
    }
}
