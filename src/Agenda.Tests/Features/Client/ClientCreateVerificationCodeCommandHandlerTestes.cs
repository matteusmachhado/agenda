using Agenda.Domain.Features.Client.Commands.SendVerificationCode;
using Agenda.Shared.Enums;
using FluentAssertions;

namespace Agenda.Tests.Features.Client
{

    [Collection(nameof(CollectionClient))]
    public class ClientCreateVerificationCodeCommandHandlerTestes
    {
        private readonly ClientTestsFixture _clientTestsFixture;

        public ClientCreateVerificationCodeCommandHandlerTestes(ClientTestsFixture clientTestsFixture)
        {
            _clientTestsFixture = clientTestsFixture;
        }

        [Fact]
        public async void Client_CreateVerificationCodeNumeric_Sucesso()
        {
            // Arrange
            var command = new ClientCreateVerificationCodeCommand() { TypeCodeVerify = TypeCodeVerifyEnum.Numeric };
            var clientCreateVerificationCodeCommandaHandler = _clientTestsFixture.AutoMocker.CreateInstance<ClientCreateVerificationCodeCommandHandler>();

            // Act
            var result = await clientCreateVerificationCodeCommandaHandler.Handle(command, CancellationToken.None);

            // Assert
            result.ValidationResult.Errors.Should().HaveCount(0);
            result.Code.All(char.IsDigit).Should().BeTrue();
        }

        [Fact]
        public async void Client_CreateVerificationCodeAlphaNumeric_Sucesso()
        {
            // Arrange
            var command = new ClientCreateVerificationCodeCommand() { TypeCodeVerify = TypeCodeVerifyEnum.AlphaNumeric };
            var clientCreateVerificationCodeCommandaHandler = _clientTestsFixture.AutoMocker.CreateInstance<ClientCreateVerificationCodeCommandHandler>();

            // Act
            var result = await clientCreateVerificationCodeCommandaHandler.Handle(command, CancellationToken.None);

            // Assert
            result.ValidationResult.Errors.Should().HaveCount(0);
            result.Code.All(char.IsLetterOrDigit).Should().BeTrue();
        }
    }
}
