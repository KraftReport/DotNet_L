using Microsoft.AspNetCore.Mvc;
using Runner.Data;
using Microsoft.EntityFrameworkCore;

namespace Runner.Controllers
{
    public class Menu : Controller
    {
        private readonly MenuContext _context;
        public Menu(MenuContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string searchString)
        {
            var dishes = from d in _context.Dish
                         select d;
            if (!string.IsNullOrEmpty(searchString))
            {
                dishes = dishes.Where(d => d.Name.Contains(searchString));
                return View(await dishes.ToListAsync());

            }
            return View(await dishes.ToListAsync());
        }

        public async Task<IActionResult> Detail(int? id)
        {
            Console.WriteLine("wow wow");
            var dish = await _context.Dish
                .Include(di => di.DishIngredients)
                .ThenInclude(i => i.Ingridient)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (dish == null)
            {
                Console.WriteLine("wow wow");
                return NotFound();
            }
            Console.WriteLine("wow wow");
            return View(dish);
        }
    }
}