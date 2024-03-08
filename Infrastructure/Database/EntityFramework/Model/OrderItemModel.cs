using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Database.EntityFramework.Model
{
    public class OrderItemModel
    {
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; } = string.Empty;

        [Required]
        public float Price { get; set; }

        [Required]
        public float Total { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [ForeignKey("ProductModel")]
        public Guid ProductId { get; set; }

        public virtual ProductModel Product { get; set; } = null!;
    }
}
