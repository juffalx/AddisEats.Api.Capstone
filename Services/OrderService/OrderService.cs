using AddisEats.Api.Models;

namespace AddisEats.Api.Services.OrderService;

public class OrderService : IOrderService
{
    private static readonly List<Order>  _order = new List<Order>();
    public Order GetById(int id)
    {
        Order? result = _order.Where(r => r.Id == id).FirstOrDefault();
        return result;
    }

    public Order CreateOrder(Order query)
    {
        Order result  = new Order()
        {
            CustomerName = query.CustomerName,
            CustomerPhone = query.CustomerPhone,
            DeliveryAddress = query.DeliveryAddress,
            Id = query.Id,
            MenuItemId = query.MenuItemId,
            Quantity = query.Quantity,
            RestaurantId = query.RestaurantId,
            TotalAmount = query.TotalAmount
        };

        _order.Add(result);
        return result;
    }
}