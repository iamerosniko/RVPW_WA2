using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ProjectWorkplaceAzure.Models;
using System.Web.Http.Cors;

namespace ProjectWorkplaceAzure.Controllers
{
    [EnableCors(origins: "*",
    headers: "*", methods: "*", exposedHeaders: "*")]
    public class LeadersController : ApiController
    {
        private ProjectWorkplaceAzureContext db = new ProjectWorkplaceAzureContext();

        // GET: api/Leaders
        public IQueryable<PW_Leaders> GetPW_Leaders()
        {
            return db.PW_Leaders;
        }

        // GET: api/Leaders/5
        [ResponseType(typeof(PW_Leaders))]
        public IHttpActionResult GetPW_Leaders(int id)
        {
            PW_Leaders pW_Leaders = db.PW_Leaders.Find(id);
            if (pW_Leaders == null)
            {
                return NotFound();
            }

            return Ok(pW_Leaders);
        }

        // PUT: api/Leaders/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPW_Leaders(int id, PW_Leaders pW_Leaders)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pW_Leaders.LeaderID)
            {
                return BadRequest();
            }

            db.Entry(pW_Leaders).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PW_LeadersExists(id))
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

        // POST: api/Leaders
        [ResponseType(typeof(PW_Leaders))]
        public IHttpActionResult PostPW_Leaders(PW_Leaders pW_Leaders)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PW_Leaders.Add(pW_Leaders);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pW_Leaders.LeaderID }, pW_Leaders);
        }

        // DELETE: api/Leaders/5
        [ResponseType(typeof(PW_Leaders))]
        public IHttpActionResult DeletePW_Leaders(int id)
        {
            PW_Leaders pW_Leaders = db.PW_Leaders.Find(id);
            if (pW_Leaders == null)
            {
                return NotFound();
            }

            db.PW_Leaders.Remove(pW_Leaders);
            db.SaveChanges();

            return Ok(pW_Leaders);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PW_LeadersExists(int id)
        {
            return db.PW_Leaders.Count(e => e.LeaderID == id) > 0;
        }
    }
}