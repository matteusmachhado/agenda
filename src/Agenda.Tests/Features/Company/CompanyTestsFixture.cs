using Agenda.Domain.Features.Company.Commands.Create;
using Bogus;
using Moq.AutoMock;

namespace Agenda.Tests.Features.Company
{
    [CollectionDefinition(nameof(CollectionCompany))]
    public class CollectionCompany : ICollectionFixture<CompanyTestsFixture> { }

    public class CompanyTestsFixture : IDisposable
    {
        public readonly AutoMocker AutoMocker;

        public CompanyTestsFixture()
        {
            AutoMocker = new AutoMocker();
        }

        public CompanyCreateCommand GenerateCompany() 
        {
            return GenerateCompanies(1).First();
        }

        public IEnumerable<CompanyCreateCommand> GenerateCompanies(int amount)
        {
            var companies = new Faker<CompanyCreateCommand>("pt_BR")
                .RuleFor(x => x.Name, f => f.Company.CompanyName())
                .RuleFor(x => x.Description, f => f.Lorem.Text());
            
            return companies.Generate(amount);
        }

        public void Dispose()
        {

        }
    }
}
