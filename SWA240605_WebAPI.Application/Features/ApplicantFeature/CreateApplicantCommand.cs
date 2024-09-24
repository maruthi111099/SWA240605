using MediatR;
using SWA240605_WebAPI.Application.Interfaces.Repositories;
using SWA240605_WebAPI.Application.Wrappers;
using SWA240605_WebAPI.Domain.Entities;
using System;
using System.Threading.Tasks;
using System.Threading;
using AutoMapper;

namespace SWA240605_WebAPI.Application.Features.ApplicantFeature
{
    public class CreateApplicantCommand : IRequest<APIResponse<int>>
    {
        public int ApplicationNo { get; set; }
        public string? FullName { get; set; }
        public string? FatherName { get; set; }
        public string? MotherName { get; set; }
        public string? MobileNo { get; set; }
        public string? EmailId { get; set; }
        public string? AadharNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? PostCode { get; set; }
        public string? PostUnitCode { get; set; }
        public int VisitorId { get; set; }

        public class CreateApplicantCommandHandler : IRequestHandler<CreateApplicantCommand, APIResponse<int>>
        {
            private readonly IApplicantRepository _applicantRepository;
            private readonly IMapper _mapper;

            public CreateApplicantCommandHandler(IApplicantRepository applicantRepository, IMapper mapper)
            {
                _applicantRepository = applicantRepository;
                _mapper = mapper;
            }

            public async Task<APIResponse<int>> Handle(CreateApplicantCommand command, CancellationToken cancellationToken)
            {
                // Mapping command to applicant
                Applicant applicant = _mapper.Map<Applicant>(command);

                // Adding the new applicant to the repository
                _applicantRepository.Add(applicant);

                // Commit the changes asynchronously and get the affected records count
                int affectedRecordsCount = await _applicantRepository.CommitAsync();

                // Returning the identifier of the newly created applicant
                return new APIResponse<int>(applicant.ApplicationNo);
            }
        }
    }
}
