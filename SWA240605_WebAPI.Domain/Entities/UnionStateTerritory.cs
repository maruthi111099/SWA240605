using System.Collections.Generic;

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
        public ICollection<ApplicantContactAddress>? ApplicantContactAddresses { get; set; }
        public ICollection<ApplicantPermanentAddress>? ApplicantPermanentAddresses { get; set; }
        public ICollection<District>? Districts { get; set; }
    }
}
