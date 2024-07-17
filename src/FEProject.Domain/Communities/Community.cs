using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace FEProject.Communities
{
    public class Community : FullAuditedEntity<Guid>
    {
        public string CommunityName { get; set; }
        public string? CommunityName_Ar { get; set; }
        public string? MainBranch { get; set; }

        // Foreign key to the user who created this community
        public Guid CreatedBy { get; set; }



    }
}
