using Microsoft.Build.ObjectModelRemoting;
using static Wassandashboard.Components.Pages.Projects.Index;

namespace Wassandashboard.Data.Models.Dto
{
    public class ProjectsGridDTO
    {
        public long Id { get; set; }    

        public string Name { get; set; } = string.Empty;
        public List<ProjectLinksData> ProjectLinksData { get; set; } = new List<ProjectLinksData>();
    }
}
