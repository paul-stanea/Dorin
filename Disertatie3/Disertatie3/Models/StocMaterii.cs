using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Disertatie3.Models
{
    public class StocMaterii
    {
        [Required]
        public int Id { get; set; }

        public DateTime Data { get; set; }

        public int? MaterieId { get; set; }

        public virtual MateriiPrime Materii { get; set; }

        public int Cantitate { get; set; }

    

    }
}