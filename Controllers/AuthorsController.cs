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
    public class AuthorsController : ControllerBase
    {
        // db
        private BookstoreModel db;

        public AuthorsController(BookstoreModel db)
        {
            this.db = db;
        }

        // GET: api/authors
        [HttpGet]
        public IEnumerable<Author> Get()
        {
            return db.Authors.ToList();
        }

        // GET: api/authors/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }

        // POST: api/authors/
        [HttpPost]
        public ActionResult Post([FromBody] Author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Authors.Add(author);
            db.SaveChanges();
            return CreatedAtAction("Post", author);

        }

        // PUT: api/authors/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Entry(author).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return NoContent();
        }

        // DELETE: api/authors/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return NotFound();
            }
            db.Authors.Remove(author);
            db.SaveChanges();
            return Ok();
        }
    }
}