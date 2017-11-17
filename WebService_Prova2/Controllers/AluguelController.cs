using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Web.Http;
using System.Web.Http.Description;
using WebService_Prova2.Connect;
using WebService_Prova2.Models;

namespace WebService_Prova2.Controllers
{
    public class AluguelController : ApiController
    {
        private ConexaoPadrao db = new ConexaoPadrao();

        // GET: api/Aluguel
        public IQueryable<Aluguel> GetAlugueis()
        {
            return db.Alugueis;
        }

        // GET: api/Aluguel/5
        [ResponseType(typeof(Aluguel))]
        public IHttpActionResult GetAluguel(int id)
        {
            Aluguel aluguel = db.Alugueis.Find(id);
            if (aluguel == null)
            {
                return NotFound();
            }

            return Ok(aluguel);
        }

        // PUT: api/Aluguel/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAluguel(int id, Aluguel aluguel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aluguel.IdAluguel)
            {
                return BadRequest();
            }

            db.Entry(aluguel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AluguelExists(id))
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

        // POST: api/Aluguel
        [ResponseType(typeof(Aluguel))]
        public IHttpActionResult PostAluguel(Aluguel aluguel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Alugueis.Add(aluguel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = aluguel.IdAluguel }, aluguel);
        }

        // DELETE: api/Aluguel/5
        [ResponseType(typeof(Aluguel))]
        public IHttpActionResult DeleteAluguel(int id)
        {
            Aluguel aluguel = db.Alugueis.Find(id);
            if (aluguel == null)
            {
                return NotFound();
            }

            db.Alugueis.Remove(aluguel);
            db.SaveChanges();

            return Ok(aluguel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AluguelExists(int id)
        {
            return db.Alugueis.Count(e => e.IdAluguel == id) > 0;
        }
    }
}