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

namespace ProjectWorkplaceAzure.Controllers
{
    public class TeamsController : ApiController
    {
        private ProjectWorkplaceAzureContext db = new ProjectWorkplaceAzureContext();

        // GET: api/PW_Teams
        public IQueryable<PW_Teams> GetPW_Teams()
        {
            return db.PW_Teams.OrderBy(x=>x.TeamDesc);
        }

        // GET: api/PW_Teams/5
        [ResponseType(typeof(PW_Teams))]
        public IHttpActionResult GetPW_Teams(Guid id)
        {
            PW_Teams pW_Teams = db.PW_Teams.Find(id);
            if (pW_Teams == null)
            {
                return NotFound();
            }

            return Ok(pW_Teams);
        }

        // PUT: api/PW_Teams/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPW_Teams(Guid id, PW_Teams pW_Teams)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pW_Teams.TeamID)
            {
                return BadRequest();
            }

            db.Entry(pW_Teams).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PW_TeamsExists(id))
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

        // POST: api/PW_Teams
        [ResponseType(typeof(PW_Teams))]
        public IHttpActionResult PostPW_Teams(PW_Teams pW_Teams)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PW_Teams.Add(pW_Teams);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PW_TeamsExists(pW_Teams.TeamID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pW_Teams.TeamID }, pW_Teams);
        }

        // DELETE: api/PW_Teams/5
        [ResponseType(typeof(PW_Teams))]
        public IHttpActionResult DeletePW_Teams(Guid id)
        {
            PW_Teams pW_Teams = db.PW_Teams.Find(id);
            if (pW_Teams == null)
            {
                return NotFound();
            }

            db.PW_Teams.Remove(pW_Teams);
            db.SaveChanges();

            return Ok(pW_Teams);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PW_TeamsExists(Guid id)
        {
            return db.PW_Teams.Count(e => e.TeamID == id) > 0;
        }
    }
}