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
    public class ResourcesController : ApiController
    {
        private ProjectWorkplaceAzureContext db = new ProjectWorkplaceAzureContext();

        // GET: api/Resources
        public IQueryable<PW_Resources> GetPW_Resources()
        {
            return db.PW_Resources;
        }

        // GET: api/Resources/5
        [ResponseType(typeof(PW_Resources))]
        public IHttpActionResult GetPW_Resources(Guid id)
        {
            PW_Resources pW_Resources = db.PW_Resources.Find(id);
            if (pW_Resources == null)
            {
                return NotFound();
            }

            return Ok(pW_Resources);
        }

        // PUT: api/Resources/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPW_Resources(Guid id, PW_Resources pW_Resources)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pW_Resources.ResourceID)
            {
                return BadRequest();
            }

            db.Entry(pW_Resources).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PW_ResourcesExists(id))
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

        // POST: api/Resources
        [ResponseType(typeof(PW_Resources))]
        public IHttpActionResult PostPW_Resources(PW_Resources pW_Resources)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PW_Resources.Add(pW_Resources);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PW_ResourcesExists(pW_Resources.ResourceID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pW_Resources.ResourceID }, pW_Resources);
        }

        // DELETE: api/Resources/5
        [ResponseType(typeof(PW_Resources))]
        public IHttpActionResult DeletePW_Resources(Guid id)
        {
            PW_Resources pW_Resources = db.PW_Resources.Find(id);
            if (pW_Resources == null)
            {
                return NotFound();
            }

            db.PW_Resources.Remove(pW_Resources);
            db.SaveChanges();

            return Ok(pW_Resources);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PW_ResourcesExists(Guid id)
        {
            return db.PW_Resources.Count(e => e.ResourceID == id) > 0;
        }
    }
}