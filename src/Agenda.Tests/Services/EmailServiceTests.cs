
using Moq.AutoMock;
using Agenda.Domain.Services;
using Agenda.Shared.Settings;
using Microsoft.Extensions.Options;
using System.Net.Mail;
using Agenda.Domain.Interfaces;
using Moq;

namespace Agenda.Tests.Services
{
    public class EmailServiceTests
    {
        [Fact]
        public async void Email_Send_Success()
        {
            // Arrange
            //var autoMocker = new AutoMocker();
            //autoMocker.GetMock<IOptions<EmailSettings>>()
            //    .Setup(s => s.Value)
            //    .Returns(new EmailSettings() 
            //{
            //    From = "test@test.com",
            //    Host = "localhost",
            //    Login = "",
            //    Password = "",
            //    Port = 25,
            //    EnableSsl = false
            //});
            //var message = new MailMessage("test@test.com", "test@test.com", "Subject", "Body");
            //var emailService = autoMocker.CreateInstance<EmailService>();
            //autoMocker.GetMock<IEmailService>()
            //    .Setup(s => s.Send(It.IsAny<MailMessage>()))
            //    .Returns(Task.CompletedTask);

            // Act
            //await emailService.Send(message);

            // Assert
            //autoMocker.GetMock<IEmailService>().Verify(r => r.Send(message), Times.Once);
        }

    }
}
