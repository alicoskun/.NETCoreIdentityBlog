using System.Threading.Tasks;

namespace CoreIdentity.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
