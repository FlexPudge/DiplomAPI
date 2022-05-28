using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoflanBobus.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        public SmolenskTravelContext db = new SmolenskTravelContext();

        [HttpGet("Client")]
        public async Task<List<Client>> GetClients()
        {
            return await db.Clients.ToListAsync();
        }

        [HttpGet("Tour")]
        public async Task<List<Tour>> GetTours()
        {
            return await db.Tours.Include(x=> x.IdlivingTourNavigation).Include(x=>x.IdprogrammTourNavigation).Include(x=>x.IdtourInfoNavigation).ToListAsync();
        }
        [HttpGet("Favorite")]
        public async Task<List<Favorite>> GetFavorite()
        {
            return await db.Favorites.Include(x => x.IdtoursNavigation).ToListAsync();
        }

        [HttpGet("Login.login={login}.password={password}")]
        public async Task<Client> GetUser([FromRoute] string login, [FromRoute] string password)
        {
            var userObj = await db.Clients.FirstOrDefaultAsync(x => x.Login == login &&
            x.Password == password);
            return userObj;
        }

        [HttpPost("AddVoucher")]
        public async Task<Voucher> PostVoucherAsync([FromBody] Voucher voucher)
        {
            try
            {
                await db.Vouchers.AddAsync(voucher);
                await db.SaveChangesAsync();
                return voucher;
            }
            catch
            {
                return null;
            }
        }

        [HttpPost("AddFavorite")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Favorite))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult PostFavoriteAsync([FromBody] Favorite favorite)
        {
            try
            {
                db.Favorites.AddAsync(favorite);
                db.SaveChangesAsync();
                return Ok("Все сохранено");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
