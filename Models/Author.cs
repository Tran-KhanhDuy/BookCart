using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookCart.Models
{
    public class Author
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column(TypeName ="nvarchar(255)")]

        public string? FirstName { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }

        List<Book>? books { get; set; }

    }
}
