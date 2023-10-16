namespace RestaurantOnline.Models
{
    public class CustomerOrder
    {
        public Guid Id { get; set; } 
        public string ClientName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public List<MenuPosition> Order { get; set; }
        public bool HasBeenPlaced { get; set; } = false;
    }
}
