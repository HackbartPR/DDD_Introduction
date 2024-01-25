using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Database.EntityFramework.Model
{
    public class Product
    {
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; } = string.Empty;

        [Required]
        public float Price { get; set; }

        [Required]
        public float RewardsPoints { get; set; }
    }
}
