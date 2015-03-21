using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Disertatie2.Models
{
    public class MateriiPrime
    {
        public virtual ICollection<StocMaterii> StocMaterii { get; set; }
        public virtual ICollection<Consum> Consum { get; set; }
        public virtual ICollection<Retete> Retete { get; set; }

        [Required]
        [Key]
        public int Id { get; set; }

        public string Nume { get; set; }

        public int? UserId { get; set; }
        public virtual UserProfile UserProfile { get; set; }

        public bool IsDeleted { get; set; }
    }
}