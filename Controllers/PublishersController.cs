using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        // db
        private BookstoreModel db;

        public PublishersController(BookstoreModel db)
        {
            this.db = db;
        }

        // GET: api/publishers
        [HttpGet]
        public IEnumerable<Publisher> Get()
        {
            return db.Publishers.ToList();
        }

        // GET: api/publishers/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Publisher publisher = db.Publishers.Find(id);
            if (publisher == null)
            {
                return NotFound();
            }
            return Ok(publisher);
        }

        // POST: api/publishers/
        [HttpPost]
        public ActionResult Post([FromBody] Publisher publisher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Publishers.Add(publisher);
            db.SaveChanges();
            return CreatedAtAction("Post", publisher);

        }

        // PUT: api/publishers/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Publisher publisher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Entry(publisher).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return NoContent();
        }

        // DELETE: api/publishers/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Publisher publisher = db.Publishers.Find(id);
            if (publisher == null)
            {
                return NotFound();
            }
            db.Publishers.Remove(publisher);
            db.SaveChanges();
            return Ok();
        }
    }
}