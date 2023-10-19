namespace RestaurantOnline.Controllers.RequestModel;

public class CustomerOrderRequest
{
    public string? ClientName { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? Phone { get; set; }
    public Guid CartId { get; set; }
}