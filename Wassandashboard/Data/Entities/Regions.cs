using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wassandashboard.Data.Entities
{
    public class Regions : BaseEntity
    {
        public string RegionName { get; set; }
        // Many-to-Many Relationship
        public List<ProjectRegions> ProjectRegions { get; set; } = new();
    }
}
