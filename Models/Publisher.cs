using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore_API.Models
{
    public class Publisher
    {
        [Key]
        public int id { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string publish_name { get; set; }

        [Column(TypeName = "text")]
        public string company_name { get; set; }

        [Column(TypeName = "text")]
        public string address { get; set; }

        [Column(TypeName = "ntext")]
        public string postal_code { get; set; }

        [Column(TypeName = "text")]
        public string country { get; set; }
    }
}
