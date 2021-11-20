using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PineappleSupermarket.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Name { get; set; }
        public int ProductCategory { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(300)]
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        [DisplayName("Picture")]
        public byte[] Picture { get; set; }

        public string ImageMimeType { get; set; }
    }
}