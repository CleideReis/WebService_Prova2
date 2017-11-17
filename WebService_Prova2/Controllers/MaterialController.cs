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
using WebService_Prova2.Connect;
using WebService_Prova2.Models;

namespace WebService_Prova2.Controllers
{
    public class MaterialController : ApiController
    {
        private ConexaoPadrao db = new ConexaoPadrao();

        // GET: api/Material
        public IQueryable<Material> GetMateriais()
        {
            return db.Materiais;
        }

        // GET: api/Material/5
        [ResponseType(typeof(Material))]
        public IHttpActionResult GetMaterial(int id)
        {
            Material material = db.Materiais.Find(id);
            if (material == null)
            {
                return NotFound();
            }

            return Ok(material);
        }

        // PUT: api/Material/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMaterial(int id, Material material)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != material.IdMaterial)
            {
                return BadRequest();
            }

            db.Entry(material).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaterialExists(id))
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

        // POST: api/Material
        [ResponseType(typeof(Material))]
        public IHttpActionResult PostMaterial(Material material)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Materiais.Add(material);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = material.IdMaterial }, material);
        }

        // DELETE: api/Material/5
        [ResponseType(typeof(Material))]
        public IHttpActionResult DeleteMaterial(int id)
        {
            Material material = db.Materiais.Find(id);
            if (material == null)
            {
                return NotFound();
            }

            db.Materiais.Remove(material);
            db.SaveChanges();

            return Ok(material);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MaterialExists(int id)
        {
            return db.Materiais.Count(e => e.IdMaterial == id) > 0;
        }
    }
}