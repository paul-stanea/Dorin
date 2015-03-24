using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Disertatie3.Models
{
    public class StocProduse
    {
        [Required]
        public int Id { get; set; }

        public DateTime Data { get; set; }

        public int? ProdusId { get; set; }

        public virtual Produse Produse { get; set; }

        public int Cantitate { get; set; }
    }
}