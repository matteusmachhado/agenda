using Agenda.Domain.Features.Client.Commands.SendVerificationCode;
using Agenda.Shared.Enums;
using FluentAssertions;
using Moq.AutoMock;

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
            var autoMocker = new AutoMocker();
            var command = new ClientCreateVerificationCodeCommand() { TypeVerificarionCode = TypeVerificarionCodeEnum.Numeric };
            var clientCreateVerificationCodeCommandaHandler = autoMocker.CreateInstance<ClientCreateVerificationCodeCommandHandler>();

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
            var autoMocker = new AutoMocker();
            var command = new ClientCreateVerificationCodeCommand() { TypeVerificarionCode = TypeVerificarionCodeEnum.AlphaNumeric };
            var clientCreateVerificationCodeCommandaHandler = autoMocker.CreateInstance<ClientCreateVerificationCodeCommandHandler>();

            // Act
            var result = await clientCreateVerificationCodeCommandaHandler.Handle(command, CancellationToken.None);

            // Assert
            result.ValidationResult.Errors.Should().HaveCount(0);
            result.Code.All(char.IsLetterOrDigit).Should().BeTrue();
        }
    }
}
