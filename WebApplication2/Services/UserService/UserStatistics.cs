namespace WebApplication2.Services.UserService
{
    public class UserStatistics
    {
        public string Role { get; set; }
        public string Shift { get; set; }
        public string Planification { get; set; }
        public int Month { get; set; }
        public int UserCount { get; set; }
    }

    public class UserStatisticsRequest
    {
        public int Month { get; set; }
    }
}
