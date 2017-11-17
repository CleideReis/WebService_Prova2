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
    public class ReceitaController : ApiController
    {
        private ConexaoPadrao db = new ConexaoPadrao();

        // GET: api/Receita
        public IQueryable<Receita> GetReceitas()
        {
            return db.Receitas;
        }

        // GET: api/Receita/5
        [ResponseType(typeof(Receita))]
        public IHttpActionResult GetReceita(int id)
        {
            Receita receita = db.Receitas.Find(id);
            if (receita == null)
            {
                return NotFound();
            }

            return Ok(receita);
        }

        // PUT: api/Receita/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutReceita(int id, Receita receita)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != receita.IdReceita)
            {
                return BadRequest();
            }

            db.Entry(receita).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReceitaExists(id))
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

        // POST: api/Receita
        [ResponseType(typeof(Receita))]
        public IHttpActionResult PostReceita(Receita receita)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Receitas.Add(receita);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = receita.IdReceita }, receita);
        }

        // DELETE: api/Receita/5
        [ResponseType(typeof(Receita))]
        public IHttpActionResult DeleteReceita(int id)
        {
            Receita receita = db.Receitas.Find(id);
            if (receita == null)
            {
                return NotFound();
            }

            db.Receitas.Remove(receita);
            db.SaveChanges();

            return Ok(receita);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReceitaExists(int id)
        {
            return db.Receitas.Count(e => e.IdReceita == id) > 0;
        }
    }
}