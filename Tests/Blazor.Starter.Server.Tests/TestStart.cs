using Blazor.Starter.Server.Tests.Fixtures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Starter.Server.Tests
{

    [CollectionDefinition("ExampleTestCollection")]
    public class TestStart : ICollectionFixture<ExampleTestDbFixture> { }

}
