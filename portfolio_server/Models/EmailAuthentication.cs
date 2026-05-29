using portfolio_server.Interfaces;

namespace portfolio_server.Models
{
    public class EmailAuthentication : IEmailAuthentication
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
