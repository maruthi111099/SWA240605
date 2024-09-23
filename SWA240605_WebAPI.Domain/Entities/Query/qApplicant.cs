using System;

namespace SWA240605_WebAPI.Domain.Entities
{
    public class qApplicant
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
        public string? Photo {  get; set; }
        public string? Signatue {  get; set; }
        public string? Thumb { get; set; }
        public string? IdentityCard { get; set; }
    }
}
