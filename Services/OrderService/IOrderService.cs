namespace AddisEats.Api.Services.OrderService;
using AddisEats.Api.Models;
public interface IOrderService
{
    Order GetById(int id);
    Order CreateOrder(Order query);
}

