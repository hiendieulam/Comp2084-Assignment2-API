using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore_API.Models
{
    public class Author
    {
        [Key]
        public int id { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string name { get; set; }

        [Column(TypeName = "text")]
        public string email { get; set; }

        [Column(TypeName = "text")]
        public string address { get; set; }
    }
}
