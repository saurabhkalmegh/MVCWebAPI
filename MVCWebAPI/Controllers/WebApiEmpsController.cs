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

namespace MVCWebAPI.Models
{
    public class WebApiEmpsController : ApiController
    {
        private Database1Entities db = new Database1Entities();

        // GET: api/WebApiEmps
        public IQueryable<WebApiEmp> GetWebApiEmps()
        {
            return db.WebApiEmps;
        }

        // GET: api/WebApiEmps/5
        [ResponseType(typeof(WebApiEmp))]
        public IHttpActionResult GetWebApiEmp(int id)
        {
            WebApiEmp webApiEmp = db.WebApiEmps.Find(id);
            if (webApiEmp == null)
            {
                return NotFound();
            }

            return Ok(webApiEmp);
        }

        // PUT: api/WebApiEmps/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWebApiEmp(int id, WebApiEmp webApiEmp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != webApiEmp.Id)
            {
                return BadRequest();
            }

            db.Entry(webApiEmp).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WebApiEmpExists(id))
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

        // POST: api/WebApiEmps
        [ResponseType(typeof(WebApiEmp))]
        public IHttpActionResult PostWebApiEmp(WebApiEmp webApiEmp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.WebApiEmps.Add(webApiEmp);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = webApiEmp.Id }, webApiEmp);
        }

        // DELETE: api/WebApiEmps/5
        [ResponseType(typeof(WebApiEmp))]
        public IHttpActionResult DeleteWebApiEmp(int id)
        {
            WebApiEmp webApiEmp = db.WebApiEmps.Find(id);
            if (webApiEmp == null)
            {
                return NotFound();
            }

            db.WebApiEmps.Remove(webApiEmp);
            db.SaveChanges();

            return Ok(webApiEmp);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WebApiEmpExists(int id)
        {
            return db.WebApiEmps.Count(e => e.Id == id) > 0;
        }
    }
}