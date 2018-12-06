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
    public class BooksController : ControllerBase
    {
        // db
        private BookstoreModel db;

        public BooksController(BookstoreModel db)
        {
            this.db = db;
        }

        // GET: api/books
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return db.Books.ToList();
        }

        // GET: api/books/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Book book = db.Books.Find(id);
            if(book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        // POST: api/books/
        [HttpPost]
        public ActionResult Post([FromBody] Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Books.Add(book);
            db.SaveChanges();
            return CreatedAtAction("Post", book);

        }

        // PUT: api/books/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Entry(book).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return NoContent();
        }

        // DELETE: api/books/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            db.Books.Remove(book);
            db.SaveChanges();
            return Ok();
        }
    }
}