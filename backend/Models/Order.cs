namespace OrderDashboard.Api.Models;

public class Order
{
    public int Id { get; set; }
    public string OrderNumber { get; set; } = string.Empty;
    public string CustomerName { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string Product { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal Total { get; set; }
    public string OrderedBy { get; set; } = string.Empty;
    public OrderStatus Status { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}
