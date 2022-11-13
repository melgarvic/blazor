using Blazor.Starter.Server.Interfaces;
using Blazor.Starter.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Blazor.Starter.Server.Tests.Fixtures
{
    public class ExampleTestDbFixture : IDisposable
    {
            public readonly IExampleDbContext _db;
            public readonly IServiceProvider _serviceProvider;

            public ExampleTestDbFixture()
            {
                // setup DI
                var testDI = new ServiceCollection();

                testDI.AddDbContext<IExampleDbContext, ExampleDbContext>(opt => opt.UseInMemoryDatabase($"ExampleDB-TEST-{Guid.NewGuid():D}"));
                _serviceProvider = testDI.BuildServiceProvider();

                var scope = _serviceProvider.CreateScope();

                _db = scope.ServiceProvider.GetRequiredService<IExampleDbContext>();
            }

            public void Dispose()
            {
                _db?.Dispose();
            }
        }
    }
}
