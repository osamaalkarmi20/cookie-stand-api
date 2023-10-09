using cookie_stand_api.data;
using cookie_stand_api.model.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;

namespace cookie_stand_api.model.Services
{
    public class OneHourSaleService
    {
        private readonly CookieStandDbContext _dbContext;

        public OneHourSaleService(CookieStandDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public  void randomHourSales(CookieStand stand)
        {
            if(stand.hourlySales != null)
            {
                for (int i = 0; i < stand.hourlySales.Count; i++)
                {
                    _dbContext.oneHourSales.Remove(stand.hourlySales[i]);
               
                }
               
            }
                var hourlySales = new List<oneHourSales>();
                var random = new Random();

                for (var hour = 0; hour < 14; hour++)
                {
                    var one = new oneHourSales();
                    var customers = random.Next(stand.MinimumCustomersPerHour, stand.MaximumCustomersPerHour + 1);
                    one.hour = (int)(customers * stand.AverageCookiesPerSale);
                    one.CookieStandId = stand.Id;
                 
                    
                    _dbContext.oneHourSales.Add(one);
                    _dbContext.SaveChanges();

                }
           



            }
        }
    }
