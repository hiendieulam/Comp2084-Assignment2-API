using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore_API.Models
{
    public class Book
    {
        [Key]
        public int id { get; set; }

        [Column(TypeName = "text")]
        public string ISBN { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string title { get; set; }

        public int category_id { get; set; }

        public int publisher_id { get; set; }
        
        public DateTime publish_date { get; set; }

        public int author_id { get; set; }

        [Column(TypeName = "money")]
        public decimal prise { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string url { get; set; }

    }
}
