namespace Wassandashboard.Data.Entities
{
    public class ProjectRegions : BaseEntity
    {
        public long ProjectId { get; set; }
        public long RegionId { get; set; }

        public Projects Project { get; set; }
        public Regions Region { get; set; }
    }

}
