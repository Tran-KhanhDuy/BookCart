using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BookCart.Models
{
    public class User
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        
        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? Fullname { get; set; }

        public string? Phone { get; set; }

        public int RoleId  { get; set; }

        [ForeignKey("RoleId")]
        public Role? Role { get; set; }
    }
}
