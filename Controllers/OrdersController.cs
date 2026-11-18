using AddisEats.Api.DTOs;
using AddisEats.Api.Mappers;
using AddisEats.Api.Models;
using AddisEats.Api.Services.OrderService;
using Microsoft.AspNetCore.Mvc;

namespace AddisEats.Api.Controllers;

[ApiController]
[Route("api/v1/orders")]

public class OrdersController : ControllerBase
{

    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }


    [HttpGet("{id:int}")]
    public ActionResult<OrderDTO> GetById(int id)
    {
        var result = _orderService.GetById(id);
        if(result == null)
        {
            return NotFound();
        }

        return Ok(result.ToDTOs());
    }

    [HttpPost]
    public ActionResult<Order> CreateOrder([FromBody] Order ForOrder)
    {
        var result = _orderService.CreateOrder(ForOrder);

        return CreatedAtAction(
            nameof(CreateOrder),
            new {id = result.Id},
            result
        ) ;
        
    }
}