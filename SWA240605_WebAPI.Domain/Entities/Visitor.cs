using System;
using System.Collections.Generic;

namespace SWA240605_WebAPI.Domain.Entities
{
    public class Visitor
    {
        public int Id { get; set; }
        public string IPAddress { get; set; } = string.Empty;
        public string Browser { get; set; } = string.Empty;
        public string Device { get; set; } = string.Empty;
        public DateTime VisitedOn { get; set; }
        //
        //Child entity
        //
        public ICollection<Applicant>? Applicants { get; set; }
    }
}
