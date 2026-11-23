namespace AddisEats.Api.DTOs;

public class CreateOrderRequest
{
    public int RestaurantId { get; set; }
    public string Area { get; set; } = string.Empty;
    public string CustomerName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public List<OrderLineRequest> Items { get; set; } = new();

};