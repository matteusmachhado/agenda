using Agenda.Domain.Features.Client.Commands.CreateVerificationCode;
using Agenda.Domain.Features.Client.Commands.SendVerificationCode;
using Agenda.Domain.Interfaces;
using Agenda.Shared.Utils;
using FluentAssertions;
using MediatR;
using Moq;
using Moq.AutoMock;

namespace Agenda.Tests.Features.Client
{
    [Collection(nameof(CollectionClient))]
    public class ClientSendVerificationCodeCommandHandlerTests
    {
        private readonly ClientTestsFixture _clientTestsFixture;

        public ClientSendVerificationCodeCommandHandlerTests(ClientTestsFixture clientTestsFixture)
        {
            _clientTestsFixture = clientTestsFixture;
        }

        [Theory]
        [InlineData("+55 (71) 91234-5678")]
        [InlineData("55 (61) 98765-4321")]
        [InlineData("(11) 91234-5678")]
        [InlineData("21 98765-4321")]
        [InlineData("(31) 912345678")]
        [InlineData("31912345678")]
        public async void Client_SendVerificationCodeNumeric_Sucesso(string phoneNumber)
        {
            // Arrange
            var command = new ClientSendVerificationCodeCommand() { PhoneNumber = phoneNumber };
            var autoMocker = new AutoMocker();
            var clientSendVerificationCodeCommandHandler = autoMocker.CreateInstance<ClientSendVerificationCodeCommandHandler>();
            autoMocker.GetMock<IMediator>().Setup(c => c.Send(It.IsAny<ClientCreateVerificationCodeCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ClientCreateVerificationCodeResponse(RandomUtil.Numeric(5)));

            // Act
            var result = await clientSendVerificationCodeCommandHandler.Handle(command, CancellationToken.None);

            // Assert
            result.Errors.Should().HaveCount(0);
            autoMocker.GetMock<ITwilioService>().Verify(r => r.SendVerificationCode(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
    }
}
