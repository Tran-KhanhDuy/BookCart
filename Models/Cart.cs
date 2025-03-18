using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookCart.Models
{
    public class Cart
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        public int UserId { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string? FullName {  get; set; }
        [Column(TypeName = "nvarchar(20)")]

        public string? Phone {  get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string? Address { get; set; }
        [Column(TypeName = "Timestamp")]
        public DateTime Date { get; set; }
        [ForeignKey("UserId")]
        public List<Cart>? Carts { get; set; }

        
    }
}
