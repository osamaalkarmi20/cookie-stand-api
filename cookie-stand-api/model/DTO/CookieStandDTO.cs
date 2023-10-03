namespace cookie_stand_api.model.DTO
{
    public class CookieStandDTO
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public List<int> hourlySales { get; set; }
        public int MinimumCustomersPerHour { get; set; }
        public int MaximumCustomersPerHour { get; set; }
        public double AverageCookiesPerSale { get; set; }
        public string Owner { get; set; }
    }
}
