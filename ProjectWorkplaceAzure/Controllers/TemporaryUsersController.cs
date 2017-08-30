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
    public class TemporaryUsersController : ApiController
    {
        private ProjectWorkplaceAzureContext db = new ProjectWorkplaceAzureContext();

        // GET: api/TemporaryUsers
        public IQueryable<PW_TemporaryUsers> GetPW_TemporaryUsers()
        {
            return db.PW_TemporaryUsers;
        }

        // GET: api/TemporaryUsers/5
        [ResponseType(typeof(PW_TemporaryUsers))]
        public IHttpActionResult GetPW_TemporaryUsers(int id)
        {
            PW_TemporaryUsers pW_TemporaryUsers = db.PW_TemporaryUsers.Find(id);
            if (pW_TemporaryUsers == null)
            {
                return NotFound();
            }

            return Ok(pW_TemporaryUsers);
        }

        // PUT: api/TemporaryUsers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPW_TemporaryUsers(int id, PW_TemporaryUsers pW_TemporaryUsers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pW_TemporaryUsers.ID)
            {
                return BadRequest();
            }

            db.Entry(pW_TemporaryUsers).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PW_TemporaryUsersExists(id))
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

        // POST: api/TemporaryUsers
        [ResponseType(typeof(PW_TemporaryUsers))]
        public IHttpActionResult PostPW_TemporaryUsers(PW_TemporaryUsers pW_TemporaryUsers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PW_TemporaryUsers.Add(pW_TemporaryUsers);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pW_TemporaryUsers.ID }, pW_TemporaryUsers);
        }

        // DELETE: api/TemporaryUsers/5
        [ResponseType(typeof(PW_TemporaryUsers))]
        public IHttpActionResult DeletePW_TemporaryUsers(int id)
        {
            PW_TemporaryUsers pW_TemporaryUsers = db.PW_TemporaryUsers.Find(id);
            if (pW_TemporaryUsers == null)
            {
                return NotFound();
            }

            db.PW_TemporaryUsers.Remove(pW_TemporaryUsers);
            db.SaveChanges();

            return Ok(pW_TemporaryUsers);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PW_TemporaryUsersExists(int id)
        {
            return db.PW_TemporaryUsers.Count(e => e.ID == id) > 0;
        }
    }
}