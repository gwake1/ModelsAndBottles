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
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ModelsAndBottles.Models;

namespace ModelsAndBottles.Controllers
{
    public class WineListsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/WineLists
        public IQueryable<WineList> GetWineLists()
        {
            return db.WineLists;
        }

        // GET: api/WineLists/5
        [ResponseType(typeof(WineList))]
        public async Task<IHttpActionResult> GetWineList(int id)
        {
            WineList wineList = await db.WineLists.FindAsync(id);
            if (wineList == null)
            {
                return NotFound();
            }

            return Ok(wineList);
        }

        // PUT: api/WineLists/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutWineList(int id, WineList wineList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != wineList.Id)
            {
                return BadRequest();
            }

            db.Entry(wineList).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WineListExists(id))
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

        // POST: api/WineLists
        [ResponseType(typeof(WineList))]
        public async Task<IHttpActionResult> PostWineList(WineList wineList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.WineLists.Add(wineList);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = wineList.Id }, wineList);
        }

        // DELETE: api/WineLists/5
        [ResponseType(typeof(WineList))]
        public async Task<IHttpActionResult> DeleteWineList(int id)
        {
            WineList wineList = await db.WineLists.FindAsync(id);
            if (wineList == null)
            {
                return NotFound();
            }

            db.WineLists.Remove(wineList);
            await db.SaveChangesAsync();

            return Ok(wineList);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WineListExists(int id)
        {
            return db.WineLists.Count(e => e.Id == id) > 0;
        }
    }
}