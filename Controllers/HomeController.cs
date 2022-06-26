using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmolenskTravelApi.Controllers
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
        [HttpPost("Registration")]
        public async Task<IActionResult> PostRegistration([FromBody] Client client)
        {
            try
            {
                await db.Clients.AddAsync(client);
                await db.SaveChangesAsync();
                return Ok(200);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        [HttpGet("Passport")]
        public async Task<List<Idpassport>> GetPassport()
        {
            return await db.Idpassports.Include(x => x.Idpassport1Navigation).Include(x => x.IdzagranPassportNavigation).ToListAsync();
        }
        [HttpGet("Login.login={login}.password={password}")]
        public async Task<Client> GetUser([FromRoute] string login, [FromRoute] string password)
        {
            var userObj = await db.Clients.FirstOrDefaultAsync(x => x.Login == login &&
            x.Password == password);
            return userObj;
        }
        [HttpGet("Tour")]
        public async Task<List<Tour>> GetTours()
        {
            return await db.Tours.Include(x => x.IdlivingTourNavigation)
                .Include(x => x.IdprogrammTourNavigation).Include(x => x.IdtourInfoNavigation).ToListAsync();
        }
        [HttpGet("Tour.id={id}")]
        public async Task<Tour> GetToursId([FromRoute] int id)
        {
            return await db.Tours.Include(x => x.IdlivingTourNavigation)
                .Include(x => x.IdprogrammTourNavigation).Include(x => x.IdtourInfoNavigation).FirstOrDefaultAsync(x => x.Id == id);
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
        [HttpDelete("DeleteVoucher.id={id}")]
        public async Task<ActionResult<Voucher>> DeleteEmployee([FromRoute] int id)
        {
            var result = await db.Vouchers
            .FirstOrDefaultAsync(e => e.Id == id);
            if (result != null)
            {
                db.Vouchers.Remove(result);
                await db.SaveChangesAsync();
                return result;
            }

            return null;
        }
        [HttpGet("Voucher")]
        public async Task<List<Voucher>> GetVoucher()
        {
            return await db.Vouchers.Include(x => x.IdtoursNavigation).ToListAsync();
        }
        [HttpGet("Favorite")]
        public async Task<List<Favorite>> GetFavorite()
        {
            return await db.Favorites.Include(x => x.IdtoursNavigation).ToListAsync();
        }
        [HttpPost("AddFavorite")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PostFavoriteAsync([FromBody] Favorite favorite)
        {
            try
            {
                var check = db.Favorites.Where(x => x.Idclient == favorite.Idclient && x.Idtours == favorite.Idtours).ToList();
                if (check.Count == 0)
                {
                    await db.Favorites.AddAsync(favorite);
                    await db.SaveChangesAsync();
                    return Ok("Новое поступление в ламоду");
                }
                if (check.Count != 0)
                {
                    return Ok("Ага блин повторяшка");
                }
                return Ok("Все сохранено");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("DeleteFavorite")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public List<Favorite> PostDeleteFavoriteAsync([FromBody] Favorite favorite)
        {
            try
            {
                db.Favorites.RemoveRange(favorite);
                db.SaveChangesAsync();
                return db.Favorites.ToList();
            }
            catch
            {
                return null;
            }
        }
        [HttpGet("LoadAboutPhoto.id={id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public List<AboutPhoto> GetAboutPhotoAsync([FromRoute] int id)
        {
            try
            {
                var aboutPhoto = db.AboutPhotos.Where(x => x.IdTour == id).ToList(); ;
                return aboutPhoto;
            }
            catch
            {
                return null;
            }
        }
    }
}
