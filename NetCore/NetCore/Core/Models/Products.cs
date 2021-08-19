using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Core.Models
{
    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [StringLength(100)]
        public string? Description { get; set; }

        [Range(0,100)]
        public int? AgeRestriction { get; set; }

        [StringLength(50)]
        [Required]
        public string Company { get; set; }

        [Range(1, 1000)]
        [Required]
        public decimal Price { get; set; }
    }
}
