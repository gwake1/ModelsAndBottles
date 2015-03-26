using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ModelsAndBottles.Models;

namespace ModelsAndBottles.Controllers
{
    public class VintageMaturitiesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/VintageMaturities
        public IQueryable<VintageMaturity> GetVintageMaturities()
        {
            return db.VintageMaturities;
        }

        // GET: api/VintageMaturities/5
        [ResponseType(typeof(VintageMaturity))]
        public async Task<IHttpActionResult> GetVintageMaturity(int id)
        {
            VintageMaturity vintageMaturity = await db.VintageMaturities.FindAsync(id);
            if (vintageMaturity == null)
            {
                return NotFound();
            }

            return Ok(vintageMaturity);
        }

        // PUT: api/VintageMaturities/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutVintageMaturity(int id, VintageMaturity vintageMaturity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vintageMaturity.Id)
            {
                return BadRequest();
            }

            db.Entry(vintageMaturity).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VintageMaturityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/VintageMaturities
        [ResponseType(typeof(VintageMaturity))]
        public async Task<IHttpActionResult> PostVintageMaturity(VintageMaturity vintageMaturity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VintageMaturities.Add(vintageMaturity);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = vintageMaturity.Id }, vintageMaturity);
        }

        // DELETE: api/VintageMaturities/5
        [ResponseType(typeof(VintageMaturity))]
        public async Task<IHttpActionResult> DeleteVintageMaturity(int id)
        {
            VintageMaturity vintageMaturity = await db.VintageMaturities.FindAsync(id);
            if (vintageMaturity == null)
            {
                return NotFound();
            }

            db.VintageMaturities.Remove(vintageMaturity);
            await db.SaveChangesAsync();

            return Ok(vintageMaturity);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VintageMaturityExists(int id)
        {
            return db.VintageMaturities.Count(e => e.Id == id) > 0;
        }
    }
}