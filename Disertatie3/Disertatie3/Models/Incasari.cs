using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Disertatie3.Models
{
    public class Incasari
    {
        [Required]
        public int Id { get; set; }

        public bool Incasat { get; set; }

        public string DeLa { get; set; }

        public DateTime Data { get; set; }
        
        public string FacturaInc { get; set; }

        public string DocumentInc { get; set; }

        public int ValoareInc { get; set; }

        public DateTime Scadenta { get; set; }

        public string Scontare { get; set; }

        public string Girat { get; set; }

        public int? UserId { get; set; }
        public virtual UserProfile UserProfile { get; set; }


    }
}