using Agenda.Data.Interfaces;
using FluentValidation.Results;
using MediatR;

namespace Agenda.Domain.Features.Company.Commands.Create
{
    public class CompanyCreateCommandHandler : BaseCommandHandler, IRequestHandler<CompanyCreateCommand, ValidationResult>
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyCreateCommandHandler(ICompanyRepository companyRepository, IUnitOfWork _uow) : base (_uow)
        {
            _companyRepository = companyRepository;
        }

        public async Task<ValidationResult> Handle(CompanyCreateCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            var company = new Agenda.Entities.Entities.Company(request.Name, request.Description);

            _companyRepository.Add(company);

            return await Commit();
        }
    }
}
