using OrderDashboard.Api.Models;

namespace OrderDashboard.Api.Services;

public class AuthService
{
    public const string DemoEmail = "inkoop@leverportaal.nl";
    public const string DemoPassword = "Acceptatie-2026";
    public const string DemoToken = "demo-token-2026";

    public LoginResponse? Login(string email, string password)
    {
        var emailOk = string.Equals(email.Trim(), DemoEmail, StringComparison.OrdinalIgnoreCase);
        var passwordOk = string.Equals(password, DemoPassword, StringComparison.Ordinal);
        if (!emailOk || !passwordOk)
        {
            return null;
        }

        return new LoginResponse
        {
            Token = DemoToken,
            DisplayName = "Inkoop",
        };
    }

    public bool IsValidBearer(string? authorizationHeader)
    {
        return string.Equals(authorizationHeader, $"Bearer {DemoToken}", StringComparison.Ordinal);
    }
}
