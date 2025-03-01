using NuGet.Protocol.Core.Types;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Wassandashboard.Components.Pages.Projects.Index;

namespace Wassandashboard.Data.Entities
{
    [Table("projects")]
    public class Projects : BaseEntity
    {
        [Required(ErrorMessage = "Project Name is Required"), MaxLength(100)]
        [Display(Name = "Project Name")]
        public string Name { get; set; }
                                  
        // Many-to-Many Relationship
        public List<ProjectRegions> ProjectRegions { get; set; } = new();
        //public List<ProjectLinks> ProjectLinks { get; set; } = new List<ProjectLinks>();

    }
}