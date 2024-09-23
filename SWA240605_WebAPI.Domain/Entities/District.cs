using System.Collections.Generic;

namespace SWA240605_WebAPI.Domain.Entities
{
    public class District
    {
        public string? Code { get; set; }
        public string? Title { get; set; }
        public string? UnionStateCode { get; set; }
        //
        //Child entity
        //
        public IEnumerable<ApplicantContactAddress>? ApplicantContactAddresses { get; set; }
        public IEnumerable<ApplicantPermanentAddress>? ApplicantPermanentAddresses { get; set; }
        //
        //parent entity
        //
        public UnionStateTerritory? UnionStateTerritories { get; set; }
    }
}
