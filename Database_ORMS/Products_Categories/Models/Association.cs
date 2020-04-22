using System;
using System.ComponentModel.DataAnnotations;

namespace Products_Categories.Models
{
    public class Association
    {
        [Key]
        public int AssociationId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int ProductId { get; set; }

        public Category AssociationCategories { get; set; }
        public Product AssociationProducts { get; set; }
        public Association() { }
    }
}