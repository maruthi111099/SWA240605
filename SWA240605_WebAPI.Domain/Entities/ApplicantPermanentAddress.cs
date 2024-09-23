namespace SWA240605_WebAPI.Domain.Entities
{
    public class ApplicantPermanentAddress
    {
        public int ApplicationNo { get; set; }
        public string? DoorNo { get; set; }
        public string? Street { get; set; }
        public string? Landmark { get; set; }
        public string? Taluk { get; set; }
        public string? City { get; set; }
        public string? DistrictCode { get; set; }
        public string? OtherDistrictName { get; set; }
        public string? UnionStateCode { get; set; }
        public string? Pincode { get; set; }
        //
        //parent entity
        //
        public District? Districts { get; set; }
        public UnionStateTerritory? UnionStateTerritories { get; set; }
        public ApplicantContactAddress? ApplicantContactAddresses { get; set; }
    }
}
