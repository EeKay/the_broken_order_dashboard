using OrderDashboard.Api.Models;

namespace OrderDashboard.Api.Services;

public class OrderService
{
    private readonly List<Order> _orders =
    [
        new() { Id = 1, OrderNumber = "LZ-2026-08102", CustomerName = "Zorggroep De Linde", Location = "Breda, locatie Ginneken", Product = "Passieve tillift, 175 kg", Quantity = 2, Total = 4860.00m, OrderedBy = "M. Vermeer", Status = OrderStatus.Pending, CreatedAt = DateTimeOffset.Parse("2026-08-12T09:15:00+02:00") },
        new() { Id = 2, OrderNumber = "LZ-2026-08118", CustomerName = "Huisartsenpraktijk Merellaan", Location = "Tilburg", Product = "Bovenarm bloeddrukmeter, klinisch", Quantity = 8, Total = 1192.00m, OrderedBy = "A. de Wit", Status = OrderStatus.Processing, CreatedAt = DateTimeOffset.Parse("2026-08-14T11:40:00+02:00") },
        new() { Id = 3, OrderNumber = "LZ-2026-08133", CustomerName = "Verpleeghuis Zonnehof", Location = "Eindhoven, vleugel Noord", Product = "Incontinentiemateriaal, doos 100 st.", Quantity = 36, Total = 1044.00m, OrderedBy = "S. Hendriks", Status = OrderStatus.Shipped, CreatedAt = DateTimeOffset.Parse("2026-08-18T16:05:00+02:00") },
        new() { Id = 4, OrderNumber = "LZ-2026-08091", CustomerName = "Thuiszorg Kempen", Location = "Valkenswaard, team West", Product = "Pulsoximeter, vingertop", Quantity = 12, Total = 1548.00m, OrderedBy = "J. Peeters", Status = OrderStatus.Delivered, CreatedAt = DateTimeOffset.Parse("2026-07-29T08:20:00+02:00") },
        new() { Id = 5, OrderNumber = "LZ-2026-08140", CustomerName = "Revalidatie Markdal", Location = "Breda", Product = "Actieve rolstoel, standaardzitting", Quantity = 4, Total = 6320.00m, OrderedBy = "L. van Dijk", Status = OrderStatus.Pending, CreatedAt = DateTimeOffset.Parse("2026-08-25T13:55:00+02:00") },
        new() { Id = 6, OrderNumber = "LZ-2026-08121", CustomerName = "GGZ De Waarden", Location = "Den Bosch, polikliniek", Product = "AED-binnenkast, wandmontage", Quantity = 3, Total = 2175.00m, OrderedBy = "R. Gerritsen", Status = OrderStatus.Processing, CreatedAt = DateTimeOffset.Parse("2026-08-21T10:10:00+02:00") },
        new() { Id = 7, OrderNumber = "LZ-2026-08077", CustomerName = "Kraamzorg Brabant", Location = "Helmond", Product = "Babyweegschaal, ijkwaardig", Quantity = 6, Total = 890.00m, OrderedBy = "E. Coolen", Status = OrderStatus.Cancelled, CreatedAt = DateTimeOffset.Parse("2026-08-08T15:30:00+02:00") },
        new() { Id = 8, OrderNumber = "LZ-2026-08144", CustomerName = "Apotheek De Markt", Location = "Oosterhout", Product = "Medicatiekoelkast 2–8 °C, 140 L", Quantity = 1, Total = 2490.00m, OrderedBy = "P. Rahman", Status = OrderStatus.Shipped, CreatedAt = DateTimeOffset.Parse("2026-08-27T09:00:00+02:00") },
        new() { Id = 9, OrderNumber = "LZ-2026-08109", CustomerName = "Dagbesteding De Es", Location = "Uden", Product = "Anti-decubitusmatras, traagschuim", Quantity = 10, Total = 3150.00m, OrderedBy = "K. Smits", Status = OrderStatus.Delivered, CreatedAt = DateTimeOffset.Parse("2026-08-19T14:22:00+02:00") },
        new() { Id = 10, OrderNumber = "LZ-2026-08151", CustomerName = "Hospice Lindehof", Location = "Waalwijk", Product = "Zuurstofconcentrator, 5 L/min", Quantity = 2, Total = 3780.00m, OrderedBy = "T. Bakker", Status = OrderStatus.Pending, CreatedAt = DateTimeOffset.Parse("2026-08-28T08:45:00+02:00") },
        new() { Id = 11, OrderNumber = "LZ-2026-08127", CustomerName = "Wijkverpleging Delta", Location = "Roosendaal, team Zuid", Product = "Wondzorgset, steriel, 10-pack", Quantity = 48, Total = 672.00m, OrderedBy = "N. Jacobs", Status = OrderStatus.Processing, CreatedAt = DateTimeOffset.Parse("2026-08-22T16:18:00+02:00") },
        new() { Id = 12, OrderNumber = "LZ-2026-08136", CustomerName = "Zorggroep De Linde", Location = "Etten-Leur, locatie Haven", Product = "Hoog-laagbed, elektrisch", Quantity = 3, Total = 4410.00m, OrderedBy = "M. Vermeer", Status = OrderStatus.Shipped, CreatedAt = DateTimeOffset.Parse("2026-08-26T11:05:00+02:00") },
    ];

    public async Task<IReadOnlyList<Order>> GetOrdersAsync()
    {
        await Task.Delay(80);
        return _orders.ToList();
    }

    public async Task<Order?> GetOrderAsync(int id)
    {
        await Task.Delay(40);
        return _orders.FirstOrDefault(o => o.Id == id);
    }

    public async Task<Order?> UpdateStatusAsync(int id, OrderStatus status)
    {
        await Task.Delay(40);
        var order = _orders.FirstOrDefault(o => o.Id == id);
        if (order is null)
        {
            return null;
        }

        order.Status = status;
        return order;
    }
}
