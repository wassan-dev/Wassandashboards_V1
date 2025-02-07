using System.ComponentModel.DataAnnotations;

namespace Wassandashboard.Data.Entities
{
    public class OdkBaseEntity : BaseEntity
    {
        public DateTime? submissionDate { get; set; }
        public string submitterId { get; set; }
        public string submitterName { get; set; }
        public bool Approved { get; set; } = false;
        public string ApprovedBy { get; set; }
    }

    public class BaseEntity
    {
        [Key]
        [Required]
        public long Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; } = null;
        public string UpdatedBy { get; set; } = null;
        public bool IsDeleted { get; set; }
    }
}
