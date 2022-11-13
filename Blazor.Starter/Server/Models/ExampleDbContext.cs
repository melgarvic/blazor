using Blazor.Starter.Server.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blazor.Starter.Server.Models
{
    public class ExampleDbContext : DbContext, IExampleDbContext
    {
        public DbSet<Person> People { get; set; }
        public ExampleDbContext() { }
        public ExampleDbContext(DbContextOptions<ExampleDbContext> options) : base(options) { }
    }
}
