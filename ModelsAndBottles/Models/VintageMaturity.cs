using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ModelsAndBottles.Models
{
    public class VintageMaturity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string MaturityDesc { get; set; }
    }
}