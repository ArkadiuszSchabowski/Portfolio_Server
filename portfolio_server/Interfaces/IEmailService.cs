using portfolio_server.Models;

namespace portfolio_server.Interfaces
{
    public interface IEmailService
    {
        Task Send(SendEmailDto dto);
    }
}
