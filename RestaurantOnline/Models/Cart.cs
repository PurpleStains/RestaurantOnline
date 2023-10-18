using System.ComponentModel.DataAnnotations;

namespace RestaurantOnline.Models
{
    public class Cart
    {
        public Cart() { }

        [Key]
        public Guid Id { get; set; }
        public ICollection<MenuPosition> ToOrder { get; set; }
    }
}
