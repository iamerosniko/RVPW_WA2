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
    public class QuestionsController : ApiController
    {
        private ProjectWorkplaceAzureContext db = new ProjectWorkplaceAzureContext();

        // GET: api/PW_Questions
        public IQueryable<PW_Questions> GetPW_Questions()
        {
            return db.PW_Questions;
        }

        // GET: api/PW_Questions/5
        [ResponseType(typeof(PW_Questions))]
        public IHttpActionResult GetPW_Questions(Guid id)
        {
            PW_Questions pW_Questions = db.PW_Questions.Find(id);
            if (pW_Questions == null)
            {
                return NotFound();
            }

            return Ok(pW_Questions);
        }

        // PUT: api/PW_Questions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPW_Questions(Guid id, PW_Questions pW_Questions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pW_Questions.QuestionID)
            {
                return BadRequest();
            }

            db.Entry(pW_Questions).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PW_QuestionsExists(id))
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

        // POST: api/PW_Questions
        [ResponseType(typeof(PW_Questions))]
        public IHttpActionResult PostPW_Questions(PW_Questions pW_Questions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PW_Questions.Add(pW_Questions);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PW_QuestionsExists(pW_Questions.QuestionID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pW_Questions.QuestionID }, pW_Questions);
        }

        // DELETE: api/PW_Questions/5
        [ResponseType(typeof(PW_Questions))]
        public IHttpActionResult DeletePW_Questions(Guid id)
        {
            PW_Questions pW_Questions = db.PW_Questions.Find(id);
            if (pW_Questions == null)
            {
                return NotFound();
            }

            db.PW_Questions.Remove(pW_Questions);
            db.SaveChanges();

            return Ok(pW_Questions);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PW_QuestionsExists(Guid id)
        {
            return db.PW_Questions.Count(e => e.QuestionID == id) > 0;
        }
    }
}