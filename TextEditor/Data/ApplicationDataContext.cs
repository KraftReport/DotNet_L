using Microsoft.EntityFrameworkCore;
using TextEditor.Models;

namespace TextEditor.Data
{
    public class ApplicationDataContext : DbContext
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options) { }

        public DbSet<Doc> Docs { get; set; }
    }
}
