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
            return await db.Tours.ToListAsync();
        }

        [HttpGet("Login.login={login}.password={password}")]
        public async Task<Client> GetUser([FromRoute] string login, [FromRoute] string password)
        {
            var userObj = await db.Clients.FirstOrDefaultAsync(x => x.Login == login &&
            x.Password == password);
            return userObj;
        }

        [HttpPost("AddVoucher")]
        public async Task<Voucher> GetVoucherAsync([FromBody] Voucher voucher)
        {
            try
            {
                await db.Vouchers.AddAsync(voucher);
                await db.SaveChangesAsync();
                return voucher;
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}
