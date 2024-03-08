using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Database.EntityFramework.Model
{
    public class OrderModel
    {
        public Guid Id { get; set; }

        [Required]
        public float Total { get; set; }

        [Required]
        public int RewardPoints { get; set; }

        [Required]
        [ForeignKey("CustomerModel")]
        public Guid CustomerId { get; set; }

        [Required]
        public ICollection<OrderItemModel> Items { get; set; } = new HashSet<OrderItemModel>();
    }
}
