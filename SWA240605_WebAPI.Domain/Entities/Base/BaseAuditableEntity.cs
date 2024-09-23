using System;

namespace SWA240605_WebAPI.Domain.Entities.Base
{
    public class BaseAuditableEntity
    {
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
        public string LastModifiedBy { get; set; } = string.Empty;
        public DateTime? LastModifiedOn { get; set; }
    }
}
