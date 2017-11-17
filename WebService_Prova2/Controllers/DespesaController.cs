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
    public class DespesaController : ApiController
    {
        private ConexaoPadrao db = new ConexaoPadrao();

        // GET: api/Despesa
        public IQueryable<Despesa> GetDespesas()
        {
            return db.Despesas;
        }

        // GET: api/Despesa/5
        [ResponseType(typeof(Despesa))]
        public IHttpActionResult GetDespesa(int id)
        {
            Despesa despesa = db.Despesas.Find(id);
            if (despesa == null)
            {
                return NotFound();
            }

            return Ok(despesa);
        }

        // PUT: api/Despesa/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDespesa(int id, Despesa despesa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != despesa.IdDespesa)
            {
                return BadRequest();
            }

            db.Entry(despesa).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DespesaExists(id))
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

        // POST: api/Despesa
        [ResponseType(typeof(Despesa))]
        public IHttpActionResult PostDespesa(Despesa despesa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Despesas.Add(despesa);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = despesa.IdDespesa }, despesa);
        }

        // DELETE: api/Despesa/5
        [ResponseType(typeof(Despesa))]
        public IHttpActionResult DeleteDespesa(int id)
        {
            Despesa despesa = db.Despesas.Find(id);
            if (despesa == null)
            {
                return NotFound();
            }

            db.Despesas.Remove(despesa);
            db.SaveChanges();

            return Ok(despesa);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DespesaExists(int id)
        {
            return db.Despesas.Count(e => e.IdDespesa == id) > 0;
        }
    }
}