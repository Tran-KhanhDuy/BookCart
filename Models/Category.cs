using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookCart.Models
{
    public class Category
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? Description { get; set; }
    }
}
