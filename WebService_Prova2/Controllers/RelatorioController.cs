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
    public class RelatorioController : ApiController
    {
        private ConexaoPadrao db = new ConexaoPadrao();

        // GET: api/Relatorio
        public IQueryable<Relatorio> GetRelatorios()
        {
            return db.Relatorios;
        }

        // GET: api/Relatorio/5
        [ResponseType(typeof(Relatorio))]
        public IHttpActionResult GetRelatorio(int id)
        {
            Relatorio relatorio = db.Relatorios.Find(id);
            if (relatorio == null)
            {
                return NotFound();
            }

            return Ok(relatorio);
        }

        // PUT: api/Relatorio/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRelatorio(int id, Relatorio relatorio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != relatorio.IdRelatorio)
            {
                return BadRequest();
            }

            db.Entry(relatorio).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RelatorioExists(id))
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

        // POST: api/Relatorio
        [ResponseType(typeof(Relatorio))]
        public IHttpActionResult PostRelatorio(Relatorio relatorio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Relatorios.Add(relatorio);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = relatorio.IdRelatorio }, relatorio);
        }

        // DELETE: api/Relatorio/5
        [ResponseType(typeof(Relatorio))]
        public IHttpActionResult DeleteRelatorio(int id)
        {
            Relatorio relatorio = db.Relatorios.Find(id);
            if (relatorio == null)
            {
                return NotFound();
            }

            db.Relatorios.Remove(relatorio);
            db.SaveChanges();

            return Ok(relatorio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RelatorioExists(int id)
        {
            return db.Relatorios.Count(e => e.IdRelatorio == id) > 0;
        }
    }
}