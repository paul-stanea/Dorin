using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Disertatie3.Models
{
    public class Produse
    {
        public virtual ICollection<Retete> Retete { get; set; }
        public virtual ICollection<StocProduse> StocProduse { get; set; }

        [Required]
        public int Id { get; set; }

        public string Nume { get; set; }

        public bool IsDeleted { get; set; }

        public int? UserId { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}