namespace OrderDashboard.Api.Models;

public class LoginResponse
{
    public string Token { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
}
