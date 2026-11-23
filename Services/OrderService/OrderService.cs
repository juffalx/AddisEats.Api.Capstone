using AddisEats.Api.Common;
using AddisEats.Api.Models;

namespace AddisEats.Api.Services.OrderService;

public class OrderService : IOrderService
{
    private static readonly List<Order>  _order = new List<Order>();
    public Result<Order> GetById(int id)
{
    Order? result = _order.FirstOrDefault(r => r.Id == id);

    if (result is null)
    {
        return Result<Order>.Fail(
            "ORDER_NOT_FOUND",
            "Order was not found.",
            404);
    }

    return Result<Order>.Ok(result);
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