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

        public string? Phone {  get; set; }
        public string? Address { get; set; }
        public DateTime Date { get; set; }

        public List<CartDetail>? CartDetails { get; set; }
    }
}
