using Moq.AutoMock;

namespace Agenda.Tests.Features.Client
{
    [CollectionDefinition(nameof(CollectionClient))]
    public class CollectionClient : ICollectionFixture<ClientTestsFixture> { }

    public class ClientTestsFixture : IDisposable
    {
        public readonly AutoMocker AutoMocker;

        public ClientTestsFixture()
        {
            AutoMocker = new AutoMocker();
        }

        public void Dispose()
        {

        }
    }
}
