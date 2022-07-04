using Microsoft.EntityFrameworkCore;
using TrainingDemoNet6.Models;

namespace TrainingDemoNet6.Data
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {

        }

        public DbSet<CategoryModel> Categories { get; set; }
    }
}
