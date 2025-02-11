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
        [Required(ErrorMessage = "Location is Required"), MaxLength(100)]
        [Display(Name = "Location")]
        public string Location { get; set; }
        [Required(ErrorMessage = "Location Type is Required"), MaxLength(100)]
        [Display(Name = "Location Type")]
        public string LocationType { get; set; }
        [Required(ErrorMessage = "No of Target Beneficiaries is Required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a valid value.")]
        [Display(Name = "No of Target Beneficiaries")]
        public int NoofTargetBeneficiaries { get; set; }

        [Required(ErrorMessage = "CSR/Partner/Donor Name is Required"), MaxLength(100)]
        [Display(Name = "CSR/Partner/Donor Name")]
        public string DonorName { get; set; }
        [Required(ErrorMessage = "Contact Person Name is Required"), MaxLength(50)]
        public string ContactPersonName { get; set; }
        [Required(ErrorMessage = "Contact Number is Required"), MaxLength(12)]
        public string ContactNumber { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Status is Required")]
        [Display(Name = "Status")]
        [Range(0, 1, ErrorMessage = "Please select a valid Status.")] // Valid values are 0 and 1 for Closed and Live.
        public int Status { get; set; }
        [NotMapped]
        public string StatusText => Status == 1 ? "Live" : "Closed";
        // Many-to-Many Relationship
        public List<ProjectRegions> ProjectRegions { get; set; } = new();
        //public List<ProjectLinks> ProjectLinks { get; set; } = new List<ProjectLinks>();

    }
}