using Agenda.Data.Interfaces;
using Agenda.Domain.Features.Company.Commands.Create;
using FluentAssertions;
using Moq;
using Moq.AutoMock;

namespace Agenda.Tests.Features.Company
{
    [Collection(nameof(CollectionCompany))]
    public class CompanyCreateCommandHandlerTests
    {
        private readonly CompanyTestsFixture _companyTestsFixture;

        public CompanyCreateCommandHandlerTests(CompanyTestsFixture companyTestsFixture)
        {
            _companyTestsFixture = companyTestsFixture;
        }

        [Fact]
        public async void Company_Add_Success()
        {
            // Arrange
            var company = _companyTestsFixture.GenerateCompany();
            var companyCreateCommandHandler = _companyTestsFixture.AutoMocker.CreateInstance<CompanyCreateCommandHandler>();

            // Act
            var result = await companyCreateCommandHandler.Handle(company, CancellationToken.None);

            // Assert
            result.Errors.Should().HaveCount(0);
            _companyTestsFixture.AutoMocker.GetMock<ICompanyRepository>().Verify(r => r.Add(It.IsAny<Entities.Entities.Company>()), Times.Once);
        }
    }
}
