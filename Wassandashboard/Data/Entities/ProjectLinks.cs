using System.ComponentModel.DataAnnotations.Schema;

namespace Wassandashboard.Data.Entities
{
    public class ProjectLinks : BaseEntity
    {
        public string ProjectName { get; set; } = string.Empty;
        public string ProjectLink {  get; set; } = string.Empty;
        public bool IsSingleLink { get; set; } = false;
        public int IsPrivateOrPublic { get; set; } 
        public long ProjectId { get; set; }

        [ForeignKey(nameof(ProjectId))]
        public Projects projects { get; set; }
    }
}
