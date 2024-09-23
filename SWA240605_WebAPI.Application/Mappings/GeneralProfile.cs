using AutoMapper;
using SWA240605_WebAPI.Application.Features.Commands;
using SWA240605_WebAPI.Application.Features.VisitorFeature.Commands;
using SWA240605_WebAPI.Domain.Entities;

namespace SWA240605_WebAPI.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<CreateApplicantCommand, Applicant>();
            CreateMap<CreateVisitorCommand, Visitor>();
        }
    }
}
