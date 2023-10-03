

namespace cookie_stand_api.model
{
    public class oneHourSales
    {
        public int Id { get; set; }
        public int hour { get; set; }
        public int CookieStandId { get; set; }
        public CookieStand cookieStand { get; set; }

    }
}
