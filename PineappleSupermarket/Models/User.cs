using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PineappleSupermarket.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string  Username{ get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Password { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Email { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Role { get; set; }//admin, viewer

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedDate { get; set; }

    }
}

