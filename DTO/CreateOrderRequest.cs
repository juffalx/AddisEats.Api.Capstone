
using AddisEats.Api.Validations;

namespace AddisEats.Api.DTOs;

/// <summary>
/// Contains the information required to create a new restaurant order.
/// </summary>
public class CreateOrderRequest
{
    /// <summary>
    /// Gets or sets the ID of the restaurant receiving the order.
    /// Example: 1
    /// </summary>
    public int RestaurantId { get; set; }

    /// <summary>
    /// Gets or sets the ID of the menu item being ordered.
    /// Example: 5
    /// </summary>
    public int MenuItemId { get; set; }

    /// <summary>
    /// Gets or sets the customer's full name.
    /// Example: Abebe Kebede
    /// </summary>
    public string CustomerName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the delivery address.
    /// Example: Bole, Addis Ababa
    /// </summary>
    public string DeliveryAddress { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the customer's Ethiopian mobile phone number.
    /// Example: 0912345678
    /// </summary>
    [EthiopianMobile]
    public string CustomerPhone { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the quantity of the menu item.
    /// Example: 2
    /// </summary>
    public int Quantity { get; set; }
}
