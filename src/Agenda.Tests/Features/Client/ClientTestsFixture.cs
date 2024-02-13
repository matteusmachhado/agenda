using Moq.AutoMock;

namespace Agenda.Tests.Features.Client
{
    [CollectionDefinition(nameof(CollectionClient))]
    public class CollectionClient : ICollectionFixture<ClientTestsFixture> { }

    public class ClientTestsFixture : IDisposable
    {

        public ClientTestsFixture()
        {

        }

        public void Dispose()
        {

        }
    }
}
