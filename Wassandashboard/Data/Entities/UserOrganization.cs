using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wassandashboard.Data.Entities
{
    [Table("userprojects")]
    public class UserProjects : BaseEntity
    {
        [MaxLength(30), Required]
        public string UserName { get; set; }
        public long ProjectId { get; set; }
        
        [ForeignKey(nameof(ProjectId))]
        public Projects projects { get; set; }
    }
}
