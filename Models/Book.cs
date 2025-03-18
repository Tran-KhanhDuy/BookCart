using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace BookCart.Models
{
    public class Book
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        public string? Title { get; set; }

        public string? Description { get; set; }

        [Column(TypeName ="money")]
        public decimal Price { get; set; }

        public string? Image {  get; set; }
        public bool? Features { get; set; }

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

        [ForeignKey("AuthorId")]
        public Author? Author { get; set; }
    }
}
