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
    public class AnswersController : ApiController
    {
        private ProjectWorkplaceAzureContext db = new ProjectWorkplaceAzureContext();

        // GET: api/Answers
        public IQueryable<PW_Answers> GetPW_Answers()
        {
            return db.PW_Answers;
        }

        // GET: api/Answers/5
        [ResponseType(typeof(PW_Answers))]
        public IHttpActionResult GetPW_Answers(Guid id)
        {
            PW_Answers pW_Answers = db.PW_Answers.Find(id);
            if (pW_Answers == null)
            {
                return NotFound();
            }

            return Ok(pW_Answers);
        }

        // PUT: api/Answers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPW_Answers(Guid id, PW_Answers pW_Answers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pW_Answers.AnswerID)
            {
                return BadRequest();
            }

            db.Entry(pW_Answers).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PW_AnswersExists(id))
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

        // POST: api/Answers
        [ResponseType(typeof(PW_Answers))]
        public IHttpActionResult PostPW_Answers(PW_Answers pW_Answers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PW_Answers.Add(pW_Answers);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PW_AnswersExists(pW_Answers.AnswerID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pW_Answers.AnswerID }, pW_Answers);
        }

        // DELETE: api/Answers/5
        [ResponseType(typeof(PW_Answers))]
        public IHttpActionResult DeletePW_Answers(Guid id)
        {
            PW_Answers pW_Answers = db.PW_Answers.Find(id);
            if (pW_Answers == null)
            {
                return NotFound();
            }

            db.PW_Answers.Remove(pW_Answers);
            db.SaveChanges();

            return Ok(pW_Answers);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PW_AnswersExists(Guid id)
        {
            return db.PW_Answers.Count(e => e.AnswerID == id) > 0;
        }
    }
}