using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Database.EntityFramework.Model
{
    public class CustomerModel
    {
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; } = string.Empty;

        [Required]
        public bool Active { get; set; }

        [Required]
        public int RewardsPoints { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string? Street { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string? City { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string? ZipCode { get; set; }
    }
}
