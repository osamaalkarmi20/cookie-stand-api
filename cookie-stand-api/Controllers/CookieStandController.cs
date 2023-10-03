using cookie_stand_api.data;
using cookie_stand_api.model;
using cookie_stand_api.model.DTO;
using cookie_stand_api.model.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace cookie_stand_api.Controllers
{


    [Route("[controller]")]
    [ApiController]
    public class CookieStandController : ControllerBase
    {
        private readonly CookieStandDbContext _dbContext;
        private readonly OneHourSaleService _oneHourSaleService;
         public CookieStandController(CookieStandDbContext dbContext, OneHourSaleService oneHourSaleService)
        {
            _dbContext = dbContext;
           _oneHourSaleService = oneHourSaleService;

        }

        [HttpPost]
        public ActionResult<CookieStand> CreateCookieStand(CREATCookieStandDTO standDto)
        {
            CookieStand stand = new CookieStand()
            {
                Location = standDto.Location,
                Description = standDto.Description,
                AverageCookiesPerSale = standDto.AverageCookiesPerSale,
                MaximumCustomersPerHour = standDto.MaximumCustomersPerHour,
                MinimumCustomersPerHour= standDto.MinimumCustomersPerHour,
                
                Owner = standDto.Owner,
            };
            _dbContext.CookieStands.Add(stand);
            _dbContext.SaveChanges();
            _oneHourSaleService.randomHourSales(stand);
            _dbContext.Entry(stand).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return CreatedAtAction(nameof(GetCookieStandById), new { id = stand.Id }, stand);
        }

        [HttpGet]
        public ActionResult<List<CookieStandDTO>> GetCookieStands()
        { List<CookieStandDTO> CookieStandDTOList = new List<CookieStandDTO>();
            var cookieStands = _dbContext.CookieStands.Include(X=> X.hourlySales).ToList();
            foreach (var stand in cookieStands){
              var hour=_dbContext.oneHourSales.Where(x=>x.CookieStandId ==stand.Id).Select(x=>x.hour).ToList();
               
                   var cookiestanddto = new CookieStandDTO
                { Id = stand.Id,
           Location=stand.Location,
           Description=stand.Description,
           MaximumCustomersPerHour=stand.MaximumCustomersPerHour,
           MinimumCustomersPerHour=stand.MinimumCustomersPerHour,
           AverageCookiesPerSale=stand.AverageCookiesPerSale,
           Owner=stand.Owner,
           hourlySales=hour};

                CookieStandDTOList.Add(cookiestanddto);
            }

            return Ok(CookieStandDTOList);
        }

        [HttpGet("{id}")]
        public ActionResult<CookieStandDTO> GetCookieStandById(int id)
        {
            var stand = _dbContext.CookieStands.Find(id);


            if (stand == null)
            {
                return NotFound();
            }
            var hour = _dbContext.oneHourSales.Where(x => x.CookieStandId == stand.Id).Select(x => x.hour).ToList();


            var cookiestanddto = new CookieStandDTO
            {
                Id = stand.Id,
                Location = stand.Location,
                Description = stand.Description,
                MaximumCustomersPerHour = stand.MaximumCustomersPerHour,
                MinimumCustomersPerHour = stand.MinimumCustomersPerHour,
                AverageCookiesPerSale = stand.AverageCookiesPerSale,
                Owner = stand.Owner,
                hourlySales = hour
            };

            return Ok(cookiestanddto);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCookieStand(int id)
        {
            var cookieStand = _dbContext.CookieStands.Find(id);

            if (cookieStand == null)
            {
                return NotFound();
            }

            _dbContext.CookieStands.Remove(cookieStand);
            _dbContext.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult<CookieStandDTO> UpdateCookieStand(int id, CREATCookieStandDTO updatedStand)
        {

            var Stand = _dbContext.CookieStands.Include(X => X.hourlySales).Where(a => a.Id == id).FirstOrDefault();
            if (id != _dbContext.CookieStands.Find(id).Id)
            {
                return BadRequest();
            }

            Stand.Description = updatedStand.Description;
            Stand.Location = updatedStand.Location;
            Stand.Owner = updatedStand.Owner;
            Stand.MinimumCustomersPerHour = updatedStand.MinimumCustomersPerHour;
            Stand.MaximumCustomersPerHour = updatedStand.MaximumCustomersPerHour;
             _oneHourSaleService.randomHourSales(Stand);

           
            _dbContext.Entry(Stand).State = EntityState.Modified;
            _dbContext.SaveChanges();
            var hour = _dbContext.oneHourSales.Where(x => x.CookieStandId == Stand.Id).Select(x => x.hour).ToList();
            var cookiestanddto = new CookieStandDTO
            {
                Id = Stand.Id,
                Location = updatedStand.Location,
                Description = updatedStand.Description,
                MaximumCustomersPerHour = updatedStand.MaximumCustomersPerHour,
                MinimumCustomersPerHour = updatedStand.MinimumCustomersPerHour,
                AverageCookiesPerSale = updatedStand.AverageCookiesPerSale,
                Owner = updatedStand.Owner,
                hourlySales = hour
            };
            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_dbContext.CookieStands.Any(c => c.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(cookiestanddto);
        }
    }
}