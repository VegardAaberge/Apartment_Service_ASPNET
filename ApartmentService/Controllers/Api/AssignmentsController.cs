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
using ApartmentService.Models;

namespace ApartmentService.Controllers.Api
{
    public class AssignmentsController : ApiController
    {
        private ApartmentServiceContext db = new ApartmentServiceContext();

        // GET: api/Assignments
    public IQueryable<Assignment> GetAssignments()
        {          
            return db.Assignments;
        }

        [Route("api/assignments/created_by/{userName}/{statusType}/{status}")]
        public IQueryable<Assignment> GetCreatedAssignments(string userName, string statusType, string status)
        {
            IQueryable<Assignment> assignments = null;

            if (statusType == "0")
            {
                assignments = db.Assignments.Where(emp => ((emp.Status != status) && (emp.CreatedBy.ToLower() == userName.ToLower())));
            }
            else
            {
                assignments = db.Assignments.Where(emp => ((emp.Status == status) && (emp.CreatedBy.ToLower() == userName.ToLower())));
            }
            
            return assignments;
        }

        [Route("api/assignments/responsible/{userName}/{statusType}/{status}")]
        public IQueryable<Assignment> GetAssignedAssignments(string userName, string statusType, string status)
        {
            IQueryable<Assignment> assignments = null;

            if (statusType == "0")
            {
                assignments = db.Assignments.Where(emp => ((emp.Status != status) && (emp.Responsible.ToLower() == userName.ToLower())));
            }
            else
            {
                assignments = db.Assignments.Where(emp => ((emp.Status == status) && (emp.Responsible.ToLower() == userName.ToLower())));
            }

            return assignments;
        }

        // GET: api/Assignments/5
        [ResponseType(typeof(Assignment))]
        public async Task<IHttpActionResult> GetAssignment(int id)
        {
            Assignment assignment = await db.Assignments.FindAsync(id);
            if (assignment == null)
            {
                return NotFound();
            }
            
            return Ok(assignment);
        }

        // PUT: api/Assignments/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAssignment(int id, Assignment assignment)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != assignment.ID)
            {
                return BadRequest();
            }

            db.Entry(assignment).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssignmentExists(id))
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

        // POST: api/Assignments
        [ResponseType(typeof(Assignment))]
        public async Task<IHttpActionResult> PostAssignment(Assignment assignment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Assignments.Add(assignment);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = assignment.ID }, assignment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AssignmentExists(int id)
        {
            return db.Assignments.Count(e => e.ID == id) > 0;
        }
    }
}