using System.ComponentModel.DataAnnotations;

namespace RestaurantOnline.Models
{
	public class MenuPosition
	{
		[Key]
		public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
		[Required]
        public double Price { get; set; }
	}
}
