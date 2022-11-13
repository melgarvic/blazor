using Blazor.Starter.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Blazor.Starter.Server.Interfaces
{
    public interface IExampleDbContext
    {
        DbSet<Person> People { get; set; }
        Task<int> SaveChangesAsync(CancellationToken token = default);
        int SaveChanges();
        void Dispose();
    }
}
