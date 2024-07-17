using System;

namespace FEProject.Communities
{
    public class CommunityDto
    {
        public Guid Id { get; set; }
        public string CommunityName { get; set; }
        public string CommunityName_Ar { get; set; }
        public Guid CreatedBy { get; set; }
        public string MainBranch { get; set; }
    }
}
