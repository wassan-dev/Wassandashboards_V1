namespace Wassandashboard.Data.Models
{

    public class Token
    {
        public DateTime createdAt { get; set; }
        public DateTime expiresAt { get; set; }
        public string token { get; set; }
        public string csrf { get; set; }
    }

}
