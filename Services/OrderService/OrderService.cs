
using System.Collections.Generic;
using System.Linq;
using AddisEats.Api.Common;
using AddisEats.Api.DTOs;
using AddisEats.Api.Models;
using AddisEats.Api.Services.MenuItemService;
using Microsoft.AspNetCore.Mvc;

namespace AddisEats.Api.Services.OrderService;

public class OrderService : IOrderService
{
    private static readonly List<Order> _order = new();
    private static int _nextId = 1;
    private readonly ILogger<OrderService> _logger;

    private readonly IMenuItemService _menuItemService;

    public OrderService(IMenuItemService menuItemService, ILogger<OrderService> logger)
    {
        _menuItemService = menuItemService;
        _logger = logger;
    }
    [ProducesResponseType(typeof(OrderDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
    public Result<Order> GetById(int id)
    {
        Order? result = _order.FirstOrDefault(r => r.Id == id);

        if (result is null)
        {
            _logger.LogInformation(
    "Order {OrderId} was not found",
    id);
            return Result<Order>.Fail(
                "ORDER_NOT_FOUND",
                "Order was not found.",
                404);
        }

        return Result<Order>.Ok(result);
    }

    [ProducesResponseType(typeof(OrderDTO), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]

    public Result<Order> CreateOrder(CreateOrderRequest query)
    {
        MenuItem? menuItem = _menuItemService.GetById(query.MenuItemId);

        if (menuItem is null)
        {
            return Result<Order>.Fail(
                "MENU_ITEM_NOT_FOUND",
                "Menu item was not found.",
                404);
        }

        decimal totalAmount = menuItem.Price * query.Quantity;

        Order result = new()
        {
            Id = _nextId++,
            RestaurantId = query.RestaurantId,
            CustomerName = query.CustomerName,
            DeliveryAddress = query.DeliveryAddress,
            CustomerPhone = query.CustomerPhone,
            MenuItemId = query.MenuItemId,
            Quantity = query.Quantity,
            TotalAmount = totalAmount
        };

        _order.Add(result);

        _logger.LogInformation(
    "Order {OrderId} created with total {TotalAmount}",
    result.Id,
    result.TotalAmount);

        return Result<Order>.Ok(result);
    }
}
