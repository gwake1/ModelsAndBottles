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
    public class TerroirsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Terroirs
        public IQueryable<Terroir> GetTerroirs()
        {
            return db.Terroirs;
        }

        // GET: api/Terroirs/5
        [ResponseType(typeof(Terroir))]
        public async Task<IHttpActionResult> GetTerroir(int id)
        {
            Terroir terroir = await db.Terroirs.FindAsync(id);
            if (terroir == null)
            {
                return NotFound();
            }

            return Ok(terroir);
        }

        // PUT: api/Terroirs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTerroir(int id, Terroir terroir)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != terroir.Id)
            {
                return BadRequest();
            }

            db.Entry(terroir).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TerroirExists(id))
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

        // POST: api/Terroirs
        [ResponseType(typeof(Terroir))]
        public async Task<IHttpActionResult> PostTerroir(Terroir terroir)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Terroirs.Add(terroir);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = terroir.Id }, terroir);
        }

        // DELETE: api/Terroirs/5
        [ResponseType(typeof(Terroir))]
        public async Task<IHttpActionResult> DeleteTerroir(int id)
        {
            Terroir terroir = await db.Terroirs.FindAsync(id);
            if (terroir == null)
            {
                return NotFound();
            }

            db.Terroirs.Remove(terroir);
            await db.SaveChangesAsync();

            return Ok(terroir);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TerroirExists(int id)
        {
            return db.Terroirs.Count(e => e.Id == id) > 0;
        }
    }
}