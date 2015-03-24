using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Disertatie3.Models
{
    public class Retete
    {
        [Required]
        public int Id { get; set; }

        public int? ProdusId { get; set; }

        public virtual Produse Produse { get; set; }

        public int? MaterieId { get; set; }

        public virtual MateriiPrime Materii { get; set; }

        public int Cantitate { get; set; }

        public int? UserId { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}