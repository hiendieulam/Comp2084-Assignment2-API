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
    public class CategoriesController : ControllerBase
    {
        // db
        private BookstoreModel db;

        public CategoriesController(BookstoreModel db)
        {
            this.db = db;
        }

        // GET: api/categories
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return db.Categories.ToList();
        }

        // GET: api/categories/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        // POST: api/categories/
        [HttpPost]
        public ActionResult Post([FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Categories.Add(category);
            db.SaveChanges();
            return CreatedAtAction("Post", category);

        }

        // PUT: api/categories/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return NoContent();
        }

        // DELETE: api/categories/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            db.Categories.Remove(category);
            db.SaveChanges();
            return Ok();
        }
    }
}