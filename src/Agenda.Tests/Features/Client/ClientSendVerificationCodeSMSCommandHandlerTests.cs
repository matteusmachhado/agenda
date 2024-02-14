using Agenda.Domain.Features.Client.Commands.SendVerificationCodeSMS;
using Agenda.Domain.Interfaces;
using Agenda.Shared.Enums;
using Agenda.Shared.Utils;
using FluentAssertions;
using Moq;
using Moq.AutoMock;

namespace Agenda.Tests.Features.Client
{
    [Collection(nameof(CollectionClient))]
    public class ClientSendVerificationCodeSMSCommandHandlerTests
    {
        private readonly ClientTestsFixture _clientTestsFixture;

        public ClientSendVerificationCodeSMSCommandHandlerTests(ClientTestsFixture clientTestsFixture)
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
            var command = new ClientSendVerificationCodeSMSCommand() { PhoneNumber = phoneNumber };
            var autoMocker = new AutoMocker();
            var clientSendVerificationCodeSMSCommandHandler = autoMocker.CreateInstance<ClientSendVerificationCodeSMSCommandHandler>();
            autoMocker.GetMock<IVerificationCodeService>()
                .Setup(v => v.CreateVerificationCodeSMS(It.IsAny<string>(), It.IsAny<TypeOfVerificarionCodeEnum>()))
                .ReturnsAsync(RandomUtil.Numeric(5));

            // Act
            var result = await clientSendVerificationCodeSMSCommandHandler.Handle(command, CancellationToken.None);

            // Assert
            result.Errors.Should().HaveCount(0);
            autoMocker.GetMock<ITwilioService>().Verify(r => r.SendVerificationCode(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
    }
}
