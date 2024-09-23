namespace SWA240605_WebAPI.Domain.Entities
{
    public class UnionStateTerritory
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int OrderIndex { get; set; }
        //
        //Child entity
        //
        public ApplicantContactAddress? ApplicantContactAddresses { get; set; }
        public ApplicantPermanentAddress? ApplicantPermanentAddresses { get; set; }
        public District? Districts { get; set; }
    }
}
