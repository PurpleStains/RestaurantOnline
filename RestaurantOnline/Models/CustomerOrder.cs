using System.ComponentModel.DataAnnotations;

namespace RestaurantOnline.Models
{
    public class CustomerOrder
    {
        [Key]
        public Guid Id { get; set; } 
        public string? ClientName { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? Phone { get; set; }
        public Cart Cart { get; set; }
    }
}
