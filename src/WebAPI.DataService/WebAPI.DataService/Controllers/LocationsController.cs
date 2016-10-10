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
using WebAPI.DataService.Models;
using Apprenda.SaaSGrid;

namespace WebAPI.DataService.Controllers
{
    public class LocationsController : ApiController
    {
        private WebAPIDataServiceContext db = new WebAPIDataServiceContext(TenantContext.Current.ConnectionString);

        // GET api/Locations
        public IQueryable<LocationModel> GetLocationModels()
        {
            return db.LocationModels;
        }

        // GET api/Locations/5
        [ResponseType(typeof(LocationModel))]
        public IHttpActionResult GetLocationModel(int id)
        {
            LocationModel locationmodel = db.LocationModels.Find(id);
            if (locationmodel == null)
            {
                return NotFound();
            }

            return Ok(locationmodel);
        }

        // PUT api/Locations/5
        public IHttpActionResult PutLocationModel(int id, LocationModel locationmodel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != locationmodel.Id)
            {
                return BadRequest();
            }

            db.Entry(locationmodel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationModelExists(id))
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

        // POST api/Locations
        [ResponseType(typeof(LocationModel))]
        public IHttpActionResult PostLocationModel(LocationModel locationmodel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LocationModels.Add(locationmodel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = locationmodel.Id }, locationmodel);
        }

        // DELETE api/Locations/5
        [ResponseType(typeof(LocationModel))]
        public IHttpActionResult DeleteLocationModel(int id)
        {
            LocationModel locationmodel = db.LocationModels.Find(id);
            if (locationmodel == null)
            {
                return NotFound();
            }

            db.LocationModels.Remove(locationmodel);
            db.SaveChanges();

            return Ok(locationmodel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LocationModelExists(int id)
        {
            return db.LocationModels.Count(e => e.Id == id) > 0;
        }
    }
}