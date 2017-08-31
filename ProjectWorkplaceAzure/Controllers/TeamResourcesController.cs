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
    public class TeamResourcesController : ApiController
    {
        private ProjectWorkplaceAzureContext db = new ProjectWorkplaceAzureContext();

        // GET: api/TeamResources
        public IQueryable<PW_TeamResources> GetPW_TeamResources()
        {
            return db.PW_TeamResources;
        }

        // GET: api/TeamResources/5
        [ResponseType(typeof(PW_TeamResources))]
        public IHttpActionResult GetPW_TeamResources(int id)
        {
            PW_TeamResources pW_TeamResources = db.PW_TeamResources.Find(id);
            if (pW_TeamResources == null)
            {
                return NotFound();
            }

            return Ok(pW_TeamResources);
        }

        // PUT: api/TeamResources/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPW_TeamResources(int id, PW_TeamResources pW_TeamResources)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pW_TeamResources.TeamResourceID)
            {
                return BadRequest();
            }

            db.Entry(pW_TeamResources).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PW_TeamResourcesExists(id))
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

        // POST: api/TeamResources
        [ResponseType(typeof(PW_TeamResources))]
        public IHttpActionResult PostPW_TeamResources(PW_TeamResources pW_TeamResources)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PW_TeamResources.Add(pW_TeamResources);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pW_TeamResources.TeamResourceID }, pW_TeamResources);
        }

        // DELETE: api/TeamResources/5
        [ResponseType(typeof(PW_TeamResources))]
        public IHttpActionResult DeletePW_TeamResources(int id)
        {
            PW_TeamResources pW_TeamResources = db.PW_TeamResources.Find(id);
            if (pW_TeamResources == null)
            {
                return NotFound();
            }

            db.PW_TeamResources.Remove(pW_TeamResources);
            db.SaveChanges();

            return Ok(pW_TeamResources);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PW_TeamResourcesExists(int id)
        {
            return db.PW_TeamResources.Count(e => e.TeamResourceID == id) > 0;
        }
    }
}