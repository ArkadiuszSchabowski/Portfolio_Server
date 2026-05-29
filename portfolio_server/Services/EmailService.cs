using portfolio_server.Interfaces;
using portfolio_server.Models;
using FluentEmail.Core;

namespace portfolio_server.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailAuthentication _emailAuthentication;
        private readonly ISenderFactory _senderFactory;
        public EmailService(IEmailAuthentication emailAuthentication, ISenderFactory senderFactory)
        {
            _emailAuthentication = emailAuthentication;
            _senderFactory = senderFactory;
        }
        public async Task Send(SendEmailDto dto)
        {
            _senderFactory.CreateSender();

            var email = await Email
                .From(emailAddress: _emailAuthentication.Email)
                .To(emailAddress: _emailAuthentication.Email)
                .Subject(dto.Subject)
                .Body($"Message from: {dto.From}, {dto.Message}")
                .SendAsync();
        }
    }
}
